using Airline.DAL.Interfaces;
using Airline.DAL.Interfaces.IEntityRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IFlightScheduleRepository _flightScheduleRepository;
        private readonly IFlightRepository _flightRepository;

        public UnitOfWork(
            IPassengerRepository passengerRepository,
            IFlightScheduleRepository flightScheduleRepository,
            IFlightRepository flightRepository
            )
           
        {
            _passengerRepository = passengerRepository;
            _flightScheduleRepository = flightScheduleRepository;
            _flightRepository = flightRepository;
        }

        public IPassengerRepository PassengerRepository
        {
            get
            {
                return _passengerRepository;
            }
        }

       

        public IFlightScheduleRepository FlightScheduleRepository
        {
            get
            {
                return _flightScheduleRepository;
            }
        }


        public IFlightRepository FlightRepository
        {
            get
            {
                return _flightRepository;
            }
        }
    }
    }
