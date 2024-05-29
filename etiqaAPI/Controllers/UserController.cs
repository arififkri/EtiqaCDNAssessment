using AutoMapper;
using etiqa.Domain.Abstraction.Repositories;
using etiqa.Domain.Model;
using etiqaAPI.Dto.UserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace etiqaAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.GetUserAsync(userId);

            if (user is null)
                return NotFound();

            return Ok(user);

        }

       
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {

            var user = await _userRepository.GetUsersAsync();
            var userDto = _mapper.Map<List<GetUserDto>>(user);
            return Ok(user);
        
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUserAsync(EditUserDto editUser)
        {
            var user = _mapper.Map<User>(editUser);
            var result = await _userRepository.EditUserAsync(user);

            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _userRepository.DeleteUserAsync(userId);

            return Ok("User delete successfully.");
        }


        
    
    }
}
