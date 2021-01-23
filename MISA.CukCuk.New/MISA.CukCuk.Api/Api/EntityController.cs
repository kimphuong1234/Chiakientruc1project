using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interface;
using MISA.Infrastructure;
using MISA.Infrastructure.Base;
using MISA.ApplicationCore.Services;

namespace MISA.CukCuk.Api.Api
{
    [Route("api/v1/[controller]")]

    [ApiController]
    public class EntityController<MISAEntity> : ControllerBase
    {
        IBaseServices<MISAEntity> _baseServices;
        public EntityController(IBaseServices<MISAEntity> baseServices)
        {
            _baseServices = baseServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_baseServices.GET());
        }
        [HttpGet("id")]
        public IActionResult GetById(string id)
        {
            return Ok(_baseServices.GetById(id));
        }
        [HttpPost]
        public IActionResult Insert([FromBody] MISAEntity entity)
        {
            return Ok(_baseServices.Add(entity));
        }
        [HttpPut]
        public IActionResult Update(MISAEntity entity)
        {
            return Ok(_baseServices.Update(entity));
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            return Ok(_baseServices.Delete(id));
        }
    }
}
