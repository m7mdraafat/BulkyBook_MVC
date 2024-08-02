using BulkyWebRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkyWebRazor_Temp.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                    new Category { Id=1, Name="Action", DisplayOrder=1},
                    new Category { Id = 2, Name = "Technology", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "History", DisplayOrder = 3 }

                );
        }
    }
}
