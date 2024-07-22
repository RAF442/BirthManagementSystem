namespace BirthManagementSystem.Domain.Entities;

public class Baby : Entity
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string PersonalIdentityNumber { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public int? ApgarScoreId { get; set; }
    public ApgarScore ApgarScore { get; set; }

    public PlaceOfBirth PlaceOfBirth { get; set; }

}
