using Airline.BLL.DTOs;
using Airline.BLL.Interfaces.IServices;
using Airline.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService flightService;

        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightService>>> GetAll()
        {
            IEnumerable<FlightDTO> flightDto = await flightService.GetAllFlightAsync();

            if (flightDto == null)
            {
                return NotFound();
            }

            return Ok(flightDto);
        }
        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("{Id}")]
        [HttpGet]
        public async Task<ActionResult<FlightDTO>> GetFlightAsync(int Id)
        {
            FlightDTO flightDto = await flightService.GetFlightAsync(Id);

            if (flightDto == null)
            {
                return NotFound();
            }

            return Ok(flightDto);
        }
        /// <summary>
        /// Create flight
        /// </summary>
        /// <param name="flightDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<FlightDTO>> Add([FromBody]FlightDTO flightDto)
        {
            if (flightDto == null)
            {
                return BadRequest();
            }

            await flightService.AddFlightAsync(flightDto);

            return Ok(flightDto);
        }
        /// <summary>
        /// Delete by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<ActionResult<FlightDTO>> Delete(int Id)
        {
            FlightDTO flightDto = await flightService.GetFlightAsync(Id);

            if (flightDto == null)
            {
                return NotFound();
            }

            await flightService.DeleteFlightAsync(flightDto);
            return NoContent();
        }
        /// <summary>
        /// Update by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="flightDto"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<ActionResult<FlightDTO>> Update(int Id, [FromBody]FlightDTO flightDto)
        {


            if (flightDto == null)
            {
                return NotFound();
            }

            flightDto.Id = Id;

            await flightService.UpdateFlightAsync(flightDto);
            return Ok(flightDto);
        }
    }
}
