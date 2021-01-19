using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public abstract class EntityController<MISAEntity> : ControllerBase
    {
        DbConnector dbConnector = new DbConnector();
        [HttpGet]
        public IEnumerable<MISAEntity> Get()
        {
            var customers = dbConnector.Get<MISAEntity>();
            return customers;
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var customer = dbConnector.GetById<MISAEntity>(id);
            //Trả dữ liệu cho Client:
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = dbConnector.Delete<MISAEntity>(id);
            return Ok(result);
        }
    }
}

