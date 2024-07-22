namespace BirthManagementSystem.Domain.Entities;

public class PlaceOfBirth : Entity
{
    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }

    public int? BabyId { get; set; }
    public Baby Baby { get; set; }
}
