using CarApi.Models;
using FluentValidation.Results;

namespace CarApi.Services
{
    public interface ICarService
    {
        List<CarModel> GetAllCars();
        void CreateCar(CarModel car);
        void UpdateCar(CarModel model);
        CarModel GetCarByLicenseNumber(string licenseNumber);
        void DeleteCar(CarModel model);
        bool ExistingCar(string licenseNumber);
        List<string> ValidateCar(CarModel model);
    }
}
