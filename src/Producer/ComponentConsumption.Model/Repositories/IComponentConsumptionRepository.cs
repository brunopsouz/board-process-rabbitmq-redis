using ComponentConsumption.Model.Models;

namespace ComponentConsumption.Model.Repositories
{
    public interface IComponentConsumptionRepository
    {
        Task<IEnumerable<ComponentConsumptionModel>> GetConsumedComponentsAsync(int lastId);
    }
}
