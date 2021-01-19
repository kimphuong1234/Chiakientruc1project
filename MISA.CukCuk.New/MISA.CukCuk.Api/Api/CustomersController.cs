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
 

    public class CustomersController : EntityController<Customer>
    {
        DbConnector dbConnector = new DbConnector();
        #region method post
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// CreatedBy: ABC(11/01/2021)
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            #region các cách làm bài insert
            //Video 16                 <------------
            //var properties = customer.GetType().GetProperties();                 <------------
            //var parameters = new DynamicParameters();
            //foreach(var property in properties)
            //{
            //    var propertyName = property.Name;
            //    var propertyValue = property.GetValue(customer);
            //    var propertyType = property.PropertyType;
            //    if(propertyType == typeof(Guid))
            //    {
            //        parameters.Add($"@(propertyName)", propertyValue, DbType.String);
            //    }
            //    else
            //    {
            //        parameters.Add($"@(propertyName)", propertyValue);
            //    }
            //}

            //Video Rec 01-11-21 phút 60                 <------------
            //DynamicParameters dynamicParameters = new DynamicParameters();
            //dynamicParameters.Add("@CustomerId", customer.CustomerId.ToString());
            //dynamicParameters.Add("@CustomerCode", customer.CustomerCode);
            //dynamicParameters.Add("@FullName", customer.FullName);
            //dynamicParameters.Add("@PhoneNumber", customer.PhoneNumber);
            //dynamicParameters.Add("@Email", customer.Email);
            //dynamicParameters.Add("@CustomerGroupId", customer.CustomerGroupId.ToString());
            //Dữ liệu vào database
            //var customers = dbConnection.Execute("Proc_InsertCustomer",commandType:CommandType.StoredProcedure, param: dynamicParameters);
            //return Ok(customers);


            //Validate dữ liệu:
            //Check trùng mã:
            //var customerCode = customer.CustomerCode;
            //if (string.IsNullOrEmpty(customerCode))
            //    return BadRequest("Mã khách hàng không được phép để trống");


            //var _dbConnection = new MySqlConnection();

            //Video Rec 01-11-21 phút 30  < ------------
            //var storeparamobject = new               
            //{
            //    customerId = customer.CustomerId.ToString(),
            //    customercode = customer.CustomerCode,
            //    fullname = customer.FullName,
            //    phonenumber = customer.PhoneNumber,
            //    email = customer.Email,
            //    customergroupid = customer.CustomerGroupId.ToString()
            //};

            ////Video Rec 01-11-21 1 giờ 20                 <------------
            //DynamicParameters dynamicParameters = new DynamicParameters();
            //var properties = customer.GetType().GetProperties();
            //foreach (var property in properties)
            //{
            //    var propertyName = property.Name;
            //    var propertyValue = property.GetValue(customer);
            //    if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
            //    {
            //        propertyValue = propertyValue.ToString();
            //    }

            //    dynamicParameters.Add($"@{propertyName}", propertyValue);
            //}


            ////Dữ liệu vào database
            //var customers = _dbConnection.Execute("Proc_InsertCustomer", commandType: CommandType.StoredProcedure, param: dynamicParameters);
            //return Ok(customers);
            #endregion

            var result = dbConnector.Insert<Customer>(customer);
            return Ok(result);
        }
        #endregion
        
        #region method put
        [HttpPut]
        public IActionResult Put([FromBody] Customer customer)
        {
            var result = dbConnector.Put<Customer>(customer);
            return Ok(result);
        }
        #endregion
    }
}