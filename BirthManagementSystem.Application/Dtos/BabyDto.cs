namespace BirthManagementSystem.Application.Dtos;

public class BabyDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string PersonalIdentityNumber { get; set; }
    public DateOnly DateOfBirth { get; set; }
}
