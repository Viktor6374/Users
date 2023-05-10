using Users.Models.Entities;

namespace Users.Controllers.DTO
{
    public class UserStateDTO
    {
        public UserStateDTO(UserState userState)
        {
            Id = userState.Id;
            Code = userState.Code.ToString();
            Description = userState.Description;
        }
        public int Id { get; }
        public string Code { get; }
        public string Description { get; }
    }
}
