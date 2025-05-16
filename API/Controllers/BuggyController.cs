using API.Controllers;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API;

public class BuggyController(DataContext context) : BaseApiController
{
  [Authorize]
  [HttpGet("auth")]
  public ActionResult<string> GetAuth()
  {
    return "secret text";
  }
  [HttpGet("not-found")]
  public ActionResult<AppUser> GetNotFound()
  {
    var element = context.Users.Find(-1);
    if (element == null) return NotFound();

    return element;
  }
  [HttpGet("server-error")]
  public ActionResult<AppUser> GetServerError()
  {
    var element = context.Users.Find(-1) ?? throw new Exception("A bad thing has happened");

    return element;
  }

  [HttpGet("bad-request")]
  public ActionResult<string> GetBadRequest()
  {
    return BadRequest("This was not a good request");
  }

}
