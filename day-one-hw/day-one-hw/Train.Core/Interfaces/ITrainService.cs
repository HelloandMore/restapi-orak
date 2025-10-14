namespace Train.Core.Interfaces;

public interface ITrainService
{
    Task<ErrorOr<TrainModel>> CreateAsync(TrainModel model);
    Task<ErrorOr<Success>> UpdateAsync(TrainModel model);
    Task<ErrorOr<Success>> DeleteAsync(string trainId);
    Task<ErrorOr<TrainModel>> GetByIdAsync(string trainId);
    Task<ErrorOr<List<TrainModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<TrainModel>>> GetPagedAsync(int page = 0);
}