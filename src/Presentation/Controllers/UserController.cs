using Microsoft.AspNetCore.Mvc;
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
            return Ok(await _service.GetAllUsers());
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
            return Ok(await _service.GetUserById(id));
        }
        catch (Exception ex)
        {
            return Error(ex);
        }
    }
}
