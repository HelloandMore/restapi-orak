namespace Solution.WebAPI.Controllers;

[ApiController]
[ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    [Route("api/users")]
    [Authorize]
    public async Task<IActionResult> GetUsersAsync()
    {
        var result = await userService.GetAllUsers();
        return result.Match(
          value => Ok(value),
          errors => errors.ToProblemResult()
        );
    }
}
