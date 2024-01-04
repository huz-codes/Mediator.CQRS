using Mediator.CQRS.Interfaces;
using Mediator.CQRS.Models;
using Mediator.CQRS.Queries;
using MediatR;

namespace Mediator.CQRS.Handlers.QueriesHandler
{
    public class ReadUserByIndexQueryHandler : IRequestHandler<ReadUserByIndexQuery, UserModel>
    {
        private readonly IUserServices _userServices;
        public ReadUserByIndexQueryHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public async Task<UserModel> Handle(ReadUserByIndexQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_userServices.GetUserByIndex(request.Index));
        }
    }
}
