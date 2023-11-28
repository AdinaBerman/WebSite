using AutoMapper;
using DTO;
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
        IMapper _mapper;
        IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<UserSaveDTO>> Post([FromBody] UserLoginDTO userLogin)
        {
            User userParse = _mapper.Map<UserLoginDTO, User>(userLogin);
            User user = await _userService.GetUserByUsarNameAndPassword(userParse.Email, userParse.Password);
            if (user != null)
            {
                UserSaveDTO userSave = _mapper.Map<User, UserSaveDTO>(user);
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, userSave);
            }
            return NoContent();

        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> Get(int id)
        {
            User user = await _userService.getUserById(id);
            if (user == null)
                return NoContent();
            return Ok(user);
        }

        //POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            try
            {
                User newUser = await _userService.addUser(user);
                if (newUser == null) 
                    return BadRequest();
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, newUser);
            } 
            catch(Exception e)
            {
                throw e;
            }
           
        }

        [HttpPost("checkStrongPassword")]
        public ActionResult<User> Post([FromBody] string password)
        {
            int res = _userService.checkPassword(password);
            if (res > 2)
                return Ok(res);
            return BadRequest();
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User userUpdate)
        {
            try
            {
                User updateUser = await _userService.update(id, userUpdate);
                if (updateUser == null)
                    return BadRequest();
                return Ok(updateUser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
