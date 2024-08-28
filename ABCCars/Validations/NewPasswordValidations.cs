using FluentValidation;

namespace ABCCars.Validations
{
    public class NewPasswordValidations
    {
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }

        public NewPasswordValidations(string newPassword, string confirmPassword)
        {
            this.newPassword = newPassword;
            this.confirmPassword = confirmPassword;
        }
    }

    public class NewPasswordValidationsValidator : AbstractValidator<NewPasswordValidations>
    {
        public NewPasswordValidationsValidator()
        {
            RuleFor(x => x.newPassword).NotEmpty().WithMessage("New password is required");
            RuleFor(x => x.newPassword).MinimumLength(6).WithMessage("Password must be at least 6 characters long");
            RuleFor(x => x.confirmPassword).NotEmpty().WithMessage("Confirm password is required");
            RuleFor(x => x.confirmPassword).Equal(x => x.newPassword).WithMessage("Passwords do not match");
        }
    }
}
