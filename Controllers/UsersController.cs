using Exploration.Interfaces;
using Exploration.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exploration.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsers _userService;

    public UsersController(IUsers userService)
    {
        _userService = userService;
    }


    [HttpGet]
    public IActionResult GetUsers()
    {
        List<User> users = _userService.GetUsers();
        return Ok(users);

        //List<Movie> items = collection.Find(item => true).ToList();
        //return Ok(items);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = _userService.GetUser(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        bool isCreated = _userService.CreateUser(user);

        if (isCreated)
        {
            return Ok(user);
        }

        return BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        User? updatedUser = _userService.UpdateUser(id, user);

        if (updatedUser == null)
        {
            return NotFound(id);
        }

        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        bool isDeleted = _userService.DeleteUser(id);

        if (isDeleted)
        {
            return Ok($"user deleted with id: {id}");
        }

        return BadRequest();
    }
}