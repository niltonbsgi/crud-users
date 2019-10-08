
using System;
namespace RegisterUser.Domain
{
    public class UsersEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
    }
}
