using System.Threading.Tasks;

namespace Test.Application
{
    public class ApplicationCreator : IApplicationCreator
    {
        private readonly IRepository _repository;

        public ApplicationCreator(
            IRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateBuyer(
            string name)
        {
            await _repository.AddBuyer(
                name);
        }
    }
}