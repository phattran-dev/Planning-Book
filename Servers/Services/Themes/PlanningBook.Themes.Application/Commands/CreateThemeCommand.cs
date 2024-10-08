using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Repository.EF;
using PlanningBook.Themes.Infrastructure;
using PlanningBook.Themes.Infrastructure.Entities;

namespace PlanningBook.Themes.Application.Products.Commands
{
    #region Command Model
    public sealed class CreateThemeCommand : ICommand<CommandResult<Guid>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public CreateThemeCommand(string name, string? description)
        {
            Name = name;
            Description = description;
        }

        public ValidationResult GetValidationResult()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return ValidationResult.Failure();

            return ValidationResult.Success();
        }
    }
    #endregion Command Model

    #region Command Handler
    public sealed class CreateProductCommandHandler(
        IEFRepository<PBThemeDbContext, Theme, Guid> _themeRepository) : ICommandHandler<CreateThemeCommand, CommandResult<Guid>>
    {
        public async Task<CommandResult<Guid>> HandleAsync(CreateThemeCommand command, CancellationToken cancellationToken = default)
        {
            if (command == null || !command.GetValidationResult().IsValid)
                return CommandResult<Guid>.Failure();

            var product = new Theme()
            {
                Name = command.Name,
                Description = command?.Description,
            };

            await _themeRepository.AddAsync(product);
            await _themeRepository.SaveChangeAsync();

            return CommandResult<Guid>.Success(product.Id);
        }
    }
    #endregion Command Handler
}
