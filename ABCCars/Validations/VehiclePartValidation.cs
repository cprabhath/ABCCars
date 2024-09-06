using FluentValidation;
using System.Drawing;

namespace ABCCars.Validations
{
    public class VehiclePartValidation
    {
        public string id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string Price { get; set; }
        public string qty { get; set; }

        public VehiclePartValidation(string id, string Image, string Name, string Description, string Condition, string Price, string qty)
        {
            this.id = id;
            this.Image = Image;
            this.Name = Name;
            this.Description = Description;
            this.Condition = Condition;
            this.Price = Price;
            this.qty = qty;
        }
    }

    public class VehiclePartValidationValidator : AbstractValidator<VehiclePartValidation>
    {
        public VehiclePartValidationValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("ID is required.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.Condition).NotEmpty().WithMessage("Condition is required.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.");
            RuleFor(x => x.Price).Must(x => int.TryParse(x, out int _)).WithMessage("Price must be a number.");
            RuleFor(x => x.qty).NotEmpty().WithMessage("Quantity is required.");
            RuleFor(x => x.qty).Must(x => int.TryParse(x, out int _)).WithMessage("Quantity must be a number.");
        }
    }
}
