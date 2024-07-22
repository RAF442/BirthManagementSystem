using BirthManagementSystem.Application.Configuration.Commands;

namespace BirthManagementSystem.Application.Commands.Babies.UpdateBaby;

public class UpdateBabyCommand : ICommand
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string PersonalIdentityNumber { get; set; }
    public DateOnly DateOfBirth { get; set; }

}
