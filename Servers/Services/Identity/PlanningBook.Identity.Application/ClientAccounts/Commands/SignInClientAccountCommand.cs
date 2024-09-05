using Microsoft.AspNetCore.Identity;
using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Identity.Infrastructure.Entities;

namespace PlanningBook.Identity.Application.ClientAccounts.Commands
{
    #region Command Model
    public sealed class SignInClientAccountCommand : ICommand<CommandResult<Guid>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public SignInClientAccountCommand(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        public ValidationResult GetValidationResult()
        {
            var invalid = string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password);
            if (invalid)
                return ValidationResult.Failure(null, null);

            return ValidationResult.Success();
        }
    }
    #endregion Command Model

    #region Command Handler
    public sealed class SignInClientAccountCommandHandler : ICommandHandler<SignInClientAccountCommand, CommandResult<Guid>>
    {
        private readonly UserManager<Account> _userManager;

        public Task<CommandResult<Guid>> HandleAsync(SignInClientAccountCommand command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
    #endregion Command Handler
}
