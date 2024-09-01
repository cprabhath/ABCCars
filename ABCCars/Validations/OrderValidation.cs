using FluentValidation;

namespace ABCCars.Validations
{
    public class OrderValidation
    {
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public string PartID { get; set; }
        public string VehicleID { get; set; }
        public string Total { get; set; }

        public OrderValidation(string OrderID, string CustomerID, string PartID, string VehicleID, string Total)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.PartID = PartID;
            this.VehicleID = VehicleID;
            this.Total = Total;
        }
    }

    public class OrderValidationValidator : AbstractValidator<OrderValidation>
    {
        public OrderValidationValidator()
        {
            RuleFor(x => x.OrderID).NotEmpty().WithMessage("Order ID is required.");
            RuleFor(x => x.CustomerID).NotEmpty().WithMessage("Customer ID is required.");
            RuleFor(x => x.PartID).NotEmpty().WithMessage("Part ID is required.");
            RuleFor(x => x.VehicleID).NotEmpty().WithMessage("Vehicle ID is required.");
            RuleFor(x => x.Total).NotEmpty().WithMessage("Total is required.");
        }
    }
}
