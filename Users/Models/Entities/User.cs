using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Users.Models.Entities
{
    public class User
    {
        public User() { }
        public User(string login, string password, UserGroup group, UserState state)
        {
            Login = login;
            Password = password;
            CreatedDate = DateTime.UtcNow;
            Group = group;
            State = state;
        }
        [Key]
        public int Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; }
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public virtual UserGroup Group { get; set; }
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual UserState State { get; set; }
    }
}
