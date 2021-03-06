// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftAuth.Model.Context;

#nullable disable

namespace SoftAuth.Migrations
{
    [DbContext(typeof(MySQLContext))]
    partial class MySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SoftAuth.Model.Application", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("hash")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("self_accreditation")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id");

                    b.ToTable("applications");
                });

            modelBuilder.Entity("SoftAuth.Model.ApplicationUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("application_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("application_id");

                    b.HasIndex("user_id");

                    b.ToTable("application_user");
                });

            modelBuilder.Entity("SoftAuth.Model.Menu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("controller_name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("icon")
                        .HasColumnType("longtext");

                    b.Property<int>("menu_group_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<short>("order")
                        .HasColumnType("smallint");

                    b.HasKey("id");

                    b.HasIndex("menu_group_id");

                    b.ToTable("menus");
                });

            modelBuilder.Entity("SoftAuth.Model.MenuGroup", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("application_id")
                        .HasColumnType("int");

                    b.Property<string>("icon")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<short>("order")
                        .HasColumnType("smallint");

                    b.HasKey("id");

                    b.HasIndex("application_id");

                    b.ToTable("menu_groups");
                });

            modelBuilder.Entity("SoftAuth.Model.Profile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("dashboard")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("type")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("SoftAuth.Model.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("password")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("SoftAuth.Model.UserLog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("included")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("log")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("users_logs");
                });

            modelBuilder.Entity("SoftAuth.Model.UserProfile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("application_id")
                        .HasColumnType("int");

                    b.Property<int>("profile_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("application_id");

                    b.HasIndex("profile_id");

                    b.HasIndex("user_id");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("SoftAuth.Model.ApplicationUser", b =>
                {
                    b.HasOne("SoftAuth.Model.Application", "Application")
                        .WithMany()
                        .HasForeignKey("application_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftAuth.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("user");
                });

            modelBuilder.Entity("SoftAuth.Model.Menu", b =>
                {
                    b.HasOne("SoftAuth.Model.MenuGroup", "MenuGroup")
                        .WithMany()
                        .HasForeignKey("menu_group_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuGroup");
                });

            modelBuilder.Entity("SoftAuth.Model.MenuGroup", b =>
                {
                    b.HasOne("SoftAuth.Model.Application", "Application")
                        .WithMany()
                        .HasForeignKey("application_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("SoftAuth.Model.UserLog", b =>
                {
                    b.HasOne("SoftAuth.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("SoftAuth.Model.UserProfile", b =>
                {
                    b.HasOne("SoftAuth.Model.Application", "Application")
                        .WithMany()
                        .HasForeignKey("application_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftAuth.Model.Profile", "role")
                        .WithMany()
                        .HasForeignKey("profile_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftAuth.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("role");

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
