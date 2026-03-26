namespace StarWarsApi.Controllers
{
    [ApiController]
    public class CharacterController(AppDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        [Route("/api/characters")]
        public async Task<ActionResult<List<CharacterModel>>> GetAllAsync()
        {
            var result = await dbContext
                .Characters.AsNoTracking()
                .Select(x => new CharacterModel(x))
                .ToListAsync();
            if (result.Count == 0)
            {
                return NotFound("No characters found.");
            }
            return result;
        }

        [HttpGet]
        [Route("/api/character/{id}")]
        public async Task<ActionResult<CharacterModel>> GetByIdAsync([FromRoute][Required] int id)
        {
            var result = await dbContext.Characters.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return NotFound($"Character with id '{id}' not found.");
            }
            return new CharacterModel(result);
        }

        [HttpPost]
        [Route("api/character")]
        public async Task<ActionResult<CharacterModel>> CreateAsync([FromBody][Required] CharacterModel model)
        {
            bool exists = await dbContext.Characters.AnyAsync(x => x.Name == model.Name);

            if (exists)
            {
                return Conflict($"Character with name '{model.Name}' already exists.");
            }

            var entity = model.ToEntity();

            await dbContext.Characters.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return new CharacterModel(entity);
        }

        [HttpPut]
        [Route("api/character/{id}")]
        public async Task<ActionResult<CharacterModel>> UpdateAsync(
            [FromBody][Required] CharacterModel model,
            [FromRoute][Required] int id
        )
        {
            var entity = await dbContext.Characters.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound("Character not found!");
            }

            entity.Name = model.Name;
            entity.OrderType = model.OrderType;
            entity.Species = model.Species;
            entity.Homeworld = model.Homeworld;
            entity.Era = model.Era;
            entity.Rank = model.Rank;
            entity.LightsaberColor = model.LightsaberColor;
            entity.Master = model.Master;
            entity.Apprentice = model.Apprentice;
            entity.ForceSpecialty = model.ForceSpecialty;
            entity.IsAlive = model.IsAlive;

            dbContext.Characters.Attach(entity);

            await dbContext.SaveChangesAsync();

            return new CharacterModel(entity);
        }

        [HttpDelete]
        [Route("api/character/{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute][Required] int id)
        {
            var result = await dbContext
                .Characters.AsNoTracking()
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if (result != 1)
            {
                return Conflict("Error during delete");
            }
            return Ok("Character deleted");
        }
    }
}

