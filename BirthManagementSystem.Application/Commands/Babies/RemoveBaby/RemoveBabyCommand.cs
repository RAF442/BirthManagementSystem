using BirthManagementSystem.Application.Configuration.Commands;

namespace BirthManagementSystem.Application.Commands.Babies.RemoveBaby;

public record RemoveBabyCommand(int Id) : ICommand
{
}
