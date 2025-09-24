using Microsoft.AspNetCore.Mvc;
using TomAuthApi.src.Application.Dtos;
using TomAuthApi.src.Application.Interfaces;

namespace TomAuthApi.src.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: BaseController
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            return Ok(await _service.GetAll());
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [HttpGet("[Action]/{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        try
        {
            return Ok(await _service.GetById(id));
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [HttpGet("[Action]/{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        try
        {
            return Ok(await _service.GetByEmail(email));
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateDto user)
    {
        try
        {
            return Ok(await _service.Post(user));
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [HttpPut("[Action]/{id}")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] UserUpdateDto user)
    {
        try
        {
            return Ok(await _service.Put(id, user));
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }

    [HttpDelete("[Action]/{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        try
        {
            return Ok(await _service.DeleteById(id));
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }
}
