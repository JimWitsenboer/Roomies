using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.DTOs;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository) : BaseApiController
{
  [HttpGet]
  public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
  {
    var users = await userRepository.GetMembersAsync();
    return Ok(users);
  }

  [HttpGet("{username}")]
  public async Task<ActionResult<MemberDto>> GetUser(string username)
  {
    var user = await userRepository.GetMemberAsync(username);

    if (user == null) return NotFound();

    return user;
  }
}
