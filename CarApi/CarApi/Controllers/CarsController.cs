using CarApi.Dtos;
using CarApi.Helpers;
using CarApi.Models;
using CarApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAllCars()
        {
            var cars = _carService.GetAllCars();
            if(cars.Any())
            {
                return Ok(cars);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("getByLicense")]
        public IActionResult GetCarByLicenseNumber(string licenseNumber) 
        {
            var car = _carService.GetCarByLicenseNumber(licenseNumber);
            if(car != null)
            {
                return Ok(car);
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateCar(CarDto car, string licenseNumber)
        {
            var carToBeUpdated = _carService.GetCarByLicenseNumber(licenseNumber);

            if (carToBeUpdated != null)
            {
                if(!string.IsNullOrEmpty(car.HorsePower))
                {
                    carToBeUpdated.HorsePower = car.HorsePower;
                }
                if (!string.IsNullOrEmpty(car.OwnerName))
                {
                    carToBeUpdated.OwnerName = car.OwnerName;
                }
                if (!string.IsNullOrEmpty(car.LicenseNumber))
                {
                    if(!_carService.ExistingCar(car.LicenseNumber))
                    {
                        carToBeUpdated.LicenseNumber = car.LicenseNumber;
                    }
                }
                
                _carService.UpdateCar(carToBeUpdated);
                return Ok("Car has been updated");
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public IActionResult CreateCar(CarModel car)
        {
            var errors = _carService.ValidateCar(car);
           
            if (!errors.Any())
            {
                _carService.CreateCar(car);
                return Ok();
            }
            return BadRequest(errors);
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteCar(string licenseNumber)
        {
            var car = _carService.GetCarByLicenseNumber(licenseNumber);

            if (car != null)
            {
                _carService.DeleteCar(car);
                return Ok("Car has been deleted!");
            }
            return BadRequest();
        }
    }
}
