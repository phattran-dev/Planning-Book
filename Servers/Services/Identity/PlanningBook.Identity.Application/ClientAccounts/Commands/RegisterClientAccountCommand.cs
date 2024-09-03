using Microsoft.AspNetCore.Identity;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Identity.Infrastructure.Entities;
using PlanningBook.Identity.Infrastructure;
using PlanningBook.Domain;
using Microsoft.EntityFrameworkCore;

namespace PlanningBook.Identity.Application.Accounts.Commands
{
    #region Command Model
    public sealed class RegisterClientAccountCommand : ICommand<Guid?>
    {
        public string Username { get; set; }
        public string Password { get; set; } // TO DO: Should not plain text from FE -> BE
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public RegisterClientAccountCommand(string username, string password, string? email, string? phoneNumber)
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
    public sealed class RegisterClientAccountCommandHandler : ICommandHandler<RegisterClientAccountCommand, Guid?>
    {
        private readonly PBIdentityDbContext _identityDbContext;
        private readonly UserManager<Account> _accountManager;

        public RegisterClientAccountCommandHandler(PBIdentityDbContext identityDbContext, UserManager<Account> accountManager)
        {
            _identityDbContext = identityDbContext;
            _accountManager = accountManager;
        }

        public async Task<Guid?> HandleAsync(RegisterClientAccountCommand command, CancellationToken cancellationToken = default)
        {
            if (command == null || !command.GetValidationResult().IsValid)
            {
                // TODO: Log Error
                // TODO: Handle throw error with error message
                return null;
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
                    return null;
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
                    return null;
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
                return null;
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
                return null;

            // TODO: Send Confirmed email & sms
            // TODO: Send to Person Service API to create Person record

            return account.Id;
        }
    }
    #endregion Command Handler
}
