namespace HeroWars.Services.Interfaces;

public interface IHeroService
{
    Task<ErrorOr<HeroModel>> CreateAsync(HeroModel model);
    Task<ErrorOr<Success>> UpdateAsync(HeroModel model);
    Task<ErrorOr<Success>> DeleteAsync(int heroId);
    Task<ErrorOr<HeroModel>> GetByIdAsync(int heroId);
    Task<ErrorOr<List<HeroModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<HeroModel>>> GetPagedAsync(int page = 1);
}
