﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infractructure.Configuration.Interfaces
{
    internal interface IPersonaConfig:IEntityTypeConfiguration<Usuarios>
    {
    }
}
