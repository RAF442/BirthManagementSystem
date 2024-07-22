using System.Net;

namespace BirthManagementSystem.Domain.Exceptions;

public class ApgarScoreAlreadyExistsException : BirthManagementSystemException
{
    public string Name { get; }
    public int Value { get; }

    public ApgarScoreAlreadyExistsException(int value) 
        : base($"Apgar score with value {value} already exists.")
    {
        Value = value;
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
