﻿using Application.Library.Interfaces;
using Application.Library.Interfaces.SEC.Person.Commands;
using Application.Library.Interfaces.SEC.Person.DTOs;
using AutoMapper;
using Common.Library;
using Domain.Library.Entities.SEC;
using Persistance.Library.MapperProfile;
using System;

namespace Persistance.Library.ServiceRepository.Services
{
    public class PersonUpdateService : IPersonUpdateRepository
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public PersonUpdateService(IDatabaseContext context, IMapper mapper)
        {
            var config =AutoMapperConfiguration.InitializeAutomapper();
            _context = context;
            _mapper = config;
        }
        public async Task<ResultDTO<long>> Execute(PersonDTO model)
        {
            var entity = _mapper.Map<Person>(model);
            var data = _context.People.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await Task.Delay(1000);
            return new ResultDTO<long>()
            {
                Success = true,
                Message = " با موققیت انجام شد ",
                Data = model.ID
            };
        }
    }
}
