namespace Train.PdfGenerator;

public class PdfGeneratorService : IPdfGeneratorService
{
    public async Task<ErrorOr<byte[]>> GenerateTrainReportAsync(TrainModel train)
    {
        // Simplified PDF generation - in real implementation you would use a PDF library
        var content = $@"
TRAIN REPORT
============

Name: {train.Name}
Type: {train.Type}
Build Date: {train.BuildDate}
Max Speed: {train.MaxSpeed} km/h
Weight: {train.Weight} tons
Length: {train.Length} m
Gauge: {train.Gauge} mm
Power: {train.Power} kW

Generated: {DateTime.Now:yyyy-MM-dd HH:mm}
";

        var bytes = System.Text.Encoding.UTF8.GetBytes(content);
        return await Task.FromResult<ErrorOr<byte[]>>(bytes);
    }

    public async Task<ErrorOr<byte[]>> GenerateTrainsListAsync(List<TrainModel> trains)
    {
        var content = "TRAINS LIST\n===========\n\n";

        foreach (var train in trains)
        {
            content += $"- {train.Name} ({train.Type}) - {train.BuildDate}\n";
        }

        content += $"\nTotal: {trains.Count} trains\n";
        content += $"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}\n";

        var bytes = System.Text.Encoding.UTF8.GetBytes(content);
        return await Task.FromResult<ErrorOr<byte[]>>(bytes);
    }
}