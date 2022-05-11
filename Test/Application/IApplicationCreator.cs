using System.Threading.Tasks;

namespace Test.Application
{
    public interface IApplicationCreator
    {
        Task CreateBuyer(string name);
    }
}