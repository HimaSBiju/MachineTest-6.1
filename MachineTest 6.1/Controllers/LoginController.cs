using MachineTest_6._1.Models;
using MachineTest_6._1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MachineTest_6._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserLogin _loginRepository;
        private readonly IConfiguration _config;

        //Construction injection
        public LoginController(IUserLogin loginRepository, IConfiguration config)
        {
            _loginRepository = loginRepository;
            _config = config;

        }

        //Get a User
        private Login AuthenticateUser(string username, string password)
        {
            Login user = _loginRepository.ValidateUser(username, password);

            if (user != null)
            {
                return user;
            }
            return null;
        }

        //Generate Json web token
        private string GenerateJSONWebToken(Login user)
        {
            //security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Generate Token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet("{userName}/{password}")]
        public IActionResult UserLogin(string username, string password)
        {
            IActionResult response = Unauthorized();

            //Authenticate the user by passing username, password
            Login dbLogin = AuthenticateUser(username, password);

            if (dbLogin != null)
            {
                var tokenString = GenerateJSONWebToken(dbLogin);
                response = Ok(new
                {
                    userName = dbLogin.UserName,
                    userPassword = dbLogin.UserPassword,
                    token = tokenString
                });
            }
            return response;

        }
    }
}
