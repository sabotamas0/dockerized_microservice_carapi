using CarApi.DBContexts;
using CarApi.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using CarApi.Validators;
using CarApi.Helpers;

namespace CarApi.Services
{
    public class CarService : ICarService
    {
        private ApplicationDbContext _context;

        public CarService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public void CreateCar(CarModel model)
        {
            _context.Cars.Add(model);
            _context.SaveChanges();
        }

        public void DeleteCar(CarModel model)
        {
            _context.Cars.Remove(model);
            _context.SaveChanges();
        }

        public bool ExistingCar(string licenseNumber)
        {
            return _context.Cars.Where(x => x.LicenseNumber == licenseNumber).Any();
        }

        public List<CarModel> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public CarModel GetCarByLicenseNumber(string licenseNumber)
        {
            if(_context.Cars.Where(x => x.LicenseNumber == licenseNumber).Any())
            {
                return _context.Cars.Where(x => x.LicenseNumber == licenseNumber).Single();
            }
            return null;
        }

        public void UpdateCar(CarModel model)
        {
            _context.Cars.Update(model);
            _context.SaveChanges();
        }

        public List<string> ValidateCar(CarModel model)
        {
            var carValidator = new CarValidator(_context);
            ValidationResult result = carValidator.Validate(model);
            return ErrorHelper.GetErrorNames(result.Errors);
        }
    }
}
