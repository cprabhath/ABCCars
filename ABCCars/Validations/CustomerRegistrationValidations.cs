using FluentValidation;
using System.Linq;

namespace ABCCars.Validations
{
    public class CustomerRegistrationValidations
    {
        public string fullName { get; set; }
        public string email { get; set; }
        public string mobileNumber { get; set; }
        public string address { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }


        public CustomerRegistrationValidations(string fullName, string email, string mobileNumber, string address, string password, string confirmPassword)
        {
            this.fullName = fullName;
            this.email = email;
            this.mobileNumber = mobileNumber;
            this.address = address;
            this.password = password;
            this.confirmPassword = confirmPassword;
        }

        internal class CustomerRegistrationValidator : AbstractValidator<CustomerRegistrationValidations>
        {
            public CustomerRegistrationValidator()
            {
                RuleFor(x => x.fullName).NotEmpty().WithMessage("Full Name is required");
                RuleFor(x => x.email).NotEmpty().EmailAddress().WithMessage("Invalid email address");
                RuleFor(x => x.mobileNumber).NotEmpty().Custom((mobileNumber, context) =>
                {
                    if (!int.TryParse(mobileNumber, out _))
                    {
                        context.AddFailure("Mobile number must be number");
                        return;
                    }   
                    if (mobileNumber.Length != 10)
                    {
                        context.AddFailure("Mobile number must be 10 digits");
                    }
                    
                });
                RuleFor(x => x.address).NotEmpty().Length(5, 200).WithMessage("Address must be between 5 and 200 characters");
                RuleFor(x => x.password).NotEmpty().Length(6, 20).Custom((password, context) =>
                {
                    if (!password.Any(char.IsDigit))
                    {
                        context.AddFailure("Password must contain at least one digit");
                    }
                    if (!password.Any(char.IsUpper))
                    {
                        context.AddFailure("Password must contain at least one uppercase letter");
                    }
                    if (!password.Any(char.IsLower))
                    {
                        context.AddFailure("Password must contain at least one lowercase letter");
                    }
                });
                RuleFor(x => x.confirmPassword).NotEmpty().Length(6, 20).WithMessage("Confirm Password is required");
                RuleFor(x => x.confirmPassword).Equal(x => x.password).WithMessage("Passwords do not match");
            }
        }
    }
}
