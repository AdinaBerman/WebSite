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
        IUserService userService; //_userService - convention 

        public UsersController(IUserService iuserService)
        //IuserService userService (instead of  iuserService)

        {
            userService = iuserService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        //IEnumerable? why?
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
        //async await???? Task<ActionResult<User>>
        public ActionResult<User> Post([FromBody] User user)
        {

            try
            {
                //newUser= , Store the result of adding the user into  'newUser' variable.
                userService.addUser(user);
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
                //Check if newUser==null return BadRequest() 

            }
            catch (Exception e)
            {
                //(An exception return an interanl server error- 500) 
                throw e;
            }
           
        }

        [HttpPost("checkStrongPassword")]
        public ActionResult<User> Post([FromBody] string password)
        {
            int res = userService.checkPassword(password);
            if (res > 2)
                return Ok(res);
            return NoContent();//NoContent isn't suitable here, use BadRequest()
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User userUpdate)
        {
            try
            {
                User updateUser = await userService.update(id, userUpdate);
                return Ok(updateUser);
                //Check if updateUser==null return BadRequest()
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Clean code -Remove unnecessary lines of code.
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
