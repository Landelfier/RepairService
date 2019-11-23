using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RepairService.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace RepairService.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        ILogger logger;
        readonly UnitOfWork db;
        public AuthController(ILogger<AuthController> log, UnitOfWork uow)
        {
            db = uow;
            logger = log;
        }
        /// <summary>
        /// Return JWT barrier token to authenticate users
        /// </summary>
        /// <response code="200">return JWT token</response>
        /// <response code="400">If user wasnt found</response>    
        [FormContent("username", "Login/e-mail", "password","Password")]
        [ProducesResponseType(typeof(AuthResponseModel), 200)]
        [HttpPost("/authorize")]
        public async Task Token()
        {
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            var identity = GetIdentity(username,password);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password");
                return;
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience:AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            Response.StatusCode = 200;
            var response = new AuthResponseModel
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
        /// <summary>
        /// Register new user
        /// </summary>
        /// <response code="200">user was successfully created</response>
        /// <response code="400">user with the same login have already been created</response>  
        [FormContent("username", "Login/e-mail", "password", "Password", "fullname","User`s full name")]
        [HttpPost("/register")]
        public async Task Register()
        {
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            var fullName = Request.Form["fullname"];
            if (!db.Users.Find(x => x.Login == username).Any())
            {
                db.Users.Create(new User()
                {
                    Login = username,
                    Password = password,
                    FullName = fullName
                });
                Response.StatusCode = 200;
                db.Save();
            }
            else
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("This user has already been created");
            }
        }

        private ClaimsIdentity GetIdentity(string username,string password)
        {
            if (db.Users.Find(x => x.Login == username && x.Password == password).Any())
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, username),
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
}
}
