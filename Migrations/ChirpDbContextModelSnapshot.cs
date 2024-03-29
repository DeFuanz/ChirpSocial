﻿// <auto-generated />
using System;
using Chirp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChirpSocial.Migrations
{
    [DbContext(typeof(ChirpDbContext))]
    partial class ChirpDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Chirp.Models.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasMaxLength(28)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfileID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostID");

                    b.HasIndex("ProfileID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Chirp.Models.Profile", b =>
                {
                    b.Property<int>("ProfileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfileBio")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfileUserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("ProfileID");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Chirp.Models.Reply", b =>
                {
                    b.Property<int>("ReplyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfileID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReplyContent")
                        .IsRequired()
                        .HasMaxLength(28)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReplyDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ReplyID");

                    b.HasIndex("PostID");

                    b.HasIndex("ProfileID");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("Chirp.Models.Post", b =>
                {
                    b.HasOne("Chirp.Models.Profile", "Profile")
                        .WithMany("Posts")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Chirp.Models.Reply", b =>
                {
                    b.HasOne("Chirp.Models.Post", "Post")
                        .WithMany("Replies")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chirp.Models.Profile", "Profile")
                        .WithMany("Replies")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Chirp.Models.Post", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("Chirp.Models.Profile", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("Replies");
                });
#pragma warning restore 612, 618
        }
    }
}
