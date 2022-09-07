using Domain.Entities;
using Infractructure.Configuration.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infractructure.Configuration
{
    internal class PersonaConfig : IPersonaConfig
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("tbl_usuario");
          //  builder.("create procedure selectalluser as select *from tbl_usuario go;");
        }
    }
}
