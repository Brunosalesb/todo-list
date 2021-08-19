using FluentValidation;
using ToDoList.Domain.Contracts.Request;

namespace ToDoList.Domain.SqlServer.Validators
{
    public class CreateToDoRequestValidator : AbstractValidator<CreateToDoRequest>
    {
        public CreateToDoRequestValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(req => req.Description)
                .NotNull()
                .WithErrorCode("Description cannot be null");
        }
    }
}
