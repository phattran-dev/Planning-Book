using Microsoft.AspNetCore.Identity;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Identity.Infrastructure;
using PlanningBook.Identity.Infrastructure.Entities;
using PlanningBook.Repository.EF;

namespace PlanningBook.Identity.Application.Commands.Accounts
{
    #region Command Model
    public sealed class CreateAccountByUserNameCommand : ICommand<Guid>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public CreateAccountByUserNameCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
    #endregion Command Model

    #region Command Handler
    public sealed class CreateAccountByUserNameCommandHandler : ICommandHandler<CreateAccountByUserNameCommand, Guid>
    {
        private readonly PBIdentityDbContext _identityDbContext;
        //private readonly IEFRepository<PBIdentityDbContext, Account, Guid> _accountRepository;
        private readonly UserManager<Account> _accountManager;
        //private readonly RoleManager<AccountRole> _roleManager;
        public CreateAccountByUserNameCommandHandler(PBIdentityDbContext identityDbContext, UserManager<Account> accountManager)
        {
            _identityDbContext = identityDbContext;
            _accountManager = accountManager;
        }

        public Task<Guid> HandleAsync(CreateAccountByUserNameCommand command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
    #endregion Command Handler
}
