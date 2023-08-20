using FluentValidation;
using SRM.Api.Entites;

namespace SRM.Api.Validations
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .WithMessage("lütfen en az 2 karakter giriniz.");

            RuleFor(x=>x.LastName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .WithMessage("lütfen en az 2 karakter giriniz.");
        }
    }
}
