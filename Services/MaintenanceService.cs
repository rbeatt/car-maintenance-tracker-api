using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarMaintenanceTracker.Api.Models;
using CarMaintenanceTracker.Api.Data;

namespace CarMaintenanceTracker.Api.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly ApplicationDbContext _context;

        public MaintenanceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaintenanceRecord>> GetMaintenanceRecordsAsync(int carId)
        {
            return await _context.MaintenanceRecords
                .Where(r => r.CarId == carId)
                .ToListAsync();
        }

        public async Task<MaintenanceRecord> AddMaintenanceRecordAsync(int carId, MaintenanceRecord record)
        {
            record.CarId = carId;
            _context.MaintenanceRecords.Add(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<bool> UpdateMaintenanceRecordAsync(int id, MaintenanceRecord record)
        {
            var existing = await _context.MaintenanceRecords.FindAsync(id);
            if (existing == null) return false;
            existing.ServiceType = record.ServiceType;
            existing.ServiceDate = record.ServiceDate;
            existing.Mileage = record.Mileage;
            existing.Notes = record.Notes;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMaintenanceRecordAsync(int id)
        {
            var record = await _context.MaintenanceRecords.FindAsync(id);
            if (record == null) return false;
            _context.MaintenanceRecords.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
