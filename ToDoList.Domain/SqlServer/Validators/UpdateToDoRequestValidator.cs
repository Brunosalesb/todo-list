using FluentValidation;
using ToDoList.Domain.SqlServer.Contracts.Request;

namespace ToDoList.Domain.SqlServer.Validators
{
    public class UpdateToDoRequestValidator : AbstractValidator<UpdateToDoRequest>
    {
        public UpdateToDoRequestValidator()
        {
            RuleFor(x => x.Id)
               .NotNull();

            RuleFor(x => x.Description)
               .NotNull()
               .NotEmpty();
        }
    }
}
