using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interface;
using MISA.ApplicationCore.Model;
using MISA.Infrastructure.Base;
using Dapper;
namespace MISA.Infrastructure
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public IEnumerable<Employee> GetEmployeeByCode(string code)
        {
            return _dbConnection.Query<Employee>($"select * from Employee where EmployeeCode = '{code}'");
        }
    }
}
