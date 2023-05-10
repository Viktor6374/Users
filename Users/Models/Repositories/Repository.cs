using System.Linq;
using Users.Models.Context;
using Users.Models.Entities;
using Users.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Users.Models.Repositories
{
    public class Repository
    {
        private UserContext _userContext;
        public Repository()
        {
            _userContext = new UserContext();
        }

        public void AddUser(string login, string password, int groupId)
        {
            UserGroup group = _userContext.UserGroups.SingleOrDefault(gr => gr.Id == groupId) ?? throw new ArgumentException("Incorrect group ID");
            UserState state = _userContext.UserStates.Single(gr => gr.Code == State.Active);
            if (group.Code == Group.Admin && _userContext.Users.SingleOrDefault(user => user.Group.Code == Group.Admin && user.State.Code == State.Active) != null)
            {
                throw new ArgumentException("Admin already exist.");
            }
            _userContext.Users.Add(new User(login, password, group, state));
            _userContext.SaveChanges();
        }

        public void RemoveUser(int userId)
        {
            User? user = _userContext.Users.SingleOrDefault(user => user.Id == userId) ?? throw new ArgumentException("User with this Id dont exist");
            user.State = _userContext.UserStates.Single(state => state.Code == Enums.State.Blocked);
            _userContext.SaveChanges();
        }

        public User? GetUser(int userId)
        {
            User? result = _userContext.Users.Include(user => user.State).Include(user => user.Group).SingleOrDefault(user => user.Id == userId);
            return result;
        }

        public List<User> GetAllUsers()
        {
            List<User> result = _userContext.Users.Include(user => user.State).Include(user => user.Group).ToList();
            return result;
        }

        public User? FindUserByLogin(string login)
        {
            return _userContext.Users.Include(user => user.State).Include(user => user.Group).SingleOrDefault(user => user.Login == login);
        }
    }
}
