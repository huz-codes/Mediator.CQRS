using Mediator.CQRS.Models;
using MediatR;

namespace Mediator.CQRS.Queries
{
    public class ReadUsersQuery : IRequest<List<UserModel>>
    {
    }
}
