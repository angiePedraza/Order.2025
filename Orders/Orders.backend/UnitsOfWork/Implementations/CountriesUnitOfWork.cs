﻿using Orders.backend.Repositories.Interfaces;
using Orders.backend.UnitsOfWork.Interfaces;
using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.backend.UnitsOfWork.Implementations
{
    public class CountriesUnitOfWork : GenericUnitOfWork<Country>, ICountriesUnitOfWork
    {
        private readonly ICountriesRepository _countriesRepository;

        public CountriesUnitOfWork(IGenericRepository<Country> repository, ICountriesRepository countriesRepository) : base(repository)
        {
            _countriesRepository = countriesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync() => await _countriesRepository.GetAsync();
        

        public override async Task<ActionResponse<Country>> GetAsync(int id) =>await _countriesRepository.GetAsync(id);

    }
}
