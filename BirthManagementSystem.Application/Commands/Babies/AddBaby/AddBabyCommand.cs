using BirthManagementSystem.Application.Configuration.Commands;
using BirthManagementSystem.Application.Dtos;

namespace BirthManagementSystem.Application.Commands.Babies.AddBaby;

public class AddBabyCommand : ICommand<BabyDto>
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string PersonalIdentityNumber { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
}
