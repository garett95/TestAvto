using System.Threading.Tasks;
using Test.Application;
using Test.Database;
using Test.Models;

namespace Test.Infrastructure
{
    public class Repository : IRepository
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddBuyer(
            string name)
        {
            var buyerDto = new BuyerDto
            {
                Name = name
            };
            await _context.Buyers.AddAsync(buyerDto);
            await _context.SaveChangesAsync();
        }

        public Task AddSale()
        {
            throw new System.NotImplementedException();
        }

        public Task AddProduct()
        {
            throw new System.NotImplementedException();
        }
    }
}