using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Servicios
{
    public interface ICuentaServicios<TR,T,usuario,usuariodto> where T : class   where TR:class
        where usuariodto:class where usuario :class
    {
        public Task<TR> ConstruirToken(T credencialesUsuario);
        public  Task<usuario> obtenerUsuario(usuariodto user);
    }
  
   
    
}
