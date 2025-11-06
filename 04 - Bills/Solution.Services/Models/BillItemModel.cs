namespace Solution.Services.Models;

public partial class BillItemModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    public int? id;

    [ObservableProperty]
    [JsonPropertyName("itemName")]
    public string itemName;

    [ObservableProperty]
    [JsonPropertyName("quantity")]
    public int? quantity;

    [ObservableProperty]
    [JsonPropertyName("unitPrice")]
    public decimal? unitPrice;

    [JsonPropertyName("totalPrice")]
    public decimal? TotalPrice => Quantity.HasValue && UnitPrice.HasValue ? Quantity.Value * UnitPrice.Value : null;

    public BillItemModel()
    {
    }

    public BillItemModel(BillItemEntity entity)
    {
        this.Id = entity.Id;
        this.ItemName = entity.ItemName;
        this.Quantity = entity.Quantity;
        this.UnitPrice = entity.UnitPrice;
    }

    public BillItemEntity ToEntity()
    {
        return new BillItemEntity
        {
            ItemName = ItemName,
            Quantity = Quantity.Value,
            UnitPrice = UnitPrice.Value
        };
    }

    public void ToEntity(BillItemEntity entity)
    {
        entity.ItemName = ItemName;
        entity.Quantity = Quantity.Value;
        entity.UnitPrice = UnitPrice.Value;
    }
}
