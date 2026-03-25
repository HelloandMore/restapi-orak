namespace HeroWars.Services;

public class HeroService(AppDbContext dbContext) : IHeroService
{
    private const int ROW_COUNT = 10;

    public async Task<ErrorOr<HeroModel>> CreateAsync(HeroModel model)
    {
        bool exists = await dbContext.Heroes.AnyAsync(x => x.Name.ToLower() == model.Name.ToLower().Trim());

        if (exists)
        {
            return Error.Conflict(description: "Hero with this name already exists!");
        }   

        var hero = model.ToEntity();

        await dbContext.Heroes.AddAsync(hero);
        await dbContext.SaveChangesAsync();

        return new HeroModel(hero);
    }

    public async Task<ErrorOr<Success>> UpdateAsync(HeroModel model)
    {
        var existingHero = await dbContext.Heroes.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (existingHero == null)
        {
            return Error.NotFound(description: "Hero not found.");
        }

        model.ToEntity(existingHero);

        await dbContext.SaveChangesAsync();
        return Result.Success;
    }

    public async Task<ErrorOr<Success>> DeleteAsync(int heroId)
    {
        var result = await dbContext.Heroes
            .Where(x => x.Id == heroId)
            .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<HeroModel>> GetByIdAsync(int heroId)
    {
        var hero = await dbContext.Heroes.FirstOrDefaultAsync(x => x.Id == heroId);

        return hero is null ? (ErrorOr<HeroModel>)Error.NotFound(description: "Hero not found.") : (ErrorOr<HeroModel>)new HeroModel(hero);
    }

    public async Task<ErrorOr<List<HeroModel>>> GetAllAsync() =>
        await dbContext.Heroes
            .AsNoTracking()
            .Select(x => new HeroModel(x))
            .ToListAsync();

    public async Task<ErrorOr<PaginationModel<HeroModel>>> GetPagedAsync(int page = 1)
    {
        page = page < 1 ? 1 : page - 1;

        var totalCount = await dbContext.Heroes.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / ROW_COUNT);

        var heroes = await dbContext.Heroes
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .Skip(page * ROW_COUNT)
            .Take(ROW_COUNT)
            .Select(x => new HeroModel(x))
            .ToListAsync();

        return new PaginationModel<HeroModel>
        {
            Items = heroes,
            Count = totalCount,
            TotalPages = totalPages
        };
    }
}
