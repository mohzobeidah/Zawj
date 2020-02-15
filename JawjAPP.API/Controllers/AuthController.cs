using System.Threading.Tasks;
using JawjAPP.API.Data;
using JawjAPP.API.DataTransferObject;
using JawjAPP.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace JawjAPP.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController:ControllerBase
    {
         public IAuthRepository _repo ;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo,IConfiguration config)
        {
            _repo = repo;
            this._config = config;
        }
        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody]UserDto userDto)
        {

         if (!ModelState.IsValid) return BadRequest(ModelState);
           userDto.username=userDto.username.ToUpper();
            if (await _repo.UserExists(userDto.username)){

                return BadRequest("هذا المستخدم موجود");
            }
            var userToCreate = new User {
                UserName= userDto.username,
                
            };
             var userCeate=_repo.Register(userToCreate,userDto.password);
             return StatusCode(201);


        }
[HttpPost("login")]
public async Task<IActionResult> login([FromBody]UserForLoginDTO userForLoginDTO){
 if (!ModelState.IsValid) return BadRequest(ModelState);
     var  userFromRepo = await _repo.Login(userForLoginDTO.username.ToUpper(),userForLoginDTO.password);
     if(userFromRepo== null) return Unauthorized();
     var claims = new[]{
            new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
            new Claim(ClaimTypes.Name,userForLoginDTO.username)

     };
    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("APPSettings:token").Value));
    SigningCredentials signingCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
var tokenDesciptor = new SecurityTokenDescriptor(){
    Subject=new ClaimsIdentity(claims), Expires=DateTime.Now.AddDays(1),SigningCredentials=signingCredentials
    


};
var tokenHandeler = new JwtSecurityTokenHandler();
var  token = tokenHandeler.CreateToken(tokenDesciptor);
return Ok(new { token=tokenHandeler.WriteToken(token)});
}

       
    }

}