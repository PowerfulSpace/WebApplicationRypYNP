// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationRypYNP.Domain.Data;

namespace WebApplicationRypYNP.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220414165307_EditFieldPayerUNPOnVUNP")]
    partial class EditFieldPayerUNPOnVUNP
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplicationRypYNP.Domain.Entities.Payer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CKODSOST")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DLIKV")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DREG")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NMNS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VKODS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VLIKV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VMNS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VNAIMK")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VNAIMP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VUNP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payers");
                });
#pragma warning restore 612, 618
        }
    }
}
