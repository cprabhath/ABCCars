using FluentValidation;
using System.Drawing;

namespace ABCCars.Validations
{
    public class VehicleValidation
    {
        public string carID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public string qty { get; set; }

        public VehicleValidation(string carID, string Name, string Model, string Description, string Condition, string Price, string Image, string qty)
        {
            this.carID = carID;
            this.Name = Name;
            this.Model = Model;
            this.Description = Description;
            this.Condition = Condition;
            this.Price = Price;
            this.Image = Image;
            this.qty = qty;
        }
    }

    public class VehicleValidationValidator : AbstractValidator<VehicleValidation>
    {
        public VehicleValidationValidator()
        {
            RuleFor(x => x.carID).NotEmpty().WithMessage("Car ID is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.Condition).NotEmpty().WithMessage("Condition is required.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.");
            RuleFor(x => x.Price).Must(x => int.TryParse(x, out int _)).WithMessage("Price must be a number.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image is required.");
            RuleFor(x => x.qty).NotEmpty().WithMessage("Quantity is required.");
            RuleFor(x => x.qty).Must(x => int.TryParse(x, out int _)).WithMessage("Quantity must be a number.");
        }
    }
}
