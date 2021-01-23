using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interface;
using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    
    public class DepartmentsController : EntityController<Department>
    {
        IBaseServices<Department> _baseServices;
        public DepartmentsController(IBaseServices<Department> baseServices) : base(baseServices)
        {
            _baseServices = baseServices;
        }
    }
}
