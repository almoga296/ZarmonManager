using FluentValidation;
using Zarmon.Device.ApiCore.TplBooster.Models;

namespace Zarmon.Device.Logics.Validation
{
    public class BoosterStatusValidator : AbstractValidator<BoosterStatusModel>
    {
        public BoosterStatusValidator()
        {
            RuleFor(statusModel => statusModel.Vswr).InclusiveBetween(1, 3);
            RuleFor(statusModel => statusModel.ForwardPower).InclusiveBetween(150, 200);
            RuleFor(statusModel => statusModel.ReflectedPower).InclusiveBetween(0, 50);
        }
    }
}