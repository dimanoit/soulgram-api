using FluentValidation;
using Soulgram.UserInfo.Models;

namespace Soulgram.UserInfo.Validation
{
    internal class UserRequestValidator : AbstractValidator<User>
    {
        // TODO add more rules
        public UserRequestValidator()
        {
            RuleFor(x => x).Must(x => x != null);

            RuleFor(x => x.Login)
                .MinimumLength(5)
                .MaximumLength(30);

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .MaximumLength(20);

        }
    }
}