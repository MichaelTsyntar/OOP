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
    public class FlightService : SetOfFields, IFlightService
    {
        public FlightService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public async Task AddFlightAsync(FlightDTO flightDTO)
        {
            var flight = mapper.Map<Flight>(flightDTO);

            await unitOfWork.FlightRepository.Add(flight);
        }

        public async Task DeleteFlightAsync(FlightDTO flightDTO)
        {
            var flight = await unitOfWork.FlightRepository.Get(flightDTO.Id);

            if (flight == null)
            {
                throw new Exception("Not found");
            }



            await unitOfWork.FlightRepository.Delete(flight);
        }

        public async Task<FlightDTO> GetFlightAsync(int Id)
        {
            var flight = await unitOfWork.FlightRepository.Get(Id);

            if (flight == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<FlightDTO>(flight);
        }



        public async Task<IEnumerable<FlightDTO>> GetAllFlightAsync()
        {
            var flight = await unitOfWork.FlightRepository.GetAll();

            if (flight == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<IEnumerable<FlightDTO>>(flight);
        }

        public async Task<IEnumerable<FlightDTO>> GetAirlinesFlight(string Airlines)
        {
            if (Airlines == null)
            {
                throw new Exception("is null");
            }

            var flight = await unitOfWork.FlightRepository.GetAirlinesFlight(Airlines);

            if (flight == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<IEnumerable<FlightDTO>>(flight);
        }

        public async Task UpdateFlightAsync(FlightDTO flightDTO)
        {
            var flight = mapper.Map<Flight>(flightDTO);

            await unitOfWork.FlightRepository.Update(flight);
        }


    }



}


