﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(BuyersContext))]
    partial class BuyersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Buyer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MonthlyIncome")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("Domain.House", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BuyerID")
                        .HasColumnType("int");

                    b.Property<int>("MortgageID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("BuyerID");

                    b.HasIndex("MortgageID")
                        .IsUnique();

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("Domain.Mortgage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BuyerID")
                        .HasColumnType("int");

                    b.Property<double>("DepositAmount")
                        .HasColumnType("float");

                    b.Property<int>("HouseID")
                        .HasColumnType("int");

                    b.Property<double>("InterestRate")
                        .HasColumnType("float");

                    b.Property<double>("LoanAmount")
                        .HasColumnType("float");

                    b.Property<int>("LoanTermMonths")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ID");

                    b.HasIndex("BuyerID");

                    b.ToTable("Mortgages");
                });

            modelBuilder.Entity("Domain.House", b =>
                {
                    b.HasOne("Domain.Buyer", "Buyer")
                        .WithMany("Houses")
                        .HasForeignKey("BuyerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Mortgage", "Mortgage")
                        .WithOne("House")
                        .HasForeignKey("Domain.House", "MortgageID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Mortgage");
                });

            modelBuilder.Entity("Domain.Mortgage", b =>
                {
                    b.HasOne("Domain.Buyer", "Buyer")
                        .WithMany("Mortgages")
                        .HasForeignKey("BuyerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("Domain.Buyer", b =>
                {
                    b.Navigation("Houses");

                    b.Navigation("Mortgages");
                });

            modelBuilder.Entity("Domain.Mortgage", b =>
                {
                    b.Navigation("House")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
