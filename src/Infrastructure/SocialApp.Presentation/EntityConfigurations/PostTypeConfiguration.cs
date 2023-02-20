using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialApp.Domain.Posts;
using SocialApp.Persistence.Context;

namespace SocialApp.Persistence.EntityConfigurations;
public sealed class PostTypeConfiguration : IEntityTypeConfiguration<Post> {
    public void Configure(EntityTypeBuilder<Post> builder) {
        builder.ToTable("Posts", SocialAppDbContext.DEFAULT_SCHEMA);
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique(true);
        builder.Property(x => x.Id)
               .IsRequired(true)
               .ValueGeneratedNever();

        builder.HasOne(x => x.Profile)
            .WithMany()
            .HasForeignKey(x => x.ProfileId);
    }
}