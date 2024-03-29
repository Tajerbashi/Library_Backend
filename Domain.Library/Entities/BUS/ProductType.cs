﻿using Domain.Library.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.BUS
{
    [Table("ProductTypes", Schema ="BUS"),Description("نوع محصول")]
    public class ProductType : GeneralEntity
    {
        [ForeignKey("Category")]
        public long CategoryID { get; set; }
        public virtual Category Category { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasIndex(x => x.ID).IsUnique();

            builder.HasOne(x => x.Category)
                .WithMany(p => p.ProductTypes)
                .HasForeignKey(x => x.CategoryID);

            builder.HasMany(p => p.Products)
                .WithOne(p => p.ProductType)
                .HasForeignKey(x => x.ID);
        }
    }
}
