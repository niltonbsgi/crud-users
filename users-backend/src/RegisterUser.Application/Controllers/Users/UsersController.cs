using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegisterUser.Domain;

namespace RegisterUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserUnitOfWork _userunitofwork;
        public UsersController(IUserUnitOfWork userunitofwork)
        {
            _userunitofwork = userunitofwork;
        }

        [HttpGet("{id}")]
        public ActionResult<UsersEntity> GetUserById(string id)
        {
            try
            {
                var result =  _userunitofwork.GetUser(Guid.Parse(id));
                if (result != null) {
                    return Ok (result);
                } else {
                    return NotFound (result);
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message.ToString());
                return BadRequest();
            }

        }

        [HttpGet]
        public ActionResult<UsersEntity> GetAll()
        {
            try
            {
                var result =  _userunitofwork.GetAllUsers();
                if (result != null) {
                    return Ok (result);
                } else {
                    return NotFound (result);
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message.ToString());
                return BadRequest();
            }

        }

        // POST api/values
        [HttpPost]
        public PostResult Post([FromBody] UsersEntityInsertUpdate body)
        {
            try
            {
                return  _userunitofwork.PostUser(body);
            }
            catch
            {
                throw new Exception();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public PostResult Put(Guid Id, [FromBody] UsersEntityInsertUpdate body)
        {
            try
            {
                return  _userunitofwork.PutUser(Id, body);
            }
            catch
            {
                throw new Exception();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(string Id)
        {
            try
            {
                return  _userunitofwork.DeleteUser(Guid.Parse(Id));
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
