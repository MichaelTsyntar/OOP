using Airline.BLL.DTOs;
using Airline.BLL.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService passengerService;

        public PassengerController(IPassengerService passengerService)
        {
            this.passengerService = passengerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassengerDTO>>> GetAll()
        {
            IEnumerable<PassengerDTO> passengerDto = await passengerService.GetAllPassengerAsync();

            if (passengerDto == null)
            {
                return NotFound();
            }

            return Ok(passengerDto);
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<ActionResult<PassengerDTO>> GetPassengerAsync(int Id)
        {
            PassengerDTO passengerDto = await passengerService.GetPassengerAsync(Id);

            if (passengerDto == null)
            {
                return NotFound();
            }

            return Ok(passengerDto);
        }
        [HttpPost]
        public async Task<ActionResult<PassengerDTO>> Add([FromBody]PassengerDTO passengerDto)
        {
            if (passengerDto == null)
            {
                return BadRequest();
            }

            await passengerService.AddPassengerAsync(passengerDto);

            return Ok(passengerDto);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<PassengerDTO>> Delete(int Id)
        {
            PassengerDTO passengerDto = await passengerService.GetPassengerAsync(Id);

            if (passengerDto == null)
            {
                return NotFound();
            }

            await passengerService.DeletePassengerAsync(passengerDto);
            return NoContent();
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<PassengerDTO>> Update(int Id,[FromBody]PassengerDTO passengerDto)
        {
            

            if (passengerDto == null)
            {
                return NotFound();
            }

            passengerDto.Id = Id;

            await passengerService.UpdatePassengerAsync(passengerDto);
            return Ok(passengerDto);
        }
    }          

}
