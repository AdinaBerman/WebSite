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
        ILogger<UsersController> _logger;

        public UsersController(IMapper mapper, IUserService userService, ILogger<UsersController> logger)
        {
            _mapper = mapper;
            _userService = userService;
            _logger = logger;
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<UserSaveDTO>> Post([FromBody] UserLoginDTO userLogin)
        {
            User userParse = _mapper.Map<UserLoginDTO, User>(userLogin);
            User user = await _userService.GetUserByUsarNameAndPasswordAsync(userParse.Email, userParse.Password);
            if (user != null)
            {
                UserSaveDTO userSave = _mapper.Map<User, UserSaveDTO>(user);
                _logger.LogInformation("user{0} connect", userParse.Email);
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, userSave);
            }
            return NoContent();

        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            User user = await _userService.getUserByIdAsync(id);
            if (user == null)
                return NoContent();
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return Ok(userDTO);
        }

        //POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)
        {
            User userParse = _mapper.Map<UserDTO, User>(user);
            User newUser = await _userService.addUserAsync(userParse);
            if (newUser == null) 
                return BadRequest();
            UserDTO newUserDTO = _mapper.Map<User, UserDTO>(newUser);
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUserDTO);
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
        public async Task<ActionResult> Put(int id, [FromBody] UserDTO userUpdate)
        {
            User userParse = _mapper.Map<UserDTO, User>(userUpdate);
            User updateUser = await _userService.updateAsync(id, userParse);
            if (updateUser == null)
                return BadRequest();
            return Ok(updateUser);
        }

    }
}
