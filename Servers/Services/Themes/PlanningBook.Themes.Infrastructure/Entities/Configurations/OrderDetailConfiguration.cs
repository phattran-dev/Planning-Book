﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Themes.Infrastructure.Entities.Configurations
{
    public class OrderDetailConfiguration : BaseRelationDbEntityTypeConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);

            builder.HasOne(o => o.Price)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(o => o.PriceId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
