﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _6SemCursach.Data.Models;

namespace _6SemCursach.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_6SemCursach.Data.Models.CoursStud", b =>
                {
                    b.Property<int>("CourseFK")
                        .HasColumnType("int");

                    b.Property<int>("StudentFK")
                        .HasColumnType("int");

                    b.Property<int>("SemesterFK")
                        .HasColumnType("int");

                    b.HasKey("CourseFK", "StudentFK");

                    b.HasIndex("SemesterFK");

                    b.HasIndex("StudentFK");

                    b.ToTable("CoursStud");
                });

            modelBuilder.Entity("_6SemCursach.Data.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("_6SemCursach.Data.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("_6SemCursach.Data.Models.Semester", b =>
                {
                    b.Property<int>("SemesterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SemesterId");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("_6SemCursach.Data.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Money")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserFK")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("UserFK")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("_6SemCursach.Data.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserFK")
                        .HasColumnType("int");

                    b.HasKey("TeacherId");

                    b.HasIndex("UserFK")
                        .IsUnique();

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("_6SemCursach.Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleFK")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleFK");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("_6SemCursach.Data.Models.CoursStud", b =>
                {
                    b.HasOne("_6SemCursach.Data.Models.Course", "Course")
                        .WithMany("CoursStud")
                        .HasForeignKey("CourseFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_6SemCursach.Data.Models.Semester", "Semester")
                        .WithMany("CoursStud")
                        .HasForeignKey("SemesterFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_6SemCursach.Data.Models.Student", "Student")
                        .WithMany("CoursStud")
                        .HasForeignKey("StudentFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("_6SemCursach.Data.Models.Student", b =>
                {
                    b.HasOne("_6SemCursach.Data.Models.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("_6SemCursach.Data.Models.Student", "UserFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_6SemCursach.Data.Models.Teacher", b =>
                {
                    b.HasOne("_6SemCursach.Data.Models.User", "User")
                        .WithOne("Teacher")
                        .HasForeignKey("_6SemCursach.Data.Models.Teacher", "UserFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_6SemCursach.Data.Models.User", b =>
                {
                    b.HasOne("_6SemCursach.Data.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
