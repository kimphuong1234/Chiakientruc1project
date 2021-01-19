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

    public class CustomerGroupsController : EntityController<CustomerGroup>
    {
        DbConnector dbConnector = new DbConnector();
        #region method post
        /// <summary>
        /// Thêm mới nhóm khách hàng
        /// </summary>
        /// <param name="customerGroup"></param>
        /// <returns></returns>
        /// CreatedBy: ABC(11/01/2021)
        [HttpPost]
        public IActionResult Post([FromBody] CustomerGroup customerGroup)
        {

            var result = dbConnector.Insert<CustomerGroup>(customerGroup);
            return Ok(result);
        }
        #endregion

        #region method put
        [HttpPut]
        public IActionResult Put([FromBody] CustomerGroup customerGroup)
        {
            var result = dbConnector.Put<CustomerGroup>(customerGroup);
            return Ok(result);
        }
        #endregion
    }
}
