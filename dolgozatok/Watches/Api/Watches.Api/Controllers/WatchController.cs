namespace Api.Controllers;

[ApiController]
public class WatchController(AppDbContext dbContext) : ControllerBase
{
	[HttpGet]
	[Route("/api/watches")]
	public async Task<ActionResult<List<WatchModel>>> GetAllAsync()
	{
		var result = await dbContext.Watches
			.AsNoTracking()
			.Select(w => new WatchModel(w))
			.ToListAsync();

		if (result.Count == 0)
			return NotFound("No watches found.");

		return Ok(result);
	}

	[HttpGet]
	[Route("/api/watch/{id}")]
	public async Task<ActionResult<WatchModel>> GetByIdAsync([FromRoute][Required] int id)
	{
		var entity = await dbContext.Watches.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		if (entity == null)
			return NotFound($"Watch with id '{id}' not found.");
		return new WatchModel(entity);
	}

	[HttpPost]
	[Route("/api/watch")]
	public async Task<ActionResult<WatchModel>> CreateAsync([FromBody][Required] WatchModel model)
	{
		bool exists = await dbContext.Watches.AnyAsync(x => x.Manufacturer == model.Manufacturer && x.Model == model.Model && x.ReleaseYear == model.ReleaseYear);
		if (exists)
			return Conflict("A watch with the same manufacturer, model, and release year already exists.");

		var entity = model.ToEntity();
		await dbContext.Watches.AddAsync(entity);
		await dbContext.SaveChangesAsync();

		return new WatchModel(entity);
	}

	[HttpPut]
	[Route("/api/watch/{id}")]
	public async Task<ActionResult<WatchModel>> UpdateAsync([FromBody][Required] WatchModel model, [FromRoute][Required] int id)
	{
		var entity = await dbContext.Watches.FirstOrDefaultAsync(x => x.Id == id);
		if (entity == null)
			return NotFound("Watch not found.");

		entity.Manufacturer = model.Manufacturer;
		entity.Model = model.Model;
		entity.ReleaseYear = model.ReleaseYear;
		entity.Type = model.Type;
		entity.Movement = model.Movement;
		entity.WaterResistanceM = model.WaterResistanceM;
		entity.CaseMaterial = model.CaseMaterial;
		entity.Functions = model.Functions;
		entity.Category = model.Category;

		dbContext.Watches.Attach(entity);
		await dbContext.SaveChangesAsync();

		return new WatchModel(entity);
	}

	[HttpDelete]
	[Route("/api/watch/{id}")]
	public async Task<ActionResult> DeleteAsync([FromRoute][Required] int id)
	{
		var deleted = await dbContext.Watches.AsNoTracking().Where(x => x.Id == id).ExecuteDeleteAsync();
		if (deleted != 1)
			return Conflict("Error during delete");
		return Ok("Watch deleted");
	}
}