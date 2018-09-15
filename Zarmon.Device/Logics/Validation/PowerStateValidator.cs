using FluentValidation;

namespace Zarmon.Device.Logics.Validation
{
    public class PowerStateValidator : AbstractValidator<bool>
    {
        public PowerStateValidator(bool expectedValue)
        {
            RuleFor(x => x).Equal(expectedValue);
        }
    }
}