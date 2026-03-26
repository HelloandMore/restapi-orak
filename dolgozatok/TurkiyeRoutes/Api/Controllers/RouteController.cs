namespace Api.Controllers;

[ApiController]
public class RouteController(AppDbContext dbContext) : ControllerBase
{
	[HttpGet]
	[Route("/api/routes")]
	public async Task<ActionResult<List<RouteModel>>> GetAllAsync()
	{
		var result = await dbContext.Routes
			.AsNoTracking()
			.Select(r => new RouteModel(r))
			.ToListAsync();

		if (result.Count == 0)
			return NotFound("No routes found.");

		return Ok(result);
	}

	[HttpGet]
	[Route("/api/route/{id}")]
	public async Task<ActionResult<RouteModel>> GetByIdAsync([FromRoute][Required] int id)
	{
		var entity = await dbContext.Routes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		if (entity == null)
			return NotFound($"Route with id '{id}' not found.");
		return new RouteModel(entity);
	}

	[HttpPost]
	[Route("/api/route")]
	public async Task<ActionResult<RouteModel>> CreateAsync([FromBody][Required] RouteModel model)
	{
		bool exists = await dbContext.Routes.AnyAsync(x => x.DepartureCity == model.DepartureCity && x.ArrivalCity == model.ArrivalCity && x.DepartureHour == model.DepartureHour && x.DepartureMinute == model.DepartureMinute);
		if (exists)
			return Conflict("A route with the same departure/arrival and departure time already exists.");

		var entity = model.ToEntity();
		await dbContext.Routes.AddAsync(entity);
		await dbContext.SaveChangesAsync();

		return new RouteModel(entity);
	}

	[HttpPut]
	[Route("/api/route/{id}")]
	public async Task<ActionResult<RouteModel>> UpdateAsync([FromBody][Required] RouteModel model, [FromRoute][Required] int id)
	{
		var entity = await dbContext.Routes.FirstOrDefaultAsync(x => x.Id == id);
		if (entity == null)
			return NotFound("Route not found.");

		entity.DepartureCity = model.DepartureCity;
		entity.ArrivalCity = model.ArrivalCity;
		entity.DepartureHour = model.DepartureHour;
		entity.DepartureMinute = model.DepartureMinute;
		entity.ArrivalHour = model.ArrivalHour;
		entity.ArrivalMinute = model.ArrivalMinute;
		entity.DistanceKm = model.DistanceKm;

		dbContext.Routes.Attach(entity);
		await dbContext.SaveChangesAsync();

		return new RouteModel(entity);
	}

	[HttpDelete]
	[Route("/api/route/{id}")]
	public async Task<ActionResult> DeleteAsync([FromRoute][Required] int id)
	{
		var deleted = await dbContext.Routes.AsNoTracking().Where(x => x.Id == id).ExecuteDeleteAsync();
		if (deleted != 1)
			return Conflict("Error during delete");
		return Ok("Route deleted");
	}
}
