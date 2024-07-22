using System.Net;

namespace BirthManagementSystem.Domain.Exceptions;

public class BabyAlreadyExistException : BirthManagementSystemException
{
    public string PersonalIdentityNumber { get; set; }
    public BabyAlreadyExistException(string personal_id_number) : base($"Baby with PESEL {personal_id_number} already exists.")
        =>PersonalIdentityNumber = personal_id_number;

    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
}
