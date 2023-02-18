using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialApp.Domain.User;
using SocialApp.Domain.User.ValueObjects;
using SocialApp.Persistence.Context;

namespace SocialApp.Persistence.EntityConfigurations;
public sealed class UserTypeConfiguration : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
        builder.ToTable("Users", SocialAppDbContext.DEFAULT_SCHEMA);
        ConfigureUsersTable(builder);
    }

    private void ConfigureUsersTable(EntityTypeBuilder<User> builder) {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique(true);
        builder.Property(x => x.Id)
               .IsRequired(true)
               .ValueGeneratedNever()
               .HasConversion(
                    userId => userId.Value,
                    value => UserId.Create(value));

        builder.Property(x => x.FirstName)
               .HasConversion(
                    name => name.Value,
                    value => FirstName.Create(value));

        builder.Property(x => x.LastName)
               .HasConversion(
                    name => name.Value,
                    value => LastName.Create(value));

        builder.Property(x => x.Email)
               .IsRequired(true)
               .HasConversion(
                    email => email.Value,
                    value => Email.Create(value));

        builder.HasIndex(x => x.Email, "UK_Users_Email")
               .IsUnique(true);

        builder.Property(x => x.PasswordSalt)
               .IsRequired(true)
               .HasConversion(
                    passwordSalt => passwordSalt.Value,
                    value => PasswordSalt.Create(value));

        builder.Property(x => x.PasswordHash)
                   .IsRequired(true)
                   .HasConversion(
                        passwordHash => passwordHash.Value,
                        value => PasswordHash.Create(value));
    }
}