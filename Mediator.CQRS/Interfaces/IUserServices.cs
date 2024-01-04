using Mediator.CQRS.Models;

namespace Mediator.CQRS.Interfaces
{
    public interface IUserServices
    {
        public UserModel AddUser(UserModel user);
        public List<UserModel> GetUsers();
        public UserModel GetUserByIndex(int index);
    }
}
