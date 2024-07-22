using System.Net;

namespace BirthManagementSystem.Domain.Exceptions;

public class ApgarScoreNotFoundException : BirthManagementSystemException
{
    public int Id { get; }
    public ApgarScoreNotFoundException(int id) 
        : base($"Apgar score with ID {id} was not found.")
    {
        Id = id;
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
