using CarApi.DBContexts;
using CarApi.Models;
using FluentValidation;

namespace CarApi.Validators
{
    public class CarValidator : AbstractValidator<CarModel>
    {
        private ApplicationDbContext _context;

        public CarValidator(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.OwnerName).NotEmpty().NotNull().WithMessage("Owner Name Required");
            RuleFor(x => x.LicenseNumber).NotEmpty().NotNull().WithMessage("LicenseNumber Required");
            RuleFor(x => x.HorsePower).NotEmpty().NotNull().WithMessage("HorsePower Required");
            RuleFor(m => new { m.LicenseNumber }).Must(x => !IsLicenseNumberExist(x.LicenseNumber)).WithMessage("License Number is already in use");
        }
        public bool IsLicenseNumberExist(string licenseNumber)
        {
            return _context.Cars.Where(x => x.LicenseNumber == licenseNumber).Any();
        }

    }
}
