using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Identity.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningBook.Identity.Application.ClientAccounts.Commands
{
    #region Command Model
    public sealed class ChangePasswordClientAccountCommand : ICommand<bool>
    {
        public Guid? UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public ChangePasswordClientAccountCommand(string oldPassword, string newPassword)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }

        public ValidationResult GetValidationResult()
        {
            var invalid = string.IsNullOrWhiteSpace(OldPassword) ||
                string.IsNullOrWhiteSpace(NewPassword) ||
                UserId == Guid.Empty ||
                UserId == null;

            if (invalid)
                return new ValidationResult()
                {
                    IsValid = false,
                    Messages = new List<string>()
                    {
                        "Changes Password Failed!"
                    }
                };

            return new ValidationResult()
            {
                IsValid = true
            };
        }
    }
    #endregion Command Model

    #region Command Handler
    public sealed class ChangePasswordClientAccountCommandHandler : ICommandHandler<ChangePasswordClientAccountCommand, bool>
    {
        private readonly UserManager<Account> _userManager;

        public ChangePasswordClientAccountCommandHandler(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> HandleAsync(ChangePasswordClientAccountCommand command, CancellationToken cancellationToken = default)
        {
            if (command == null || !command.GetValidationResult().IsValid)
                // TODO: Log Error
                return false;

            var userExisted = await _userManager.Users
                    .FirstOrDefaultAsync(account => account.Id == command.UserId &&
                        account.IsActive &&
                        !account.IsDeleted, cancellationToken);

            if (userExisted == null)
                return false;

            var result = await _userManager.ChangePasswordAsync(userExisted, command.OldPassword, command.NewPassword);

            return result.Succeeded;
        }
    }
    #endregion Command Handler
}
