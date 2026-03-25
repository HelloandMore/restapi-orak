using System.ComponentModel.DataAnnotations;
using StarWarsDatabase.Entities;
using StarWarsDatabase.Enums;

namespace StarWarsDatabase.Models
{
    public class CharacterModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public OrderEnum OrderType { get; set; }

        public string Species { get; set; }

        public string Homeworld { get; set; }

        public EraEnum Era { get; set; }

        public RankEnum Rank { get; set; }

        public string LightsaberColor { get; set; }

        public string Master { get; set; }

        public string Apprentice { get; set; }

        public string ForceSpecialty { get; set; }

        public bool IsAlive { get; set; }

        public CharacterModel() { }

        public CharacterModel(CharacterEntity entity)
        {
            if (entity is null)
            {
                return;
            }

            Id = entity.Id;
            Name = entity.Name;
            OrderType = entity.OrderType;
            Species = entity.Species;
            Homeworld = entity.Homeworld;
            Era = entity.Era;
            Rank = entity.Rank;
            LightsaberColor = entity.LightsaberColor;
            Master = entity.Master;
            Apprentice = entity.Apprentice;
            ForceSpecialty = entity.ForceSpecialty;
            IsAlive = entity.IsAlive;
        }

        public CharacterEntity ToEntity()
        {
            return new CharacterEntity
            {
                Id = Id,
                Name = Name,
                OrderType = OrderType,
                Species = Species,
                Homeworld = Homeworld,
                Era = Era,
                Rank = Rank,
                LightsaberColor = LightsaberColor,
                Master = Master,
                Apprentice = Apprentice,
                ForceSpecialty = ForceSpecialty,
                IsAlive = IsAlive
            };
        }

        public void ToEntity(CharacterEntity entity)
        {
            entity.Id = Id;
            entity.Name = Name;
            entity.OrderType = OrderType;
            entity.Species = Species;
            entity.Homeworld = Homeworld;
            entity.Era = Era;
            entity.Rank = Rank;
            entity.LightsaberColor = LightsaberColor;
            entity.Master = Master;
            entity.Apprentice = Apprentice;
            entity.ForceSpecialty = ForceSpecialty;
            entity.IsAlive = IsAlive;
        }
    }
}
