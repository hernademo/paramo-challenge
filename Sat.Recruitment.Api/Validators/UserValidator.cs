using FluentValidation;
using Sat.Recruitment.Api.Models.Request;

namespace Sat.Recruitment.Api.Validators
{
    public class UserValidator : AbstractValidator<UserRequest>
    {
        public  UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
        }
    }
}
