using System.Threading.Tasks;

namespace Test.Application
{
    public interface IRepository
    {
        Task AddBuyer(string name);
        Task AddSale();
        Task AddProduct();
    }
}