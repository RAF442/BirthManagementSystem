using System.Net;

namespace BirthManagementSystem.Domain.Exceptions;

public class BabyNotFoundException : BirthManagementSystemException
{
    public int Id { get; set; }
    public BabyNotFoundException(int id) : base($"Baby with ID {id} was not found")
        => Id = id;

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
