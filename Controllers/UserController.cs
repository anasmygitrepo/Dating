using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Date.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Date.Controllers
{
     [Authorize]
    public class UserController : BaseApiController
    {
       
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;

        }

       [HttpGet("users")]
       public async Task <ActionResult<IEnumerable<Models.AppUser>>> GetUsers()
       {
            var users=await _context.Users.ToListAsync();
            return users;
       } 

       [HttpGet("user/{id}")]
       public async Task<ActionResult<Models.AppUser>> Getuser(int id)
       {
            var user=await _context.Users.FindAsync(id);
            return user;
       }
    }
}