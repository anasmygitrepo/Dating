using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Date.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Date.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;

        }

       [HttpGet("Users")]
       public async Task <ActionResult<IEnumerable<Models.AppUser>>> GetUsers()
       {
            var users=await _context.Users.ToListAsync();
            return users;
       } 

       [HttpGet("Users/{id}")]
       public async Task<ActionResult<Models.AppUser>> Getuser(int id)
       {
            var user=await _context.Users.FindAsync(id);
            return user;
       }
    }
}