using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RepairService.Models;

namespace RepairService.Controllers
{
    [ApiController]
    public class FlatSettingsController : ControllerBase
    {
        ILogger logger;
        readonly UnitOfWork db;
        public FlatSettingsController(ILogger<AuthController> log, UnitOfWork uow)
        {
            db = uow;
            logger = log;
        }
        /// <summary>
        /// Create a new repair for selected flat items
        /// </summary>
        /// <response code="200">Id of created repair setting and repair cost</response>
        /// <response code="400">If user wasnt found</response>    
        [HttpPost("/flat/initialize")]
        [ProducesResponseType(typeof(RepairResponseModel),200)]
        public async Task CreateRepairSetting([FromBody]FlatModel model)
        {
            var user = db.Users.Find(x => x.Login == model.login).FirstOrDefault();
            if (user == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid user name");
                return;
            }

            var flat = new Flat()
            {
                User = user,
                Square = model.square,
                RoomNumber = model.roomNumber,
                DoorNumber = model.doorNumber,
                Height = model.height,
                Address = model.address,
                Rooms = model.rooms,
                Bathroom = db.BaseSettings.Find(x => x.ID == model.bathroomID).FirstOrDefault(),
                Kitchen = db.BaseSettings.Find(x => x.ID == model.kitchenID).FirstOrDefault(),
                Additionals = new List<AdditionalsFlat>(model.additionalsID.Select(x => new AdditionalsFlat() { AdditionalOptionsID = x}))
            };
            db.Flats.Create(flat);
            db.Save();
            Response.StatusCode = 200;
            await Response.WriteAsync(JsonConvert.SerializeObject(
                new RepairResponseModel
                {
                    FlatID = flat.ID,
                    Cost = getRepairCost(flat.ID)
                }));
        }

        double getRepairCost(int flatID)
        {
            Flat flat = db.Flats.Find(x=>x.ID == flatID).First();
            double cost = 0.0;
            cost += int.Parse(flat.Rooms.Doors.Cost) * flat.DoorNumber;//стоимость двери * количество
            cost += int.Parse(flat.Rooms.Walls.Cost) * flat.Square;//стоимость работы со стенами * площадь квартиры
            cost += double.Parse(flat.Rooms.Baseboard.Cost) * Math.Sqrt(flat.Square) * flat.RoomNumber;//стоимость плинтуса * ширину * количество комнат
            cost += int.Parse(flat.Rooms.Floor.Cost) * flat.Square;//стоимость пола * площадь квартиры
            cost += int.Parse(flat.Rooms.PowerSockets.Cost) * 0.29 * flat.Square;//стоимость розеток и выключателей * коэффициент * площадь
            cost += int.Parse(flat.Kitchen.Cost);//кухня
            cost += int.Parse(flat.Bathroom.Cost);//санузел(как и для кухни цена для выбраной вариации)
            foreach (var adds in flat.Additionals)//та штука что на сайте в опциях
                cost += adds.AdditionalOptions.Cost;
            return cost;

        }
        /// <summary>
        /// Returns list of repair settings that have been created by selected user
        /// </summary>
        /// <response code="200">list for selected user</response>
        /// <response code="400">If user wasnt found</response>   
        /// <param name="userLogin">Login of selected user</param>
        [HttpGet("/repairs")]
        [ProducesResponseType(typeof(IEnumerable<RepairResponseModel>), 200)]
        public JsonResult getUserCreatedRepairs(string userLogin) => new JsonResult(db.Flats.GetAll()
            .Select(x => new RepairResponseModel() 
            { 
                FlatID = x.ID, 
                Cost = getRepairCost(x.ID) 
            }));
    }
}