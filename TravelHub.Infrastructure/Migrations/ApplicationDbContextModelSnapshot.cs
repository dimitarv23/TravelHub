﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelHub.Infrastructure;

#nullable disable

namespace TravelHub.Infrastructure.Migrations
{
    [DbContext(typeof(TravelHubContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "4c4fa568-5033-40d9-8064-9db512d3de49",
                            ConcurrencyStamp = "21f837f2-b73a-4642-b704-33eef40bb289",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "613e9a9a-de45-4cec-8519-81625c7e603e",
                            ConcurrencyStamp = "5b1638f5-fa43-4317-a500-901b8f0f1a67",
                            Name = "Organizer",
                            NormalizedName = "ORGANIZER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "ac5688a2-417e-4a2d-973c-503b7c8eb951",
                            RoleId = "613e9a9a-de45-4cec-8519-81625c7e603e"
                        },
                        new
                        {
                            UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8",
                            RoleId = "4c4fa568-5033-40d9-8064-9db512d3de49"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TravelHub.Domain.Models.Booking", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TravelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BookDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "TravelId");

                    b.HasIndex("TravelId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("TravelHub.Domain.Models.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Country", "Place")
                        .IsUnique();

                    b.ToTable("Destinations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "Bulgaria",
                            Currency = "BGN",
                            ImageUrl = "https://i2-prod.mylondon.news/incoming/article26617964.ece/ALTERNATES/s615b/1_GettyImages-1312067182.jpg",
                            Place = "Sunny Beach"
                        },
                        new
                        {
                            Id = 2,
                            Country = "Bulgaria",
                            Currency = "BGN",
                            ImageUrl = "https://freesofiatour.com/wp-content/uploads/2018/05/seven-rila-lakes-how-to-get-to-1200x675.jpeg",
                            Place = "The Seven Rila Lakes"
                        });
                });

            modelBuilder.Entity("TravelHub.Domain.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<string>("FoodService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasPool")
                        .HasColumnType("bit");

                    b.Property<bool>("HasSpa")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DestinationId = 1,
                            FoodService = "AllInclusive",
                            HasPool = true,
                            HasSpa = true,
                            ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/340492725.jpg?k=e27fd2bc7277de6b6794b15d1d258441ecb5e85929edc499bff3cb69e8742779&o=&hp=1",
                            Name = "Diamant Residence",
                            Rating = 4
                        },
                        new
                        {
                            Id = 2,
                            DestinationId = 1,
                            FoodService = "UltraAllInclusive",
                            HasPool = true,
                            HasSpa = true,
                            ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/60906632.jpg?k=845e3aa0d06eba8ca8a546425f6100f8b9609e836228d3c3966d45607b4807cb&o=&hp=1",
                            Name = "Effect Grand Victoria Hotel",
                            Rating = 4
                        });
                });

            modelBuilder.Entity("TravelHub.Domain.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "Everyting was perfect, except the food, which wasn't that good.",
                            HotelId = 1,
                            UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8"
                        },
                        new
                        {
                            Id = 2,
                            Comment = "I am feeling amazed by how beautiful this place is!",
                            HotelId = 1,
                            UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8"
                        },
                        new
                        {
                            Id = 3,
                            Comment = "I didn't really like the food, but everything else was just awesome!",
                            HotelId = 1,
                            UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8"
                        });
                });

            modelBuilder.Entity("TravelHub.Domain.Models.Travel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("MaxNumberOfPeople")
                        .HasColumnType("int");

                    b.Property<string>("MeetingLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("HotelId");

                    b.ToTable("Travels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateFrom = new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A vacation on sunny beach for 6 days for a great amount of money! The bus leaves at 4AM on 03/07/2023 and we will be back in town at around 7PM on 08/07/2023. Come and party with us!",
                            DestinationId = 1,
                            HotelId = 1,
                            MaxNumberOfPeople = 58,
                            MeetingLocation = "Hotel 'Alen Mak', Blagoevgrad",
                            Price = 780m,
                            Type = "BeachVacation"
                        },
                        new
                        {
                            Id = 2,
                            DateFrom = new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2023, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A vacation on sunny beach for 6 days for a great amount of money! The bus leaves at 4AM on 10/07/2023 and we will be back in town at around 7PM on 16/07/2023. Come and party with us!",
                            DestinationId = 1,
                            HotelId = 2,
                            MaxNumberOfPeople = 62,
                            MeetingLocation = "Hotel 'Ezerets', Blagoevgrad",
                            Price = 820m,
                            Type = "BeachVacation"
                        },
                        new
                        {
                            Id = 3,
                            DateFrom = new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A mountain hike to gorgeous Seven Rila Lakes. We are starting our trip at 8AM on 02/07/2023 and will be back in town around 5PM on the same day. Come with us to enjoy the beauty of our bulgarian nature!",
                            DestinationId = 2,
                            MaxNumberOfPeople = 40,
                            MeetingLocation = "Park 'Bachinovo', Blagoevgrad",
                            Price = 30m,
                            Type = "MountainVacation"
                        });
                });

            modelBuilder.Entity("TravelHub.Domain.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = "ac5688a2-417e-4a2d-973c-503b7c8eb951",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a549e61f-6799-4698-a019-6e91f1b0563f",
                            Email = "organizer@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ORGANIZER@EMAIL.COM",
                            NormalizedUserName = "SEEDED_ORGANIZER",
                            PasswordHash = "AQAAAAEAACcQAAAAELGwtiYsbkca0rXgvY7e4HcAeP9psgnENVO3qAahyFhOSTStP6dq+Zd97zIoMLAH/Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "63bdec60-43a3-4823-bcf8-4424bf188616",
                            TwoFactorEnabled = false,
                            UserName = "Seeded_Organizer",
                            FirstName = "Organizer",
                            LastName = "Organizer"
                        },
                        new
                        {
                            Id = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1c9bcf91-c818-44a7-a1ff-aebf351b086f",
                            Email = "user@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@EMAIL.COM",
                            NormalizedUserName = "SEEDED_USER",
                            PasswordHash = "AQAAAAEAACcQAAAAEF7p7slPdcyfY23sYHu6e6E+T2EEQvVHDPOLd3rfjfVhk02JQnv8oGCxGEmWpoZk0w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "72945097-5b1c-482b-a9d6-bcae6c2b2b4f",
                            TwoFactorEnabled = false,
                            UserName = "Seeded_User",
                            FirstName = "User",
                            LastName = "User"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelHub.Domain.Models.Booking", b =>
                {
                    b.HasOne("TravelHub.Domain.Models.Travel", "Travel")
                        .WithMany("Bookings")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelHub.Domain.Models.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Travel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelHub.Domain.Models.Hotel", b =>
                {
                    b.HasOne("TravelHub.Domain.Models.Destination", "Destination")
                        .WithMany("Hotels")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("TravelHub.Domain.Models.Review", b =>
                {
                    b.HasOne("TravelHub.Domain.Models.Hotel", "Hotel")
                        .WithMany("Reviews")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelHub.Domain.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelHub.Domain.Models.Travel", b =>
                {
                    b.HasOne("TravelHub.Domain.Models.Destination", "Destination")
                        .WithMany("Travels")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelHub.Domain.Models.Hotel", "Hotel")
                        .WithMany("Travels")
                        .HasForeignKey("HotelId");

                    b.Navigation("Destination");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelHub.Domain.Models.Destination", b =>
                {
                    b.Navigation("Hotels");

                    b.Navigation("Travels");
                });

            modelBuilder.Entity("TravelHub.Domain.Models.Hotel", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Travels");
                });

            modelBuilder.Entity("TravelHub.Domain.Models.Travel", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("TravelHub.Domain.Models.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
