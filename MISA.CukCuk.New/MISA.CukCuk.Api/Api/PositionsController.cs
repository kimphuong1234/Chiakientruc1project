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
    public class PositionsController : EntityController<Position>
    {
        IBaseServices<Position> _baseServices;
        public PositionsController(IBaseServices<Position> baseServices) : base(baseServices)
        {
            _baseServices = baseServices;
        }
    }
}
