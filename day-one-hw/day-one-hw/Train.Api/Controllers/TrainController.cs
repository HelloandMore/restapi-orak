namespace Train.Api.Controllers;

[Route("api/[controller]")]
public class TrainController(ITrainService trainService) : BaseController
{
    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await trainService.GetAllAsync();
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("page/{page}")]
    public async Task<IActionResult> GetPagedAsync([FromRoute][Required] int page = 1)
    {
        var result = await trainService.GetPagedAsync(page);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] string id)
    {
        var result = await trainService.GetByIdAsync(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] string id)
    {
        var result = await trainService.DeleteAsync(id);
        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody][Required] TrainModel model)
    {
        var result = await trainService.CreateAsync(model);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] TrainModel model)
    {
        var result = await trainService.UpdateAsync(model);
        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }
}