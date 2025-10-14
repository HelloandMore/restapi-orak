namespace Train.Core.Models;

public partial class TrainModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private string id;

    [ObservableProperty]
    [JsonPropertyName("imageId")]
    private string imageId;

    [ObservableProperty]
    [JsonPropertyName("webContentLink")]
    private string webContentLink;

    [ObservableProperty]
    [JsonPropertyName("name")]
    private string name;

    [ObservableProperty]
    [JsonPropertyName("type")]
    private string type;

    [ObservableProperty]
    [JsonPropertyName("buildDate")]
    private int? buildDate;

    [ObservableProperty]
    [JsonPropertyName("maxSpeed")]
    private int? maxSpeed;

    [ObservableProperty]
    [JsonPropertyName("weight")]
    private float? weight;

    [ObservableProperty]
    [JsonPropertyName("length")]
    private float? length;

    [ObservableProperty]
    [JsonPropertyName("gauge")]
    private float? gauge;

    [ObservableProperty]
    [JsonPropertyName("power")]
    private float? power;

    public TrainModel()
    {
    }

    public TrainModel(TrainEntity entity)
    {
        this.Id = entity.PublicId;
        this.ImageId = entity.ImageId;
        this.WebContentLink = entity.WebContentLink;
        this.Name = entity.Name;
        this.Type = entity.Type;
        this.BuildDate = entity.BuildDate;
        this.MaxSpeed = entity.MaxSpeed;
        this.Weight = entity.Weight;
        this.Length = entity.Length;
        this.Gauge = entity.Gauge;
        this.Power = entity.Power;
    }

    public TrainEntity ToEntity()
    {
        return new TrainEntity
        {
            PublicId = Id,
            ImageId = ImageId,
            WebContentLink = WebContentLink,
            Name = Name,
            Type = Type,
            BuildDate = BuildDate.Value,
            MaxSpeed = MaxSpeed.Value,
            Weight = Weight.Value,
            Length = Length.Value,
            Gauge = Gauge.Value,
            Power = Power.Value
        };
    }

    public void ToEntity(TrainEntity entity)
    {
        entity.PublicId = Id;
        entity.ImageId = ImageId;
        entity.WebContentLink = WebContentLink;
        entity.Name = Name;
        entity.Type = Type;
        entity.BuildDate = BuildDate.Value;
        entity.MaxSpeed = MaxSpeed.Value;
        entity.Weight = Weight.Value;
        entity.Length = Length.Value;
        entity.Gauge = Gauge.Value;
        entity.Power = Power.Value;
    }
}