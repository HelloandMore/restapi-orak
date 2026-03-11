using System.ComponentModel.DataAnnotations;

namespace HeroWars.API.Controllers;

public class HeroController(IHeroService heroService) : BaseController
{
    [HttpGet]
    [Route("api/hero/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await heroService.GetAllAsync();
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/hero/page/{page}")]
    public async Task<IActionResult> GetPagedAsync([FromRoute][Required] int page = 1)
    {
        var result = await heroService.GetPagedAsync(page);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/hero/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await heroService.GetByIdAsync(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/hero/delete/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] int id)
    {
        var result = await heroService.DeleteAsync(id);
        return result.Match(
            result => Ok(true),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/hero/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] HeroModel model)
    {
        var result = await heroService.CreateAsync(model);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/hero/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] HeroModel model)
    {
        var result = await heroService.UpdateAsync(model);
        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }
}
