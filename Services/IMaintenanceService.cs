using CarMaintenanceTracker.Api.Models;

namespace CarMaintenanceTracker.Api.Services
{
    public interface IMaintenanceService
    {
        Task<IEnumerable<MaintenanceRecord>> GetMaintenanceRecordsAsync(int carId);
        Task<MaintenanceRecord> AddMaintenanceRecordAsync(int carId, MaintenanceRecord record);
        Task<bool> UpdateMaintenanceRecordAsync(int id, MaintenanceRecord record);
        Task<bool> DeleteMaintenanceRecordAsync(int id);
    }
}
