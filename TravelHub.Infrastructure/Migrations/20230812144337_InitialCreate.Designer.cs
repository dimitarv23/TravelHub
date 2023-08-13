﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelHub.Infrastructure;

#nullable disable

namespace TravelHub.Infrastructure.Migrations
{
    [DbContext(typeof(TravelHubContext))]
    [Migration("20230812144337_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            ConcurrencyStamp = "b278d596-dab3-4d76-ac6f-0a942db58462",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "613e9a9a-de45-4cec-8519-81625c7e603e",
                            ConcurrencyStamp = "d75df73d-9216-4ae3-b59b-6848a52d3d0d",
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

                    b.HasData(
                        new
                        {
                            UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8",
                            TravelId = 1,
                            BookDate = new DateTime(2023, 8, 12, 14, 43, 36, 750, DateTimeKind.Utc).AddTicks(4136)
                        },
                        new
                        {
                            UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8",
                            TravelId = 3,
                            BookDate = new DateTime(2023, 8, 12, 14, 43, 36, 750, DateTimeKind.Utc).AddTicks(4140)
                        });
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
                        },
                        new
                        {
                            Id = 3,
                            Country = "Bulgaria",
                            Currency = "BGN",
                            ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/17/d3/27/9e/photo0jpg.jpg?w=1200&h=-1&s=1",
                            Place = "Plovdiv"
                        },
                        new
                        {
                            Id = 4,
                            Country = "Greece",
                            Currency = "EUR",
                            ImageUrl = "https://www.feelgreece.com/cx/m/0/0/244/35239-viewom.jpg",
                            Place = "Nea Peramos"
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
                        },
                        new
                        {
                            Id = 3,
                            DestinationId = 3,
                            FoodService = "AllInclusive",
                            HasPool = true,
                            HasSpa = true,
                            ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/207378277.jpg?k=a3ff6dfc7bc9855ae08aacacb71f51863a8b0e41b90d0384c700456a79e7b72c&o=&hp=1",
                            Name = "Grand Hotel Plovdiv",
                            Rating = 5
                        },
                        new
                        {
                            Id = 4,
                            DestinationId = 4,
                            FoodService = "BreakfastOnly",
                            HasPool = true,
                            HasSpa = false,
                            ImageUrl = "https://ak-d.tripcdn.com/images/200l0m000000dw3kcBD54_R_550_412_R5.jpg",
                            Name = "Galaxy Hotel",
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
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

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
                            DateAdded = new DateTime(2023, 8, 2, 14, 43, 36, 750, DateTimeKind.Utc).AddTicks(9596),
                            HotelId = 1,
                            UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8"
                        },
                        new
                        {
                            Id = 2,
                            Comment = "I am feeling amazed by how beautiful this place is!",
                            DateAdded = new DateTime(2023, 7, 23, 14, 43, 36, 750, DateTimeKind.Utc).AddTicks(9604),
                            HotelId = 1,
                            UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8"
                        },
                        new
                        {
                            Id = 3,
                            Comment = "I didn't really like the food, but everything else was just awesome!",
                            DateAdded = new DateTime(2023, 6, 23, 14, 43, 36, 750, DateTimeKind.Utc).AddTicks(9605),
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
                        },
                        new
                        {
                            Id = 4,
                            DateFrom = new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A city tour trip to Plovdiv, Bulgaria. Plovdiv is a very beautiful city and it also won the European Capital of Culture in 2019.",
                            DestinationId = 3,
                            HotelId = 3,
                            MaxNumberOfPeople = 50,
                            MeetingLocation = "Hotel 'Alen Mak', Blagoevgrad",
                            Price = 600m,
                            Type = "CityTour"
                        },
                        new
                        {
                            Id = 5,
                            DateFrom = new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A 3-day beach holiday to Nea Peramos, Greece. We'll have fun on the calm and clear Greece beaches!",
                            DestinationId = 4,
                            HotelId = 4,
                            MaxNumberOfPeople = 35,
                            MeetingLocation = "Hotel 'Alen Mak', Blagoevgrad",
                            Price = 400m,
                            Type = "BeachVacation"
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
                            ConcurrencyStamp = "7c691852-c737-4a99-9b3d-d1d069f5ceb1",
                            Email = "organizer@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ORGANIZER@EMAIL.COM",
                            NormalizedUserName = "SEEDED_ORGANIZER",
                            PasswordHash = "AQAAAAEAACcQAAAAEO1I9th0BY+jXXRpsR5/OrnLBZoNAuRikDtwZSWT1OClH0TUjShvMFuqFU332tyEMw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "749f74c4-32c4-4ce7-83cc-d5e05086428d",
                            TwoFactorEnabled = false,
                            UserName = "Seeded_Organizer",
                            FirstName = "Organizer",
                            LastName = "Organizer"
                        },
                        new
                        {
                            Id = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fab3a3cb-107f-4dd0-9bce-d0b1a08531db",
                            Email = "user@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@EMAIL.COM",
                            NormalizedUserName = "SEEDED_USER",
                            PasswordHash = "AQAAAAEAACcQAAAAEEOrMmModGTMWs1mm01piaq9xo8YjUA5e+pryg3hG2AgUKCXdWTU48ATy3kXEEtkCA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fff3ca16-3080-43a4-8db1-c8aef66d5bbd",
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