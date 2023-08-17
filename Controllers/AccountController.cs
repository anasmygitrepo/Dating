

using System.Security.Cryptography;
using System.Text;
using API.Dtos;
using Date.ApiDtos;
using Date.Data;
using Date.Interfaces;
using Date.Models;
using Date.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Date.Controllers
{
  
    public class AccountController:BaseApiController
    {
        public DataContext _context { get; }
        private readonly ITokenService _tokenservice;
        public AccountController(DataContext context,ITokenService tokenservice)
        {
            _tokenservice = tokenservice;
            _context = context;
        }

        [HttpPost("register")]
        public async  Task<ActionResult<UserDto>> Register(RegisterDto Dto)
        {
            if(await IsUserExist(Dto.username))return BadRequest("User Name is already taken");

            using var hmac= new HMACSHA512();

            var user= new AppUser()
            {
                UserName=Dto.username.ToLower(),
                PassWordHash= hmac.ComputeHash (Encoding.UTF8.GetBytes(Dto.password)),
                PassWordSalt=hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new UserDto
            {
                UserName=user.UserName,
                Token=_tokenservice.CreatToken(user)
            };

        }

        private async Task<bool> IsUserExist(string username)
        {
            return await _context.Users.AnyAsync(x=>x.UserName==username.ToLower());

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> UserLogin(LoginDto Dto)
        {
            
           
            var user= await _context.Users.SingleOrDefaultAsync(x=>x.UserName==Dto.username);
            if(user==null)return Unauthorized("Invalid Username");

           using var hmac= new HMACSHA512(user.PassWordSalt);
           var computedhash= hmac.ComputeHash (Encoding.UTF8.GetBytes(Dto.password));

            for(int i = 0 ;i < computedhash.Length ;i++)
            {
                if(computedhash[i]!=user.PassWordHash[i])return Unauthorized("Invalid password");
            }

            return new UserDto
            {
                UserName=user.UserName,
                Token=_tokenservice.CreatToken(user)
            };

        }

    }    

}