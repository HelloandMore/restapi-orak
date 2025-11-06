namespace Solution.Database.Entities;

[Table("BillItem")]
public class BillItemEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(256)]
    [Required]
    public string ItemName { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    [ForeignKey("Bill")]
    public int BillId { get; set; }
    public virtual BillEntity Bill { get; set; }
}
