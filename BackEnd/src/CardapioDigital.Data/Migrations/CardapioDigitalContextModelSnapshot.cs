﻿// <auto-generated />
using CardapioDigital.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CardapioDigital.Data.Migrations
{
    [DbContext(typeof(CardapioDigitalContext))]
    partial class CardapioDigitalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CardapioDigital.Domain.Model.Bebida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BEB_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriaBebidaId")
                        .HasColumnType("int")
                        .HasColumnName("CAT_BEB_ID");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("BEB_DESCRICAO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("BEB_NOME");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaBebidaId");

                    b.ToTable("BEBIDAS");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.Borda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BORDA_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("BORDA_NOME");

                    b.HasKey("Id");

                    b.ToTable("BORDA");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.CategoriaBebida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CAT_BEB_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CAT_BEB_DESCRICAO");

                    b.HasKey("Id");

                    b.ToTable("CATEGORIA_BEBIDA");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.CategoriaPizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CAT_PIZ_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CAT_PIZ_DESCRICAO");

                    b.HasKey("Id");

                    b.ToTable("CATEGORIA_PIZZA");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PIZ_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int")
                        .HasColumnName("CAT_PIZ_ID");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("PIZ_DESCRICAO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PIZ_NOME");

                    b.Property<int>("TipoId")
                        .HasColumnType("int")
                        .HasColumnName("TIPO_ID");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("TipoId");

                    b.ToTable("PIZZA");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.PrecoPizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PRECO_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PizzaId")
                        .HasColumnType("int")
                        .HasColumnName("PIZZA_ID");

                    b.Property<int>("TamanhoId")
                        .HasColumnType("int")
                        .HasColumnName("TAM_ID");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("PRECO_VALOR");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.HasIndex("TamanhoId");

                    b.ToTable("PRECO_PIZZA");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.Tamanho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TAM_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("TAM_DESCRICAO");

                    b.HasKey("Id");

                    b.ToTable("TAMANHO");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.TamanhoPizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("int")
                        .HasColumnName("PIZ_ID");

                    b.Property<int>("TamanhoId")
                        .HasColumnType("int")
                        .HasColumnName("TAM_ID");

                    b.HasKey("PizzaId", "TamanhoId");

                    b.HasIndex("TamanhoId");

                    b.ToTable("TAMANHO_PIZZA");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.Tipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TIPO_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TIPO_DESCRICAO");

                    b.HasKey("Id");

                    b.ToTable("TIPO");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.Bebida", b =>
                {
                    b.HasOne("CardapioDigital.Domain.Model.CategoriaBebida", "CategoriaBebida")
                        .WithMany("Bebidas")
                        .HasForeignKey("CategoriaBebidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaBebida");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.Pizza", b =>
                {
                    b.HasOne("CardapioDigital.Domain.Model.CategoriaPizza", "CategoriaPizza")
                        .WithMany("Pizzas")
                        .HasForeignKey("CategoriaId")
                        .IsRequired();

                    b.HasOne("CardapioDigital.Domain.Model.Tipo", "Tipo")
                        .WithMany("Pizzas")
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaPizza");

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.PrecoPizza", b =>
                {
                    b.HasOne("CardapioDigital.Domain.Model.Pizza", "Pizza")
                        .WithMany("PrecosPizzas")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CardapioDigital.Domain.Model.Tamanho", "Tamanho")
                        .WithMany("PrecosPizzas")
                        .HasForeignKey("TamanhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("Tamanho");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.TamanhoPizza", b =>
                {
                    b.HasOne("CardapioDigital.Domain.Model.Pizza", "Pizza")
                        .WithMany("TamanhosPizzas")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CardapioDigital.Domain.Model.Tamanho", "Tamanho")
                        .WithMany("TamanhosPizzas")
                        .HasForeignKey("TamanhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("Tamanho");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.CategoriaBebida", b =>
                {
                    b.Navigation("Bebidas");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.CategoriaPizza", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.Pizza", b =>
                {
                    b.Navigation("PrecosPizzas");

                    b.Navigation("TamanhosPizzas");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.Tamanho", b =>
                {
                    b.Navigation("PrecosPizzas");

                    b.Navigation("TamanhosPizzas");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Model.Tipo", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
