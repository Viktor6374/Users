using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Users.Models.Enums;

namespace Users.Models.Entities
{
    public class UserState
    {
        public UserState(int id, State code, string description)
        {
            Id = id;
            Code = code;
            Description = description;
        }
        [Key]
        public int Id { get; private set; }
        public State Code { get; set; }
        public string Description { get; set; }
    }
}
