﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    Name = "Participant",
                    NormalizedName = "PARTICIPANT"
                },
                  new IdentityRole
                  {
                      Id = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                      Name = "Administrator",
                      NormalizedName = "ADMINISTRATOR"
                  },
                    new IdentityRole
                    {
                        Id = "cac43a4e-f7bb-4448-baaf-1add431aabbf",
                        Name = "Moderator",
                        NormalizedName = "MODERATOR"
                    }
                );
        }
    }
}
