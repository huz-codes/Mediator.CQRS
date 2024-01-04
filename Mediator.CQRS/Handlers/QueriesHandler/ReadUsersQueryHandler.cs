using Mediator.CQRS.Interfaces;
using Mediator.CQRS.Models;
using Mediator.CQRS.Queries;
using MediatR;

namespace Mediator.CQRS.Handlers.QueriesHandler
{
    public class ReadUsersQueryHandler : IRequestHandler<ReadUsersQuery, List<UserModel>>
    {
        private readonly IUserServices _userServices;
        public ReadUsersQueryHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public async Task<List<UserModel>> Handle(ReadUsersQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_userServices.GetUsers());
        }
    }
}
