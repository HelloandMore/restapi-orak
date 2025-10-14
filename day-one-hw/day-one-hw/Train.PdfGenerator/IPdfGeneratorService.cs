namespace Train.PdfGenerator;

public interface IPdfGeneratorService
{
    Task<ErrorOr<byte[]>> GenerateTrainReportAsync(TrainModel train);
    Task<ErrorOr<byte[]>> GenerateTrainsListAsync(List<TrainModel> trains);
}