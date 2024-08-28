using FluentValidation;

// This class is used to validate the reset password form
namespace ABCCars.Validations
{
    public class ResetPasswordValidations
    {
        // ======================== set the email ======================
        public string Email { get; set; }
        // =============================================================

        // ================== Initialize the email =====================
        public ResetPasswordValidations(string email)
        {
            Email = email;
        }
        // =============================================================
    }

    // ========================= Validate the reset password fields ============================
    public class ResetPasswordValidationsValidator : AbstractValidator<ResetPasswordValidations>
    {
        public ResetPasswordValidationsValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address");
        }
    }
    // ==========================================================================================

}
