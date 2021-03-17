using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        IRentService _rentService;
        public RentsController(IRentService rentService)
        {
            _rentService = rentService;
        }


        [HttpGet("getallrentdetails")]
        public IActionResult GetAllRents()
        {
            Thread.Sleep(1000);
            var result = _rentService.GetAllRentDetails();
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result.Message);

        }
    }
}
