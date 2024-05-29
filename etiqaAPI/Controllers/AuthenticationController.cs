
using AutoMapper;
using etiqa.Domain.Abstraction.Repositories;
using etiqa.Domain.Abstraction.Services;
using etiqa.Domain.Model;
using etiqa.Service;
using etiqaAPI.Dto.AuthenticationDto;
using etiqaAPI.Dto.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace etiqaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AuthenticationController(IAuthenticationService authenticationService, IMapper mapper, IUserRepository userRepository)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]CreateUserDto userdto)
        {
            try {
                if (userdto == null)
                    return BadRequest(ModelState);



                var user = _mapper.Map<User>(userdto);

                var result = await _authenticationService.SignUp(user);

                if (result is null)
                {
                    return StatusCode(422, ModelState);
                }
                return Created("", result);
            } catch (Exception e) {

                throw;
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody]SignInDto userdto)
        {
            var user = _mapper.Map<User>(userdto);
            var result = await _authenticationService.SignIn(user);
            return Ok(result);
        }
    }
}
