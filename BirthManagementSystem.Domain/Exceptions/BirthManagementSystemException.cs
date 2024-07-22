using System.Net;

namespace BirthManagementSystem.Domain.Exceptions;

public abstract class BirthManagementSystemException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }

    public BirthManagementSystemException(string messege) : base(messege)
    {
        
    }
}
