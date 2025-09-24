namespace Solution.Api.Controllers;

public class TypeController(ITypeService TypeService) : BaseController
{
    [HttpGet]
    [Route("api/type/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await TypeService.GetAllAsync();
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/type/page/{page}")]
    public async Task<IActionResult> GetPagedAsync([FromRoute][Required] int page = 0)
    {
        var result = await TypeService.GetPagedAsync(page);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/type/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await TypeService.GetByIdAsync(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/type/delete/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] int id)
    {
        var result = await TypeService.DeleteAsync(id);
        return result.Match(
            result => Ok(true),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/type/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] TypeModel model)
    {
        var result = await TypeService.CreateAsync(model);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
    [HttpPut]
    [Route("api/type/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] TypeModel model)
    {
        var result = await TypeService.UpdateAsync(model);
        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }
}
