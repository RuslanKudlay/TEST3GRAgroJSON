// <auto-generated />
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entity.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DAL.Entity.PropertyVolume", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Heigth")
                        .HasColumnType("int");

                    b.Property<string>("VolumeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Weigth")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VolumeId");

                    b.ToTable("PropertyVolumes");
                });

            modelBuilder.Entity("DAL.Entity.Volume", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Volumes");
                });

            modelBuilder.Entity("DAL.Entity.PropertyVolume", b =>
                {
                    b.HasOne("DAL.Entity.Volume", "Volume")
                        .WithMany("PropertyVolumes")
                        .HasForeignKey("VolumeId");

                    b.Navigation("Volume");
                });

            modelBuilder.Entity("DAL.Entity.Volume", b =>
                {
                    b.HasOne("DAL.Entity.Product", "Product")
                        .WithMany("Volumes")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DAL.Entity.Product", b =>
                {
                    b.Navigation("Volumes");
                });

            modelBuilder.Entity("DAL.Entity.Volume", b =>
                {
                    b.Navigation("PropertyVolumes");
                });
#pragma warning restore 612, 618
        }
    }
}
