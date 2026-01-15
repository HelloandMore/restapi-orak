

namespace Solution.WebAPI.Controllers;

[ApiController]
//[ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
[ProducesResponseType(statusCode: 400, type: typeof(BadRequestObjectResult))]
public class SecurityController(ISecurityService securityService) : ControllerBase
{
    [HttpPost]
    [Route("api/security/register")]
    [ProducesResponseType(typeof(Success), 200)]
    [EndpointDescription("Registers a new user.")]
    public async Task<IActionResult> RegisterAsync([FromBody] [Required] RegisterRequestModel model)
    {
        var result = await securityService.RegisterAsync(model);
        return result.Match(
          value => Ok(value),
          errors => errors.ToProblemResult()
        );
    }

    [HttpPost]
    [Route("api/security/login")]
    [ProducesResponseType(typeof(TokenResponseModel), 200)]
    [EndpointDescription("Logs in a user and returns a JWT token.")]
    public async Task<IActionResult> LoginAsync([FromBody] [Required] LoginRequestModel model)
    {
        var result = await securityService.LoginAsync(model);
        return result.Match(
          value => Ok(value),
          errors => errors.ToProblemResult()
        );
    }
}
