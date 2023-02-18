﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialApp.Persistence.Context;

#nullable disable

namespace SocialApp.Persistence.Migrations
{
    [DbContext(typeof(SocialAppDbContext))]
    [Migration("20230217215057_migration6")]
    partial class migration6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProfileProfile", b =>
                {
                    b.Property<Guid>("FollowersId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("followers_id");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("profile_id");

                    b.HasKey("FollowersId", "ProfileId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfileRelationships", "socialApp");
                });

            modelBuilder.Entity("SocialApp.Domain.Profile.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<long>("Follow")
                        .HasColumnType("bigint")
                        .HasColumnName("follow");

                    b.Property<long>("Follower")
                        .HasColumnType("bigint")
                        .HasColumnName("follower");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Profiles", "socialApp");
                });

            modelBuilder.Entity("SocialApp.Domain.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UK_Users_Email")
                        .IsUnique();

                    b.ToTable("Users", "socialApp");
                });

            modelBuilder.Entity("ProfileProfile", b =>
                {
                    b.HasOne("SocialApp.Domain.Profile.Profile", null)
                        .WithMany()
                        .HasForeignKey("FollowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialApp.Domain.Profile.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialApp.Domain.Profile.Profile", b =>
                {
                    b.HasOne("SocialApp.Domain.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
