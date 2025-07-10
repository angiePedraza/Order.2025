using Microsoft.AspNetCore.Mvc;
using Orders.backend.UnitsOfWork.Interfaces;
using Orders.Shared.Entities;

namespace Orders.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : GenericController<City>
    {
        public CitiesController(IGenericUnitOfWork<City> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
