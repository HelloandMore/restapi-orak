namespace Solution.Domain.Database.Builders;

internal static class UserEntityModeBuilder
{
    public static void ConfigureUser(this ModelBuilder builder)
    {
        builder.Entity<UserEntity>(entity =>
        {
            entity.ToTable("Users");
            entity.HasIndex(x => x.Id)
                  .IsUnique();

            entity.Property(x => x.FullName)
                  .HasColumnName("FullName")
                  .HasMaxLength(255)
                  .IsRequired();
            entity.Property(x => x.RegisteredUtc)
                  .HasColumnName("RegisteredUtc")
                  .IsRequired();
        }
        );
    }
}
