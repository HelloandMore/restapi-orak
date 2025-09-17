namespace Solution.Api.Controllers;

public class MotorcycleController(IMotorcycleService motorcycleService): ControllerBase
{
    [HttpGet]
    [Route("api/motorcycle/all")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        return Ok(await motorcycleService.GetAllAsync());
    }
}
