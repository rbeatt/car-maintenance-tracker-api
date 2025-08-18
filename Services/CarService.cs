using Microsoft.EntityFrameworkCore;
using CarMaintenanceTracker.Api.Models;
using CarMaintenanceTracker.Api.Data;

namespace CarMaintenanceTracker.Api.Services
{
	public class CarService : ICarService
	{
		private readonly ApplicationDbContext _context;

		public CarService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Car>> GetAllCarsAsync()
		{
			return await _context.Cars.ToListAsync();
		}

		public async Task<Car?> GetCarByIdAsync(int id)
		{
			return await _context.Cars.FindAsync(id);
		}

		public async Task<Car> AddCarAsync(Car car)
		{
			_context.Cars.Add(car);
			await _context.SaveChangesAsync();
			return car;
		}

		public async Task<bool> UpdateCarAsync(int id, Car car)
		{
			var existing = await _context.Cars.FindAsync(id);
			if (existing == null) return false;
			existing.Make = car.Make;
			existing.Model = car.Model;
			existing.Year = car.Year;
			existing.VIN = car.VIN;
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteCarAsync(int id)
		{
			var car = await _context.Cars.FindAsync(id);
			if (car == null) return false;
			_context.Cars.Remove(car);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
