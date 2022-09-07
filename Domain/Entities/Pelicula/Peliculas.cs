using Domain.Entities.Auditoria;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pelicula
{
    public class Peliculas:Auditoria<Guid>
    {


        

        public String Titulo { get; set; }



        public String Argumento { get; set; }
    }
}
