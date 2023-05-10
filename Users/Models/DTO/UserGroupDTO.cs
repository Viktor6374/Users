using Users.Models.Entities;

namespace Users.Models.DTO
{
    public class UserGroupDTO
    {
        public UserGroupDTO(UserGroup userGroup)
        {
            Id = userGroup.Id;
            Code = userGroup.Code.ToString();
            Description = userGroup.Description;
        }
        public int Id { get; }
        public string Code { get; }
        public string Description { get; }
    }
}
