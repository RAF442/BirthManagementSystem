namespace BirthManagementSystem.Domain.Entities;

public class ApgarScore : Entity
{
    public string Name { get; set; }
    public int Value { get; set; }

    public ICollection<Baby> Babies { get; set; }
}
