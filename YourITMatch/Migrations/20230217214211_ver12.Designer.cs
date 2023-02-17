﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YourITMatch.Models;

#nullable disable

namespace YourITMatch.Migrations
{
    [DbContext(typeof(YourITMatchDBContext))]
    [Migration("20230217214211_ver12")]
    partial class ver12
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("YourITMatch.Models.CompanyAddressModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CompanyIDID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Voivodeship")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CompanyIDID");

                    b.ToTable("CompanyAddress");
                });

            modelBuilder.Entity("YourITMatch.Models.CompanyModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("CompanyEstablished")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CompanySize")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyWebsite")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Regon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Voivodeship")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("YourITMatch.Models.JobOfferLocalisationModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("JobOfferIdId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Voivodeship")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("JobOfferIdId");

                    b.ToTable("JobOfferLocalisation");
                });

            modelBuilder.Entity("YourITMatch.Models.JobOfferModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyModelID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("JobCategory")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Remote")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("SalaryFrom")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SalaryTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyModelID");

                    b.ToTable("JobOffer");
                });

            modelBuilder.Entity("YourITMatch.Models.CompanyAddressModel", b =>
                {
                    b.HasOne("YourITMatch.Models.CompanyModel", "CompanyID")
                        .WithMany()
                        .HasForeignKey("CompanyIDID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyID");
                });

            modelBuilder.Entity("YourITMatch.Models.JobOfferLocalisationModel", b =>
                {
                    b.HasOne("YourITMatch.Models.JobOfferModel", "JobOfferId")
                        .WithMany()
                        .HasForeignKey("JobOfferIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOfferId");
                });

            modelBuilder.Entity("YourITMatch.Models.JobOfferModel", b =>
                {
                    b.HasOne("YourITMatch.Models.CompanyModel", null)
                        .WithMany("JobOffers")
                        .HasForeignKey("CompanyModelID");
                });

            modelBuilder.Entity("YourITMatch.Models.CompanyModel", b =>
                {
                    b.Navigation("JobOffers");
                });
#pragma warning restore 612, 618
        }
    }
}
