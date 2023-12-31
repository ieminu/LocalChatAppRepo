﻿// <auto-generated />
using LocalChatApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocalChatApp.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20230827131009_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocalChatApp.Models.Message", b =>
                {
                    b.Property<string>("MessageProp")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
