using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts.V1;
using WebAPI.Data.Entities;

namespace WebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private List<Office> offices;
        public OfficeController()
        {
            offices = new List<Office>();
            for (int i = 0; i < 5; i++)
            {
                offices.Add(new Office { Id = Guid.NewGuid(), Name = "office"+i } );
            }
        }

        [HttpGet(ApiRoutes.Offices.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(offices);
        }
    }
}
