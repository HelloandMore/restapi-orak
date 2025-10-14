namespace Train.Services;

public class TrainService(AppDbContext dbContext) : ITrainService
{
    private const int ROW_COUNT = 10;

    public async Task<ErrorOr<TrainModel>> CreateAsync(TrainModel model)
    {
        bool exists = await dbContext.Trains.AnyAsync(x => x.Name.ToLower() == model.Name.ToLower().Trim() &&
                                                            x.BuildDate == model.BuildDate.Value);

        if (exists)
        {
            return Error.Conflict(description: "Train already exists!");
        }

        var train = model.ToEntity();
        train.PublicId = Guid.NewGuid().ToString();

        await dbContext.Trains.AddAsync(train);
        await dbContext.SaveChangesAsync();

        return new TrainModel(train);
    }

    public async Task<ErrorOr<Success>> UpdateAsync(TrainModel model)
    {
        var result = await dbContext.Trains.AsNoTracking()
                                           .Where(x => x.PublicId == model.Id)
                                           .ExecuteUpdateAsync(x => x.SetProperty(p => p.PublicId, model.Id)
                                                                     .SetProperty(p => p.Name, model.Name)
                                                                     .SetProperty(p => p.Type, model.Type)
                                                                     .SetProperty(p => p.BuildDate, model.BuildDate.Value)
                                                                     .SetProperty(p => p.MaxSpeed, model.MaxSpeed.Value)
                                                                     .SetProperty(p => p.Weight, model.Weight.Value)
                                                                     .SetProperty(p => p.Length, model.Length.Value)
                                                                     .SetProperty(p => p.Gauge, model.Gauge.Value)
                                                                     .SetProperty(p => p.Power, model.Power.Value)
                                                                     .SetProperty(p => p.ImageId, model.ImageId)
                                                                     .SetProperty(p => p.WebContentLink, model.WebContentLink));
        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<Success>> DeleteAsync(string trainId)
    {
        var result = await dbContext.Trains.AsNoTracking()
                                           .Where(x => x.PublicId == trainId)
                                           .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<TrainModel>> GetByIdAsync(string trainId)
    {
        var train = await dbContext.Trains.FirstOrDefaultAsync(x => x.PublicId == trainId);

        if (train is null)
        {
            return Error.NotFound(description: "Train not found.");
        }

        return new TrainModel(train);
    }

    public async Task<ErrorOr<List<TrainModel>>> GetAllAsync() =>
        await dbContext.Trains.AsNoTracking()
                              .Select(x => new TrainModel(x))
                              .ToListAsync();

    public async Task<ErrorOr<PaginationModel<TrainModel>>> GetPagedAsync(int page = 1)
    {
        page = page < 1 ? 1 : page - 1;

        var trains = await dbContext.Trains.AsNoTracking()
                                           .Skip(page * ROW_COUNT)
                                           .Take(ROW_COUNT)
                                           .Select(x => new TrainModel(x))
                                           .ToListAsync();

        var paginationModel = new PaginationModel<TrainModel>
        {
            Items = trains,
            Count = await dbContext.Trains.CountAsync()
        };

        return paginationModel;
    }
}