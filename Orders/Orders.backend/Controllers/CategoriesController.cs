using Microsoft.AspNetCore.Mvc;
using Orders.backend.UnitsOfWork.Interfaces;
using Orders.Shared.Entities;

namespace Orders.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : GenericController<Category>
    {
        public CategoriesController(IGenericUnitOfWork<Category> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
