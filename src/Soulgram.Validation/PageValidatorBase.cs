using FluentValidation;
using Soulgram.Model;

namespace Soulgram.Validation
{
    public abstract class PageValidatorBase<T> : AbstractValidator<T>
     where T : PageRequestBase
    {
        protected PageValidatorBase()
        {
            RuleFor(x => x.Take).Must(arg => arg >= 0)
                .WithMessage(arg => $"{nameof(arg.Take)} must be greater than or equal to zero");

            RuleFor(x => x.Skip).Must(arg => arg >= 0)
                .WithMessage(arg => $"{nameof(arg.Skip)} must be greater than or equal to zero");
        }
    }
}
