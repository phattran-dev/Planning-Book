using Microsoft.AspNetCore.Identity;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Identity.Infrastructure.Entities;
using PlanningBook.Identity.Infrastructure;
using PlanningBook.Domain;
using Microsoft.EntityFrameworkCore;

namespace PlanningBook.Identity.Application.Accounts.Commands
{
    #region Command Model
    public sealed class SignUpClientAccountCommand : ICommand<CommandResult<Guid>>
    {
        public string Username { get; set; }
        public string Password { get; set; } // TO DO: Should not plain text from FE -> BE
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public SignUpClientAccountCommand(string username, string password, string? email, string? phoneNumber)
        {
            Username = username;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public ValidationResult GetValidationResult()
        {
            var invalid = string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password);
            if (invalid)
            {
                return new ValidationResult()
                {
                    IsValid = false,
                    Messages = new List<string>()
                    {
                        "Register Account Failed: Invalid request!"
                    }
                };
            }

            return new ValidationResult()
            {
                IsValid = true
            };
        }
    }
    #endregion Command Model

    #region Command Handler
    public sealed class SignUpClientAccountCommandHandler : ICommandHandler<SignUpClientAccountCommand, CommandResult<Guid>>
    {
        private readonly UserManager<Account> _accountManager;

        public SignUpClientAccountCommandHandler(UserManager<Account> accountManager)
        {
            _accountManager = accountManager;
        }

        public async Task<CommandResult<Guid>> HandleAsync(SignUpClientAccountCommand command, CancellationToken cancellationToken = default)
        {
            if (command == null || !command.GetValidationResult().IsValid)
            {
                // TODO: Log Error
                // TODO: Handle throw error with error message
                return CommandResult<Guid>.Failure(null, null);
            }

            //var accountExisted = await _accountManager.FindByEmailAsync(command.Email);
            //var accountExisted = await _accountManager.Users
            //    .FirstOrDefaultAsync(x => x.UserName == command.Username &&
            //    x.);

            if (!string.IsNullOrWhiteSpace(command.Email))
            {
                var isEmailUsed = await _accountManager.Users
                    .AnyAsync(account => account.Email == command.Email &&
                        account.IsActive &&
                        !account.IsDeleted, cancellationToken);
                if (isEmailUsed)
                {
                    // TODO: Log Error & Return Error
                    return CommandResult<Guid>.Failure(null, null);
                }
            }

            if (!string.IsNullOrWhiteSpace(command.PhoneNumber))
            {
                var isPhoneUsed = await _accountManager.Users
                    .AnyAsync(account => account.PhoneNumber == command.PhoneNumber &&
                        account.IsActive &&
                        !account.IsDeleted, cancellationToken);

                if (isPhoneUsed)
                {
                    // TODO: Log Error & Return Error
                    return CommandResult<Guid>.Failure(null, null);
                }
            }

            var accountExisted = await _accountManager.Users
                .AnyAsync(account => account.UserName == command.Username
                && account.Email == command.Email
                && account.PhoneNumber == command.PhoneNumber
                && account.IsActive
                && !account.IsDeleted, cancellationToken);

            if (accountExisted)
            {
                // TODO: Log Error
                //TODO: Improve for flow SSO (with Link account)
                // Example User craete an account username/password with email A
                // After that the login by Gmail with same email A
                // => Ask to login by username/passwork and link Gmail in account setting
                return CommandResult<Guid>.Failure(null, null);
            }

            var account = new Account()
            {
                UserName = command.Username,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
            };

            // Need Add salt & perper for Password
            var result = await _accountManager.CreateAsync(account, command.Password);
            if (!result.Succeeded)
                return CommandResult<Guid>.Failure(null, null);

            // TODO: Send Confirmed email & sms
            // TODO: Send to Person Service API to create Person record

            return CommandResult<Guid>.Success(account.Id);
        }
    }
    #endregion Command Handler
}
