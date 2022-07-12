using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Entity
{
    internal interface IEntity
    {
        object Id { get; set; }
    }
    internal interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
