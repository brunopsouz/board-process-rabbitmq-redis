using ComponentConsumption.Infrastructure.DataAccess;
using ComponentConsumption.Model.Models;
using ComponentConsumption.Model.Repositories;
using Dapper;
using System.Data;

namespace ComponentConsumption.Infrastructure.Repositories
{
    public class ComponentConsumptionRepository(DatabaseFactory factory) : IComponentConsumptionRepository
    {
        private readonly IDbConnection _connection = factory.CreateConnection();

        public async Task<IEnumerable<ComponentConsumptionModel>> GetConsumedComponentsAsync(int lastId)
        {
            var models = await _connection.QueryAsync<ComponentConsumptionModel>(
                "udpGetPendingConsumption",
                new { LastConsumedId = lastId },
                commandType: CommandType.StoredProcedure
                );

            return models;
        }

    }
}
