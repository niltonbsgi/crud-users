using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegisterUser.Data;

namespace RegisterUser.Domain
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly IUserRepository _userrepository;
        public UserUnitOfWork(IUserRepository userrepository)
        {
            _userrepository = userrepository;
        }
        public UsersEntity GetUser(Guid Id)
        {
            try
            {
                var result = _userrepository.GetUser(Id);
                return new UsersEntity
                {
                    Id=result.Id,
                    Name=result.Name,
                    Email=result.Email,
                    WebSite=result.WebSite
                };
            }
            catch
            {
                throw new Exception();
            }
        }

        public List<UsersEntity>  GetAllUsers()
        {
            try{
                List<UsersEntity> listuser = new List<UsersEntity>();
                var result = _userrepository.GetAllUsers();
                foreach (var item in result)
                {
                    listuser.Add(new UsersEntity
                    {
                        Id=item.Id,
                        Name=item.Name,
                        Email=item.Email,
                        WebSite=item.WebSite
                    });
                }
                return listuser;
            }
            catch
            {
                throw new Exception();
            }
        }

        public PostResult PostUser(UsersEntityInsertUpdate body)
        {
            try
            {
                var result =  _userrepository.PostUser(
                    new Users
                    {   Id=Guid.NewGuid(),
                        Name=body.Name,
                        Email=body.Email,
                        WebSite=body.WebSite
                    }
                );

                return new PostResult{
                    Success=result.Success,
                    Message=result.Message
                };
            }
            catch
            {
                throw new Exception();
            }
        }

        public PostResult PutUser(Guid Id, UsersEntityInsertUpdate body)
        {
            try
            {
                var result =  _userrepository.PutUser(Id,
                    new Users
                    {   Name=body.Name,
                        Email=body.Email,
                        WebSite=body.WebSite
                    }
                );

                return new PostResult{
                    Success=result.Success,
                    Message=result.Message
                };
            }
            catch
            {
                throw new Exception();
            }
        }

        public bool DeleteUser(Guid Id)
        {
            try
            {
                return _userrepository.DeleteUser(Id);
            }
            catch
            {
                throw new Exception();
            }

        }
    }
}
