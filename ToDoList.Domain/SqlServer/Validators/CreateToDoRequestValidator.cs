using FluentValidation;
using ToDoList.Domain.SqlServer.Contracts.Request;

namespace ToDoList.Domain.SqlServer.Validators
{
    public class CreateToDoRequestValidator : AbstractValidator<CreateToDoRequest>
    {
        public CreateToDoRequestValidator()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty();
        }
    }
}
