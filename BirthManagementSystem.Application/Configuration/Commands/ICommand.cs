using MediatR;

namespace BirthManagementSystem.Application.Configuration.Commands;

public interface ICommand : IRequest
{
}

public interface ICommand<out TResult> : IRequest<TResult>
{
}
