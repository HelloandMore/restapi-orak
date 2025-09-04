using System.Text.Json.Serialization;

namespace day_one_hw.Entities;

public class TrainUpdateModel
{

	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("type")]
	public string Type { get; set; }

	[JsonPropertyName("build_date")]
	public int BuildDate { get; set; }

	[JsonPropertyName("max_speed")]
	public int MaxSpeed { get; set; }

	[JsonPropertyName("weight")]
	public float Weight { get; set; }

	[JsonPropertyName("length")]
	public float Length { get; set; }

	[JsonPropertyName("gauge")]
	public float Gauge { get; set; }

	[JsonPropertyName("power")]
	public float Power { get; set; }
}