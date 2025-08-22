
using ComponentConsumption.Model.Repositories;

namespace ComponentConsumption.Application.Service
{
    public class GetComponentConsumption : IGetComponentConsumption
    {


        public GetComponentConsumption(
            IComponentConsumptionRepository repository
            )
        {
            
        }

        public Task RunAsync()
        {
            throw new NotImplementedException();
        }
    }
}
