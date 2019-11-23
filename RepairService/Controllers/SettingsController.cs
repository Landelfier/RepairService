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
    public class SettingsController : ControllerBase
    {
        ILogger logger;
        readonly UnitOfWork db;
        public SettingsController(ILogger<AuthController> log, UnitOfWork uow)
        {
            db = uow;
            logger = log;
        }

        /// <summary>
        /// Returns Wall actions in room configurator
        /// </summary>
        /// <returns></returns>
        [HttpGet("/flat/room/walls")]
        [ProducesResponseType(typeof(IEnumerable<RepairSettingModel>), 200)]
        public JsonResult GetWallOptions() => new JsonResult(db.Materials
            .Find(m => m.Purpose == MaterialPurpose.Walls)
            .Select(x => new RepairSettingModel() { ID = x.ID, Name = x.Name, Cost = x.Cost, Description = x.Description, ColorList = x.MaterialColors.Select(y => y.color.ColorName) }));
        
        /// <summary>
        /// Returns Floor actions in room configurator
        /// </summary>
        [HttpGet("/flat/room/floors")]
        [ProducesResponseType(typeof(IEnumerable<RepairSettingModel>), 200)]
        public JsonResult GetFloorOptions() => new JsonResult(db.Materials
            .Find(m => m.Purpose == MaterialPurpose.Floor)
            .Select(x => new RepairSettingModel() { ID = x.ID, Name = x.Name, Cost = x.Cost, Description = x.Description, ColorList = x.MaterialColors.Select(y => y.color.ColorName) }));

        /// <summary>
        /// Returns avaliable doors in room configurator
        /// </summary>
        [HttpGet("/flat/room/doors")]
        [ProducesResponseType(typeof(IEnumerable<RepairSettingModel>), 200)]
        public JsonResult GetDoorOptions() => new JsonResult(db.Materials
            .Find(m => m.Purpose == MaterialPurpose.Doors)
            .Select(x => new RepairSettingModel() { ID = x.ID, Name = x.Name, Cost = x.Cost, Description = x.Description, ColorList = x.MaterialColors.Select(y => y.color.ColorName) }));

        /// <summary>
        /// Returns avaliable baseboards in room configurator
        /// </summary>
        [HttpGet("/flat/room/baseboards")]
        [ProducesResponseType(typeof(IEnumerable<RepairSettingModel>), 200)]
        public JsonResult GetBaseboardOptions() => new JsonResult(db.Materials
            .Find(m => m.Purpose == MaterialPurpose.Baseboard)
            .Select(x => new RepairSettingModel() { ID = x.ID, Name = x.Name, Cost = x.Cost, Description = x.Description, ColorList = x.MaterialColors.Select(y => y.color.ColorName) }));

        /// <summary>
        /// Returns avaliable powersockets and in room configurator
        /// </summary>
        [HttpGet("/flat/room/powersockets")]
        [ProducesResponseType(typeof(IEnumerable<RepairSettingModel>), 200)]
        public JsonResult GetPowerSocketsOptions() => new JsonResult(db.Materials
            .Find(m => m.Purpose == MaterialPurpose.PowerSockets)
            .Select(x => new RepairSettingModel() { ID = x.ID, Name = x.Name, Cost = x.Cost, Description = x.Description, ColorList = x.MaterialColors.Select(y => y.color.ColorName) }));
        
        /// <summary>
        /// Returns avaliable kitchen variants
        /// </summary>
        [HttpGet("/flat/kitchens")]
        [ProducesResponseType(typeof(IEnumerable<RepairSettingModel>), 200)]
        public JsonResult GetKitchenOptions() => new JsonResult(db.BaseSettings
            .Find(b => b.purpose == Purpose.Kitchen)
            .Select(x => new RepairSettingModel() { ID = x.ID, Name = x.Name, Cost = x.Cost, Description = x.Description, ColorList = x.SettingsColors.Select(y => y.color.ColorName) }));
        
        /// <summary>
        /// Returns avaliable bathroom variants
        /// </summary>
        [HttpGet("/flat/bathrooms")]
        [ProducesResponseType(typeof(IEnumerable<RepairSettingModel>), 200)]
        public JsonResult GetBathroomOptions() => new JsonResult(db.BaseSettings
           .Find(b => b.purpose == Purpose.Bathroom)
           .Select(x => new RepairSettingModel() { ID = x.ID, Name = x.Name, Cost = x.Cost, Description = x.Description, ColorList = x.SettingsColors.Select(y => y.color.ColorName) }));
        
        /// <summary>
        /// Returns avaliable additional options
        /// </summary>
        [HttpGet("/flat/additionals")]
        [ProducesResponseType(typeof(IEnumerable<AdditionalOptions>), 200)]
        public JsonResult GetAdditionalOptions() => new JsonResult(db.Additionals.GetAll());

    }
}