﻿// <auto-generated />
using System;
using MailingList.Core.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MailingList.Web.Migrations
{
    [DbContext(typeof(EventContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MailingList.Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("MobileNo");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("MailingList.Core.Entities.CustomerEvent", b =>
                {
                    b.Property<int>("CustomerId");

                    b.Property<int>("EventId");

                    b.Property<bool>("IsEmailSent");

                    b.HasKey("CustomerId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("customerEvents");
                });

            modelBuilder.Entity("MailingList.Core.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Title");

                    b.Property<string>("Venue");

                    b.HasKey("Id");

                    b.ToTable("events");
                });

            modelBuilder.Entity("MailingList.Core.Entities.CustomerEvent", b =>
                {
                    b.HasOne("MailingList.Core.Entities.Customer", "Customer")
                        .WithMany("CustomerEvents")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MailingList.Core.Entities.Event", "Event")
                        .WithMany("CustomerEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
