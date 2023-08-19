using MongoDB.Driver;
using sampleWebAPI.src.Models;

namespace sampleWebAPI.src.Repository;
public class VehicleRepository : IVehicleRepository
{
    private IMongoCollection<VehicleModel> _collection;

    public VehicleRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<VehicleModel>("Vehicle");
    }

    public async Task AddVehicleAsync(VehicleDto vehicle)
    {
        var vehicleModel = new VehicleModel()
        {
            Battery = vehicle.Battery,
            Health = vehicle.Health,
            Id = vehicle.Guid,
            Location = vehicle.Location,
            Number = vehicle.Number,
        };
        await _collection.InsertOneAsync(vehicleModel);
    }

    public async Task<IEnumerable<VehicleDto>> GetAllVehicleAsync()
    {
        List<VehicleModel> vehicles;
        try
        {
            vehicles = await _collection.Find(Builders<VehicleModel>.Filter.Empty).ToListAsync<VehicleModel>();
        }
        catch (Exception)
        {
            throw;
        }
        return vehicles.Select(vehicle => vehicle.AsDto());
    }

    public async Task<VehicleDto> GetVehicleAsync(string number)
    {
        List<VehicleModel> vehicles;
        try
        {
            FilterDefinition<VehicleModel> filter = Builders<VehicleModel>.Filter.Where(vehicle => vehicle.Number == number);
            vehicles = await _collection.Find(Builders<VehicleModel>.Filter.Empty).ToListAsync<VehicleModel>();
        }
        catch (Exception)
        {
            throw;
        }
        return vehicles.First().AsDto();
    }

    public async Task UpdateVechicleAsync(Guid guid, VehicleDto vehicle)
    {
        if (vehicle == null)
        {
            throw new ArgumentNullException(nameof(vehicle));
        }

        FilterDefinition<VehicleModel> filter = Builders<VehicleModel>.Filter.Eq(v => v.Id, vehicle.Guid);
        var vehicleMpodel = new VehicleModel()
        {
            Battery = vehicle.Battery,
            Health = vehicle.Health,
            Id = vehicle.Guid,
            Location = vehicle.Location,
            Number = vehicle.Number,
        };
        await _collection.ReplaceOneAsync(filter, vehicleMpodel);
    }

    public async Task DeleteVechicleAsync(Guid guid)
    {
        FilterDefinition<VehicleModel> filter = Builders<VehicleModel>.Filter.Eq(v => v.Id, guid);
        await _collection.DeleteOneAsync(filter);
    }

}

