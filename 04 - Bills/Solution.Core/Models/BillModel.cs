namespace Solution.Core.Models;

public partial class BillModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    public int? id;

    [ObservableProperty]
    [JsonPropertyName("billNumber")]
    public string billNumber;

    [ObservableProperty]
    [JsonPropertyName("billDate")]
    public DateTime? billDate = DateTime.Now;

    [ObservableProperty]
    [JsonPropertyName("items")]
    public List<BillItemModel> items = new List<BillItemModel>();

    [JsonPropertyName("totalAmount")]
    public decimal TotalAmount => Items?.Sum(item => item.TotalPrice ?? 0) ?? 0;

    public BillModel()
    {
    }

    public BillModel(BillEntity entity)
    {
        this.Id = entity.Id;
        this.BillNumber = entity.BillNumber;
        this.BillDate = entity.BillDate;
        this.Items = entity.Items?.Select(i => new BillItemModel(i)).ToList() ?? new List<BillItemModel>();
    }

    public BillEntity ToEntity()
    {
        return new BillEntity
        {
            BillNumber = BillNumber,
            BillDate = BillDate.Value,
            Items = Items?.Select(i => i.ToEntity()).ToList()
        };
    }

    public void ToEntity(BillEntity entity)
    {
        entity.BillNumber = BillNumber;
        entity.BillDate = BillDate.Value;
    }
}
