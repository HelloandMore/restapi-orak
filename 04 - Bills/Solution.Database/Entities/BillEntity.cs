namespace Solution.Database.Entities;

[Table("Bill")]
public class BillEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(128)]
    [Required]
    public string BillNumber { get; set; }

    [Required]
    public DateTime BillDate { get; set; }

    public virtual ICollection<BillItemEntity> Items { get; set; }
}
