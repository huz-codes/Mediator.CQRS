using Mediator.CQRS.Commands;
using Mediator.CQRS.Interfaces;
using Mediator.CQRS.Models;
using MediatR;

namespace Mediator.CQRS.Handlers.CommandsHandler
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserModel>
    {
        private readonly IUserServices _userServices;
        public AddUserCommandHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public async Task<UserModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var oDataModel = new UserModel(request.Id,
                                           request.FirstName,
                                           request.LastName);

            return _userServices.AddUser(oDataModel);
        }
    }
}
