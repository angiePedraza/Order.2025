
using Orders.Shared.Entities;

namespace Orders.backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();

        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Jugueteria" });
                _context.Categories.Add(new Category { Name = "Tecnologia" });
                _context.Categories.Add(new Category { Name = "Hogar" });
                _context.Categories.Add(new Category { Name = "Mascotas" });
                _context.Categories.Add(new Category { Name = "COsmeticos" });
                 await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = new List<State>()
            {
                        new State()
                        {
                            Name = "Antioquia",
                            Cities = [

                                 new() { Name = "Medellin" },
                                 new() { Name = "Envigado" },
                                 new() { Name = "Itagui" },
                            ]
                        },
                        new State()
                        {
                            Name ="Bogotá",
                            Cities =
                            [
                                new() { Name = "Usaquen" },
                                new() { Name = "Soacha" },
                                new() { Name = "Chia" },
                            ]
                        },
                    }
                      });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States =
                    [
                        new State()
                        {
                            Name = "Florida",
                            Cities = new List<City>()
                            {
                                new() { Name = "Orlando" },
                                new() { Name = "Miami" },
                                new() { Name = "Key West" },
                            }
                        },
                        new State()
                        {
                            Name ="Ciudad de Texas",
                            Cities =
                            [
                                new() { Name = "Houston" },
                                new() { Name = "San Antonio" },
                                new() { Name = "Dallas" },
                            ]      
                        },
                    ]
                  });
                }
            await _context.SaveChangesAsync();
        }
      } 
   }

