using System;
using System.Collections.Generic;
using System.Text;
using MISA.ApplicationCore.Interface;
using MISA.ApplicationCore.Model;

namespace MISA.ApplicationCore.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IBaseRepository<Employee> baseRepository, IEmployeeRepository employeeRepository) : base(baseRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<Employee> GetEmployeeByCode(string code)
        {
            return _employeeRepository.GetEmployeeByCode(code);
        }

    }
}
