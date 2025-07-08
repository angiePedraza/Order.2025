using Microsoft.EntityFrameworkCore;
using Orders.backend.Data;
using Orders.backend.Repositories.Interfaces;
using Orders.Shared.Responses;

namespace Orders.backend.Repositories.Implemetations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entity;


        public GenericRepository(DataContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<ActionResponse<T>> AddAsync(T entity)
        {
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse(entity);
            }
            catch (Exception ex)
            {
                return ExceptionActionResponse(ex);
            }
            
        }

        
        public async Task<ActionResponse<T>> DeleteAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if(row == null)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = "Registro no encontrado"
                };
            }
            try
            {
                _entity.Remove(row);
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true
                };
            }
            catch
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = "No se puedo eliminar, porque tiene registroes relacionados"
                };
            }
        }

        public async Task<ActionResponse<T>> GetAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = "Registro no encontrado"
                };
            }
            return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = row
            };
        }

        public async Task<ActionResponse<IEnumerable<T>>> GetAsync()
        {
            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = await _entity.ToListAsync()
            };
        }

        public async Task<ActionResponse<T>> UpdateAsync(T entity)
        {
            _context.Update(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse(entity);
            }
            catch (Exception ex)
            {
                return ExceptionActionResponse(ex);
            }
        }
        private ActionResponse<T> DbUpdateExceptionActionResponse(T entity)
        {
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = "Ya existe el registro que estas intentando crear."
            };
        }
        private ActionResponse<T> ExceptionActionResponse(Exception ex)
        {
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }

    }
}
