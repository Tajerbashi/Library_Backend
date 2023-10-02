﻿using Application.Library.Interfaces;
using Application.Library.Interfaces.SEC.Person.Commands;
using Application.Library.Interfaces.SEC.Person.DTOs;
using AutoMapper;
using Common.Library;
using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;
using Persistance.Library.MapperProfile;

namespace Persistance.Library.ServiceRepository.Services
{
    public class PersonChangeService : IPersonChangeRepository
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public PersonChangeService(IDatabaseContext context, IMapper mapper)
        {
            //var config =AutoMapperConfiguration.InitializeAutomapper();
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResultDTO<long>> Execute(PersonDTO model)
        {
            var entity = _mapper.Map<Person>(model);
            var data = _context.People.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return RequestResult<long>.Ok(model.ID);
        }
    }
}