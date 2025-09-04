using System.Text.Json.Serialization;

namespace day_one.Models;

public class MotorcycleUpdateModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}
