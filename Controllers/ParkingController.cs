using CarPark.API.ApplicationContext;
using CarPark.API.DTO;
using CarPark.API.Helper;
using CarPark.API.IServices;
using CarPark.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarPark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
       
        private readonly ICarPArk _carPArk;

        public ParkingController( ICarPArk carPArk)
        {
            _carPArk = carPArk;
        }


        [HttpGet("GetTicketsByDate")]
        public async Task<IActionResult> GetTicketsByDate(DateTime date)
        {

            var response = await _carPArk.GetTicketsByDate(date);


            return StatusCode((int)response.StatusCode, response);
        }


        [HttpPost("CalculateTicketCost")]
        public async Task<IActionResult> CalculateTicketCost([FromBody] CalculateTicketRequest calculateTicketRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var response = await _carPArk.CalculateTicketCost(calculateTicketRequest);

            return StatusCode((int)response.StatusCode, response);

        }

    }
}
