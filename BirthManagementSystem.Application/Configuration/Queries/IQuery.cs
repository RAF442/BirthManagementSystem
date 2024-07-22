using MediatR;

namespace BirthManagementSystem.Application.Configuration.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{
}
