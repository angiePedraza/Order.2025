﻿using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.backend.UnitsOfWork.Interfaces
{
    public interface IStatesUnitOfWork
    {
        Task<ActionResponse<State>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<State>>> GetAsync();
    }
}
