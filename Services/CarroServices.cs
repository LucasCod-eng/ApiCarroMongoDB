using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication4.Model;

namespace WebApplication4.Services
{
    public class CarroServices
    {
        private readonly IMongoCollection<Carro> _carroCollection;

        public CarroServices(IOptions<CarroDatabaseSetting> carroServices)
        {
            var mongoClient = new MongoClient(carroServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(carroServices.Value.DatabaseName);

            _carroCollection = mongoDatabase.GetCollection<Carro>(carroServices.Value.CarroCollectionName);

        }
        //
        public async Task<List<Carro>> GetAsync()
        {
           return await _carroCollection.Find(x => true).ToListAsync();

        }

        public async Task<Carro> GetAsync(string id)
        {
             return await _carroCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        }

        public async Task CreateAsync(Carro carro)
        {
            await _carroCollection.InsertOneAsync(carro);

        }

        public async Task UpdateAsync(Carro carro, string id)
        {
               await _carroCollection.ReplaceOneAsync(y => y.Id == id, carro);

        }

        public async Task RemoveAsync(string id)
        {
             await _carroCollection.DeleteOneAsync(x => x.Id == id);

        }

    }
}