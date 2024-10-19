using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Net.DTO;
using WebApi.Net.Models;

namespace WebApi.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager; 
        

        public AccountController(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO UserFormatRequest) 
        {
            if (ModelState.IsValid) {
                ApplicationUser user = new ApplicationUser();
                user.UserName = UserFormatRequest.Username;
                user.Email = UserFormatRequest.Email;

             IdentityResult result = await  _userManager.CreateAsync(user, password: UserFormatRequest.Password);

                if (result.Succeeded)
                {
                    return Ok("Created");
                }
                else {
                    foreach (var item in result.Errors) {
                        ModelState.AddModelError("Password", item.Description);
                    }
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO userFromRequest)
        {
            if (ModelState.IsValid) {
                ApplicationUser userFromDb = await _userManager.FindByNameAsync(userFromRequest.Name);
                if (userFromDb != null) {
                    bool found =
                            await _userManager.CheckPasswordAsync(userFromDb, userFromRequest.Password);
                    if (found) 
                    {
                        List<Claim> UserClaims =new List<Claim>();

                        UserClaims.Add(new Claim(ClaimTypes.NameIdentifier, userFromDb.Id));
                        UserClaims.Add(new Claim(ClaimTypes.Name, userFromDb.UserName));
                        UserClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                       
                        var UserRoles =await _userManager.GetRolesAsync(userFromDb);
                        foreach (var userRole in UserRoles) {
                            UserClaims.Add(new Claim(ClaimTypes.Role,userRole));

                        }
                        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("StrongStringForSignature%$#@"));
                        
                        
                        SigningCredentials signingCredentials =
                            new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                                );
                        //Design Token
                        JwtSecurityToken mytoken = new JwtSecurityToken(
                            audience:"http://localhost:4200/",
                            issuer: "http://localhost:5073/",
                            expires:DateTime.Now.AddHours(1),
                            claims:UserClaims,
                            signingCredentials: signingCredentials
                            ); 
                        //Generate Token
                        return Ok(
                            new { 
                                token = new JwtSecurityTokenHandler().WriteToken(mytoken)
                                ,expiration =DateTime.Now.AddHours(1)
                            }
                            );

                    }
                    ModelState.AddModelError("Username", "UsernameOrPasswrd is Wrong");
            } 
            
            }
            return BadRequest(ModelState);  
        }
    }
}
