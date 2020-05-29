using Airline.BLL.DTOs;
using Airline.BLL.Interfaces.IServices;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airline.BLL.Services
{
    public class FlightScheduleService : SetOfFields, IFlightScheduleService
    {
        public FlightScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public async Task AddFlightScheduleAsync(FlightScheduleDTO flightScheduleDTO)
        {
            var flightSchedule = mapper.Map<FlightSchedule>(flightScheduleDTO);

            await unitOfWork.FlightScheduleRepository.Add(flightSchedule);
        }

        public async Task DeleteFlightScheduleAsync(FlightScheduleDTO flightScheduleDTO)
        {
            var flightSchedule = await unitOfWork.FlightScheduleRepository.Get(flightScheduleDTO.Id);

            if (flightSchedule == null)
            {
                throw new Exception("Not found");
            }



            await unitOfWork.FlightScheduleRepository.Delete(flightSchedule);
        }

        public async Task<FlightScheduleDTO> GetFlightScheduleAsync(int Id)
        {
            var flightSchedule = await unitOfWork.FlightScheduleRepository.Get(Id);

            if (flightSchedule == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<FlightScheduleDTO>(flightSchedule);
        }



        public async Task<IEnumerable<FlightScheduleDTO>> GetAllFlightScheduleAsync()
        {
            var flightSchedule = await unitOfWork.FlightScheduleRepository.GetAll();

            if (flightSchedule == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<IEnumerable<FlightScheduleDTO>>(flightSchedule);
        }

        public async Task<IEnumerable<FlightScheduleDTO>> GetDateFlightSchedule(string DepartureDate)
        {
            if (DepartureDate == null)
            {
                throw new Exception("is null");
            }

            var flightSchedule = await unitOfWork.FlightScheduleRepository.GetDateFlightSchedule(DepartureDate);

            if (flightSchedule == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<IEnumerable<FlightScheduleDTO>>(flightSchedule);
        }

        public async Task UpdateFlightScheduleAsync(FlightScheduleDTO flightScheduleDTO)
        {
            var flightSchedule = mapper.Map<FlightSchedule>(flightScheduleDTO);

            await unitOfWork.FlightScheduleRepository.Update(flightSchedule);
        }


    }
}

