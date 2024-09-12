using System;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers;
/*
[ApiController]
[Route("api/[controller]")] //api/users
public class UsersController : ControllerBase
{
    private readonly DataContext _context;
    //inject the dbcontext to the constructor of this controller
    public UsersController(DataContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
        var users = await _context.Users.ToListAsync();
        return users;
    }

    [Route("{id:int}")]
    [HttpGet]
    public async Task<ActionResult<AppUser>> GetUser(int id){
        var user = await _context.Users.FindAsync(id);
        if(user == null){
            return NotFound();
        }
        else{
            return user;
        }
    }
}
*/