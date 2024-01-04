using Mediator.CQRS.Models;
using MediatR;

namespace Mediator.CQRS.Queries
{
    public class ReadUserByIndexQuery : IRequest<UserModel>
    {
        public int Index { get; set; }
        public ReadUserByIndexQuery(int index)
        {
            Index = index;
        }
    }
}
