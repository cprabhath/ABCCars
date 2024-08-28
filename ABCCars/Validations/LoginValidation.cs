using FluentValidation;
using System;

// This class is used to validate the login form
namespace ABCCars.Validations
{
    internal class LoginValidation
    {
        // ======================== set the username and password ======================
        public String Username { get; set; }
        public String Password { get; set; }
        // =============================================================================

        // ================== Initialize the username and password =====================
        public LoginValidation(String username, String password)
        {
            Username = username;
            Password = password;
        }
        //  ============================================================================
    }

    // ========================= Validate the login fields =============================
    internal class LoginValidationValidator : AbstractValidator<LoginValidation>
    {
        public LoginValidationValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
    // ================================================================================
}
