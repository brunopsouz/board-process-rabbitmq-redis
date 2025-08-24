using ComponentConsumption.Model.Models;
using System.ComponentModel;

namespace ComponentConsumption.Model.Repositories
{
    public interface IComponentConsumptionRepository
    {
        Task<IEnumerable<ComponentConsumptionModel>> GetConsumedComponentsAsync(int lastId);
        //Task GetConsumedComponentsAsync();
    }
}
