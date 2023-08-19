namespace sampleWebAPI.src.Repository
{
    public interface IVehicleRepository
    {
        Task AddVehicleAsync(VehicleDto vehicle);
        Task<IEnumerable<VehicleDto>> GetAllVehicleAsync();
        Task<VehicleDto> GetVehicleAsync(string number);
        Task UpdateVechicleAsync(Guid guid, VehicleDto vehicle);
        Task DeleteVechicleAsync(Guid guid);
    }
}