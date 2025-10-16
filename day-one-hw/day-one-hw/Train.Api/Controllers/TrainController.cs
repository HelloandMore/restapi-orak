namespace Train.Api.Controllers;

public class TrainController(ITrainService trainService) : BaseController
{
    [HttpGet]
    [Route("api/train/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await trainService.GetAllAsync();
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/train/page/{page}")]
    public async Task<IActionResult> GetPagedAsync([FromRoute][Required] int page = 1)
    {
        var result = await trainService.GetPagedAsync(page);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/train/id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] string id)
    {
        var result = await trainService.GetByIdAsync(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/train/delete/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] string id)
    {
        var result = await trainService.DeleteAsync(id);
        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/train/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] TrainModel model)
    {
        var result = await trainService.CreateAsync(model);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/train/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] TrainModel model)
    {
        var result = await trainService.UpdateAsync(model);
        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }
}