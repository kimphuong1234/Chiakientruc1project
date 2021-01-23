using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using MISA.ApplicationCore.NewFolder;
using System.Linq;
using System.Reflection;
using MISA.ApplicationCore.Interface;
using Microsoft.Extensions.Configuration;

namespace MISA.Infrastructure.Base
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>, IDisposable
    {
        protected IConfiguration _configuration;
        protected IDbConnection _dbConnection;
        Commoned common;
        string _tableName = typeof(MISAEntity).Name;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new MySqlConnection(_configuration.GetConnectionString("MISAConnectionString"));
            common = new Commoned();
        }
        public int Add(MISAEntity entity)
        {
            var rowEffect = 0;
            _dbConnection.Open();
            using (var transection = _dbConnection.BeginTransaction())
            {
                rowEffect = _dbConnection.Execute($"Proc_Insert{_tableName}", param: common.GetParam(entity), commandType: CommandType.StoredProcedure);
                transection.Commit();
            }
            return rowEffect;
        }
        public bool CheckBySpec(MISAEntity entity, PropertyInfo property, string actionType = "add")
        {
            var sql = "";
            var spec = property.Name;
            var value = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            if (actionType == "add")
                sql = $"select * from {_tableName} where {spec} = '{value}'";
            else if (actionType == "update")
                sql = $"select * from {_tableName} where {spec} = '{value}' and {_tableName}Id <> '{keyValue}'";
            var entityCheck = _dbConnection.Query<MISAEntity>(sql).FirstOrDefault();
            return entityCheck == null ? true : false;
        }

        public int DeleteById(Guid id)
        {
            return _dbConnection.Execute($"delete from {_tableName} where {_tableName}Id = '{id.ToString()}'");
        }

        public void Dispose()
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }

        public IEnumerable<MISAEntity> Get()
        {
            return _dbConnection.Query<MISAEntity>($"select * from {_tableName}");
        }
        public IEnumerable<MISAEntity> GetById(string id)
        {
            return _dbConnection.Query<MISAEntity>($"select * from {_tableName} where {_tableName}Id= '{id}'");
        }

        public int Update(MISAEntity entiy)
        {
            return _dbConnection.Execute($"Proc_Update{_tableName}", param: common.GetParam(entiy), commandType: CommandType.StoredProcedure);
        }
    }
}
