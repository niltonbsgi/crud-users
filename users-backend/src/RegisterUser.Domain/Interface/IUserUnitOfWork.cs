
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterUser.Domain
{
    public interface IUserUnitOfWork
    {
        UsersEntity GetUser(Guid Id);
        List<UsersEntity> GetAllUsers();
        PostResult PostUser(UsersEntityInsertUpdate body);
        PostResult PutUser(Guid Id, UsersEntityInsertUpdate body);
        bool DeleteUser(Guid Id);
    }
}
