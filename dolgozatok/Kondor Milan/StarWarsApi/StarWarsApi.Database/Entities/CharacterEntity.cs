using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarWarsDatabase.Enums;

namespace StarWarsDatabase.Entities
{
    [Table("Character")]
    public class CharacterEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public OrderEnum OrderType { get; set; }

        public string Species { get; set; }

        public string Homeworld { get; set; }

        [Required]
        public EraEnum Era { get; set; }

        [Required]
        public RankEnum Rank { get; set; }

        public string LightsaberColor { get; set; }

        public string Master { get; set; }

        public string Apprentice { get; set; }

        public string ForceSpecialty { get; set; }

        public bool IsAlive { get; set; }
    }
}
