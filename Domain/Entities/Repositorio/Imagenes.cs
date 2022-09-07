using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Repositorio
{
    public class Imagenes
    {
        public IFormFile formFile { get; set; }
        public string name { get; set; }
        public string? urlAzure { get; set; }

    }
}
