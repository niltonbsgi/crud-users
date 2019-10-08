using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterUser.Data
{
    public interface IUserRepository
    {
        Users GetUser(Guid Id);
        List<Users> GetAllUsers();

        PostUser PostUser(Users body);

        PostUser PutUser(Guid Id, Users body);
        bool DeleteUser(Guid Id);

    }
}
