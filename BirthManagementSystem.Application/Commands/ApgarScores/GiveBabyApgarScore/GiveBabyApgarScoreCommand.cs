using BirthManagementSystem.Application.Configuration.Commands;

namespace BirthManagementSystem.Application.Commands.ApgarScores.GiveBabyApgarScore;

public record class GiveBabyApgarScoreCommand(int Id, int ApgarScoreId) : ICommand;

