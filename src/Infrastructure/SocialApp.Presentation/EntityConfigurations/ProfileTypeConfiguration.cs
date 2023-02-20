using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialApp.Domain.Profile;
using SocialApp.Domain.User.ValueObjects;
using SocialApp.Persistence.Context;

namespace SocialApp.Persistence.EntityConfigurations;
public sealed class ProfileTypeConfiguration : IEntityTypeConfiguration<Profile> {
    public void Configure(EntityTypeBuilder<Profile> builder) {
        ConfigureProfilesTable(builder);
        ConfigureProfileRelationshipsTable(builder);
    }

    private void ConfigureProfilesTable(EntityTypeBuilder<Profile> builder) {
        builder.ToTable("Profiles", SocialAppDbContext.DEFAULT_SCHEMA);
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique(true);
        builder.Property(x => x.Id)
               .IsRequired(true)
               .ValueGeneratedNever();
        //.HasConversion(
        //     id => id.Value,
        //     value => ProfileId.Create(value));

        //builder.Property(x => x.Follower)
        //       .HasConversion(
        //            name => name.Value,
        //            value => Follower.Create(value));

        //builder.Property(x => x.Follow)
        //       .HasConversion(
        //            name => name.Value,
        //            value => Follow.Create(value));

        builder.Property(x => x.UserId)
            .HasConversion(
                userId => userId.Value,
                value => UserId.Create(value)
                );
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
    }

    private void ConfigureProfileRelationshipsTable(EntityTypeBuilder<Profile> builder) {
        builder.HasMany(x => x.Followers)
            .WithMany(x => x.Follows)
        .UsingEntity(x => {
            x.ToTable("ProfileRelationships");
        });

        builder.Metadata.FindNavigation(nameof(Profile.Followers))?
         .SetPropertyAccessMode(PropertyAccessMode.Field);

        //builder.Metadata.FindNavigation(nameof(Profile.Follows))?
        //    .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}