using Dapper;
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
    public class DbConnector
    {
        #region Declare Kết nối Dtbs 
        //Khai báo thông tin kết nối tới Database 
        string _connetionString = "Host=103.124.92.43; " +
            "Port=3306; " +
            "Database=MISACukCuk_MF663_DMGIANG; " +
            "User Id=nvmanh; " +
            "Password=12345678"; //1 field. Các field mặc định là private. Class không khai báo public mặc định là internal
        //Khởi tạo đối tượng kết nối
        IDbConnection _dbConnection; //1 field  dbconnection là 1 interface phải kết nối(reference) đến 1 object nào đó đã đc khởi tạo để thực thi interface ấy
                                     //Tên của cái field private phải có gạch chân đằng trc
        #endregion

        #region constructor khởi tạo hàm kn
        //hàm khởi tạo tên phải TRÙNG VS TÊN CLASS
        public DbConnector()
        {
            _dbConnection = new MySqlConnection(_connetionString);
        }
        #endregion

        #region method
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MISAEntity> Get<MISAEntity>()
        {
            string tableName = typeof(MISAEntity).Name;
            //Dữ liệu từ database
            var customers = _dbConnection.Query<MISAEntity>($"SELECT * FROM {tableName}");
            //Trả dữ liệu cho Client:
            return customers;
        }
        #endregion

        #region method
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MISAEntity> GetById<MISAEntity>(string id)
        {
            string table = typeof(MISAEntity).Name;
            //dữ liệu từ database
            var entity = _dbConnection.Query<MISAEntity>($"select * from {table} where {table}Id='{id}'");
            //trả dữ liệu cho client:
            return entity;
        }

        #endregion
        public int Delete<MISAEntity>(string id)
        {
            string table = typeof(MISAEntity).Name;
            //Dữ liệu vào database
            var recordAffects = _dbConnection.Execute($"DELETE from {table} where {table}Id='{id}' LIMIT 1");
            return recordAffects;
        }

        public int Insert<MISAEntity>(MISAEntity entity)
        {
            
            //Video Rec 01-11-21 1 giờ 20                 <------------
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                {
                    propertyValue = propertyValue.ToString();
                }

                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }

            string tableName = typeof(MISAEntity).Name;
            //Dữ liệu vào database
            var recordAffects = _dbConnection.Execute($"Proc_Insert{tableName}", commandType: CommandType.StoredProcedure, param: dynamicParameters);
            return recordAffects;
        }

        public int Put<MISAEntity>(MISAEntity entity)
        {

            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                {
                    propertyValue = propertyValue.ToString();
                }

                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }

            string tableName = typeof(MISAEntity).Name;
            //Dữ liệu vào database
            var recordAffects = _dbConnection.Execute($"Proc_Update{tableName}", commandType: CommandType.StoredProcedure, param: dynamicParameters);
            return recordAffects;
        }

        
    }
}
