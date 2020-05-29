using Airline.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.BLL.Services
{
    public abstract class SetOfFields
    {
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;
        protected SetOfFields(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
    }
