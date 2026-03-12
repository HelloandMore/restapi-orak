namespace HeroWars.Services.Models;

public class HeroModel
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public HeroRole? Role { get; set; }
    public int? Intelligence { get; set; }
    public int? Agility { get; set; }
    public int? Strength { get; set; }
    public int? Health { get; set; }
    public int? PhysicalAttack { get; set; }
    public int? MagicAttack { get; set; }
    public int? Armor { get; set; }
    public int? MagicDefense { get; set; }
    public int? MagicPenetration { get; set; }
    public int? ArmorPenetration { get; set; }

    public HeroModel() { }

    public HeroModel(HeroEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Role = entity.Role;
        Intelligence = entity.Intelligence;
        Agility = entity.Agility;
        Strength = entity.Strength;
        Health = entity.Health;
        PhysicalAttack = entity.PhysicalAttack;
        MagicAttack = entity.MagicAttack;
        Armor = entity.Armor;
        MagicDefense = entity.MagicDefense;
        MagicPenetration = entity.MagicPenetration;
        ArmorPenetration = entity.ArmorPenetration;
    }

    public HeroEntity ToEntity()
    {
        return new HeroEntity
        {
            Name = Name ?? string.Empty,
            Role = Role ?? default,
            Intelligence = Intelligence ?? 0,
            Agility = Agility ?? 0,
            Strength = Strength ?? 0,
            Health = Health ?? 0,
            PhysicalAttack = PhysicalAttack ?? 0,
            MagicAttack = MagicAttack ?? 0,
            Armor = Armor ?? 0,
            MagicDefense = MagicDefense ?? 0,
            MagicPenetration = MagicPenetration ?? 0,
            ArmorPenetration = ArmorPenetration ?? 0
        };
    }

    public void ToEntity(HeroEntity entity)
    {
        if (Name != null) entity.Name = Name;
        if (Role.HasValue) entity.Role = Role.Value;
        if (Intelligence.HasValue) entity.Intelligence = Intelligence.Value;
        if (Agility.HasValue) entity.Agility = Agility.Value;
        if (Strength.HasValue) entity.Strength = Strength.Value;
        if (Health.HasValue) entity.Health = Health.Value;
        if (PhysicalAttack.HasValue) entity.PhysicalAttack = PhysicalAttack.Value;
        if (MagicAttack.HasValue) entity.MagicAttack = MagicAttack.Value;
        if (Armor.HasValue) entity.Armor = Armor.Value;
        if (MagicDefense.HasValue) entity.MagicDefense = MagicDefense.Value;
        if (MagicPenetration.HasValue) entity.MagicPenetration = MagicPenetration.Value;
        if (ArmorPenetration.HasValue) entity.ArmorPenetration = ArmorPenetration.Value;
    }
}
