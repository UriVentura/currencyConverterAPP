// <auto-generated />
using CCTransferWeb.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CCTransferWeb.Migrations
{
    [DbContext(typeof(CCTransferDbContext))]
    partial class CCTransferDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CCTransferWeb.Models.FactorConversion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Conversion")
                        .HasColumnType("float");

                    b.Property<string>("MonedaDestino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonedaOrigen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FactorConversiones");
                });

            modelBuilder.Entity("CCTransferWeb.Models.Moneda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodMoneda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomMoneda")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Monedas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodMoneda = "EUR",
                            NomMoneda = "Euro"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
