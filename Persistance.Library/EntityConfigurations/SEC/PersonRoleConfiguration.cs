﻿using Common.Library.Utilities;
using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Library.EntityConfigurations.SEC
{
    public class PersonRoleConfiguration : IEntityTypeConfiguration<PersonRole>
    {
        public void Configure(EntityTypeBuilder<PersonRole> builder)
        {

            builder.HasQueryFilter(x => x.IsDeleted == false);
            builder.HasComment(ClassExtention.GetDescription(typeof(PersonRole)));

            builder.HasIndex(x => x.ID);

            builder
                .HasOne(p => p.Person)
                .WithMany(pr => pr.PersonRoles)
                .HasForeignKey(f => f.PersonID);

            builder
                .HasOne(p => p.Role)
                .WithMany(pr => pr.PersonRoles)
                .HasForeignKey(f => f.RoleID);
        }
    }
}