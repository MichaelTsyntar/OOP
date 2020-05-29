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
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Create passenger
        /// </summary>
        /// <param name="passengerDto"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Delete by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Update by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="passengerDto"></param>
        /// <returns></returns>
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
