namespace HeroWars.Services.Models;

public class HeroModel
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public HeroRole Role { get; set; }
    public int Intelligence { get; set; }
    public int Agility { get; set; }
    public int Strength { get; set; }
    public int Health { get; set; }
    public int PhysicalAttack { get; set; }
    public int MagicAttack { get; set; }
    public int Armor { get; set; }
    public int MagicDefense { get; set; }
    public int MagicPenetration { get; set; }
    public int ArmorPenetration { get; set; }

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
            Name = Name,
            Role = Role,
            Intelligence = Intelligence,
            Agility = Agility,
            Strength = Strength,
            Health = Health,
            PhysicalAttack = PhysicalAttack,
            MagicAttack = MagicAttack,
            Armor = Armor,
            MagicDefense = MagicDefense,
            MagicPenetration = MagicPenetration,
            ArmorPenetration = ArmorPenetration
        };
    }

    public void ToEntity(HeroEntity entity)
    {
        entity.Name = Name;
        entity.Role = Role;
        entity.Intelligence = Intelligence;
        entity.Agility = Agility;
        entity.Strength = Strength;
        entity.Health = Health;
        entity.PhysicalAttack = PhysicalAttack;
        entity.MagicAttack = MagicAttack;
        entity.Armor = Armor;
        entity.MagicDefense = MagicDefense;
        entity.MagicPenetration = MagicPenetration;
        entity.ArmorPenetration = ArmorPenetration;
    }
}
