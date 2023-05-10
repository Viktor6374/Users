using Users.Models.DTO;
using Users.Models.Entities;

namespace Users.Controllers.DTO
{
    public class UserDTO
    {
        public UserDTO(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Password = user.Password;
            CreatedDate = user.CreatedDate;
            Group = new UserGroupDTO(user.Group);
            State = new UserStateDTO(user.State);
        }
        public int Id { get; }
        public string Login { get; }
        public string Password { get; }
        public DateTime CreatedDate { get; }
        public UserGroupDTO Group { get; }
        public UserStateDTO State { get; }
    }
}
