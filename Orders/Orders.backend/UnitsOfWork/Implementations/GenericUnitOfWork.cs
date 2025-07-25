﻿using Orders.backend.Repositories.Interfaces;
using Orders.backend.UnitsOfWork.Interfaces;
using Orders.Shared.DTOs;
using Orders.Shared.Responses;

namespace Orders.backend.UnitsOfWork.Implementations
{
    public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericUnitOfWork(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual async Task<ActionResponse<T>> AddAsync (T model) => await _repository.AddAsync(model);
        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination) => await _repository.GetAsync(pagination);

        public virtual async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _repository.GetTotalPagesAsync(pagination);


        public virtual async Task<ActionResponse<T>> DeleteAsync(int id) => await _repository.DeleteAsync(id);
        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync() => await _repository.GetAsync();
        public virtual async Task<ActionResponse<T>> GetAsync(int id) => await _repository.GetAsync(id);
        public virtual async Task<ActionResponse<T>> UpdateAsync(T model) => await _repository.UpdateAsync(model);

    }
}
