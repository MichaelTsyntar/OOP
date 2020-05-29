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
    public class FlightScheduleController : ControllerBase
    {
        private readonly IFlightScheduleService flightScheduleService;

        public FlightScheduleController(IFlightScheduleService flightScheduleService)
        {
            this.flightScheduleService = flightScheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightScheduleService>>> GetAll()
        {
            IEnumerable<FlightScheduleDTO> flightScheduleDto = await flightScheduleService.GetAllFlightScheduleAsync();

            if (flightScheduleDto == null)
            {
                return NotFound();
            }

            return Ok(flightScheduleDto);
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<ActionResult<FlightScheduleDTO>> GetFlightScheduleAsync(int Id)
        {
            FlightScheduleDTO flightScheduleDto = await flightScheduleService.GetFlightScheduleAsync(Id);

            if (flightScheduleDto == null)
            {
                return NotFound();
            }

            return Ok(flightScheduleDto);
        }
        [HttpPost]
        public async Task<ActionResult<FlightScheduleDTO>> Add([FromBody]FlightScheduleDTO flightScheduleDto)
        {
            if (flightScheduleDto == null)
            {
                return BadRequest();
            }

            await flightScheduleService.AddFlightScheduleAsync(flightScheduleDto);

            return Ok(flightScheduleDto);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<FlightScheduleDTO>> Delete(int Id)
        {
            FlightScheduleDTO flightScheduleDto = await flightScheduleService.GetFlightScheduleAsync(Id);

            if (flightScheduleDto == null)
            {
                return NotFound();
            }

            await flightScheduleService.DeleteFlightScheduleAsync(flightScheduleDto);
            return NoContent();
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<FlightScheduleDTO>> Update(int Id, [FromBody]FlightScheduleDTO flightScheduleDto)
        {


            if (flightScheduleDto == null)
            {
                return NotFound();
            }

            flightScheduleDto.Id = Id;

            await flightScheduleService.UpdateFlightScheduleAsync(flightScheduleDto);
            return Ok(flightScheduleDto);
        }
    }
}
