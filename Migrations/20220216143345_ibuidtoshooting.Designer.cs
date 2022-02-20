﻿// <auto-generated />
using System;
using BiathlonSuccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BiathlonSuccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220216143345_ibuidtoshooting")]
    partial class ibuidtoshooting
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Humidity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<float?>("Temp")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.HeartrateMeasurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Time")
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.ToTable("HeartrateMeasurement");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.Shooter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("FamilyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname")
                        .HasColumnType("TEXT");

                    b.Property<string>("GenderId")
                        .HasColumnType("TEXT");

                    b.Property<string>("GivenName")
                        .HasColumnType("TEXT");

                    b.Property<string>("IbuId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxHeartRate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nationality")
                        .HasColumnType("TEXT");

                    b.Property<float?>("RifleWeightAdded")
                        .HasColumnType("REAL");

                    b.Property<string>("Team")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Shooters");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.ShooterStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PronePercentage")
                        .HasColumnType("TEXT");

                    b.Property<string>("Season")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShooterIbuID")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ShooterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StandingPercentage")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ShooterId");

                    b.ToTable("ShooterStatistics");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.Shooting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DayId")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("HitRating")
                        .HasColumnType("REAL");

                    b.Property<string>("IbuId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.ToTable("Shootings");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.Shot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pulse")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Result")
                        .HasColumnType("TEXT");

                    b.Property<int>("ShotNumberOfSeries")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShotSeriesId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Wind_Deg")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Wind_Gust")
                        .HasColumnType("REAL");

                    b.Property<float?>("Wind_Speed")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ShotSeriesId");

                    b.ToTable("Shots");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.ShotFiringCoordinates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ShotId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("x")
                        .HasColumnType("REAL");

                    b.Property<float>("y")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ShotId");

                    b.ToTable("FiringCoordinates");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.ShotSeries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateWithTime")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<float>("HitRating")
                        .HasColumnType("REAL");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<int>("ShootingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShotSerieNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Stance")
                        .HasColumnType("TEXT");

                    b.Property<string>("WeatherDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("WeatherIcon")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Wind_Deg")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Wind_Gust")
                        .HasColumnType("REAL");

                    b.Property<float?>("Wind_Speed")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ShootingId");

                    b.ToTable("ShotSeries");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.TrainingFacilityLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cityname")
                        .HasColumnType("TEXT");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("TrainingFacilities");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.HeartrateMeasurement", b =>
                {
                    b.HasOne("BiathlonSuccess.Models.Poco.Day", null)
                        .WithMany("HeartrateMeasurements")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.ShooterStatistics", b =>
                {
                    b.HasOne("BiathlonSuccess.Models.Poco.Shooter", null)
                        .WithMany("ShooterStatisticsList")
                        .HasForeignKey("ShooterId");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.Shooting", b =>
                {
                    b.HasOne("BiathlonSuccess.Models.Poco.Day", null)
                        .WithMany("Shootings")
                        .HasForeignKey("DayId");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.Shot", b =>
                {
                    b.HasOne("BiathlonSuccess.Models.Poco.ShotSeries", null)
                        .WithMany("Shots")
                        .HasForeignKey("ShotSeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.ShotFiringCoordinates", b =>
                {
                    b.HasOne("BiathlonSuccess.Models.Poco.Shot", null)
                        .WithMany("FiringCoordinates")
                        .HasForeignKey("ShotId");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.ShotSeries", b =>
                {
                    b.HasOne("BiathlonSuccess.Models.Poco.Shooting", null)
                        .WithMany("ShotSeries")
                        .HasForeignKey("ShootingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.Day", b =>
                {
                    b.Navigation("HeartrateMeasurements");

                    b.Navigation("Shootings");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.Shooter", b =>
                {
                    b.Navigation("ShooterStatisticsList");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.Shooting", b =>
                {
                    b.Navigation("ShotSeries");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.Shot", b =>
                {
                    b.Navigation("FiringCoordinates");
                });

            modelBuilder.Entity("BiathlonSuccess.Models.Poco.ShotSeries", b =>
                {
                    b.Navigation("Shots");
                });
#pragma warning restore 612, 618
        }
    }
}
