using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService userService;

        public UsersController(IUserService iuserService)
        {
            userService = iuserService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get([FromQuery] string password, [FromQuery] string userName)
        {
            User user = await userService.GetUserByUsarNameAndPassword(userName, password);
            if (user != null)
                return Ok(user);
            return NoContent();

        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> Get(int id)
        {
            User user = await userService.getUserById(id);
            if (user == null)
                return NoContent();
            return Ok(user);
        }

        //POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            try
            {
                userService.addUser(user);
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            } 
            catch(Exception e)
            {
                throw e;
            }
           
        }

        [HttpPost("checkStrongPassword")]
        public ActionResult<User> Post([FromBody] string password)
        {
            int res = userService.checkPassword(password);
            if (res > 2)
                return Ok(res);
            return NoContent();
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User userUpdate)
        {
            try
            {
                User updateUser = await userService.update(id, userUpdate);
                return Ok(updateUser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
