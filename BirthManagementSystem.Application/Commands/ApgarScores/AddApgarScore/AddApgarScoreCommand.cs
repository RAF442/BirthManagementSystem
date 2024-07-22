using BirthManagementSystem.Application.Configuration.Commands;
using BirthManagementSystem.Application.Dtos;

namespace BirthManagementSystem.Application.Commands.ApgarScores.AddApgarScore;

public class AddApgarScoreCommand : ICommand<ApgarScoreDto>
{
    public string Name { get; set; }
    public int Value { get; set; }
}
