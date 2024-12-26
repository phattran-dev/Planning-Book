using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Identity.Application.Constants;
using PlanningBook.Identity.Application.Helpers.Interfaces;
using PlanningBook.Identity.Infrastructure.Entities;
using PlanningBook.Identity.Infrastructure.Enums;

namespace PlanningBook.Identity.Application.Domains.Customers.Commands
{
    #region Command Model
    public class SignUpCustomerCommand : ICommand<CommandResult<Guid>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public SignUpCustomerCommand(string username, string password, string email, string? phoneNumber)
        {
            Username = username;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public ValidationResult GetValidationResult()
        {
            var errors = new List<int>();
            if (string.IsNullOrWhiteSpace(Username))
                errors.Add(ErrorCodes.MISSING_COMMAND_PROPERTY_USERNAME);

            if (string.IsNullOrWhiteSpace(Password))
                errors.Add(ErrorCodes.MISSING_COMMAND_PROPERTY_PASSWORD);

            if (string.IsNullOrWhiteSpace(Email))
                errors.Add(ErrorCodes.MISSING_COMMAND_PROPERTY_EMAIL);

            if (errors.Any())
                return ValidationResult.Failure(errors);

            return ValidationResult.Success();
        }
    }
    #endregion Command Model

    #region Command Handler
    public class SignUpCustomerCommandHadnler(UserManager<Account> _userManager, IPasswordHasher _passwordHasher,) : ICommandHandler<SignUpCustomerCommand, CommandResult<Guid>>
    {
        public async Task<CommandResult<Guid>> HandleAsync(SignUpCustomerCommand command, CancellationToken cancellationToken = default)
        {
            if (command == null)
                return CommandResult<Guid>.Failure(new List<int>() { ErrorCodes.MISSING_COMMAND });

            var commandValidateResult = command.GetValidationResult();
            if (!commandValidateResult.IsValid)
                return CommandResult<Guid>.Failure(commandValidateResult.ErrorCodes, commandValidateResult.Messages);

            if (!string.IsNullOrWhiteSpace(command.PhoneNumber))
            {
                var isDuplicatePhoneNumber = await _userManager.Users
                    .AnyAsync(x => x.PhoneNumber == command.PhoneNumber &&
                        x.Status == AccountStatus.Active,
                        cancellationToken);
                if (isDuplicatePhoneNumber)
                    return CommandResult<Guid>.Failure(ErrorCodes.DUPLICATE_PHONE_NUMBER);
            }

            var isDuplicateEmail = await _userManager.Users
                    .AnyAsync(x => x.Email == command.Email &&
                        x.Status == AccountStatus.Active,
                        cancellationToken);
            if (isDuplicateEmail)
                return CommandResult<Guid>.Failure(ErrorCodes.DUPLICATE_EMAIL);

            var isDuplicateUsername = await _userManager.Users
                    .AnyAsync(x => x.UserName == command.Username &&
                        x.Status == AccountStatus.Active,
                        cancellationToken);
            if (isDuplicateUsername)
                return CommandResult<Guid>.Failure(ErrorCodes.DUPLICATE_USERNAME);

            var newAccount = new Account()
            {
                UserName = command.Username,
                NormalizedUserName = command.Username.ToUpper(),
                Email = command.Email,
                NormalizedEmail = command.Email.ToUpper(),
                PhoneNumber = command.PhoneNumber,
                Status = AccountStatus.InRegistrationProcess,

            };
            var createAccountResult = await _userManager.CreateAsync(newAccount);
            if (!createAccountResult.Succeeded)
                return CommandResult<Guid>.Failure(ErrorCodes.CREATE_ACCOUNT_FAILED, createAccountResult.Errors.ToString());

            newAccount.PasswordHash = _passwordHasher.Hash(command.Password);
            newAccount.Status = AccountStatus.Active;
            newAccount.CreatedDate = DateTimeOffset.UtcNow;

            var updateAccountResult = await _userManager.UpdateAsync(newAccount);
            if (!updateAccountResult.Succeeded)
                return CommandResult<Guid>.Failure(ErrorCodes.CREATE_ACCOUNT_FAILED, updateAccountResult.Errors.ToString());

            return CommandResult<Guid>.Success(newAccount.Id);
        }
    }
    #endregion Command Handler
}
