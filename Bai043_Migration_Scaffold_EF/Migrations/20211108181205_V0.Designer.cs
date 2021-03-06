// <auto-generated />
using Bai043_Migration_Scaffold_EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
// chứa thiết kế csdl
namespace Bai043_Migration_Scaffold_EF.Migrations
{
    [DbContext(typeof(WebContext))]
    [Migration("20211108181205_V0")]
    partial class V0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Bai043_Migration_Scaffold_EF.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ArticleId");

                    b.ToTable("article");
                });

            modelBuilder.Entity("Bai043_Migration_Scaffold_EF.Tag", b =>
                {
                    b.Property<string>("TagId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Content")
                        .HasColumnType("ntext");

                    b.HasKey("TagId");

                    b.ToTable("tags");
                });
#pragma warning restore 612, 618
        }
    }
}
