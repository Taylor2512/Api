using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Servicios.Usuario
{
    public interface IUsuarioServicios<TRs,TDt> 
        where TRs : class where TDt : class //where TLS : class
     
    {
        
    }
    public interface IRegistrar<TR, T> where T : class where TR : class
    {
        public Task<TR> Registrar(T usuario);

    }
    public interface ILogin<TR, T> where T : class where TR : class
    {
      public  Task<TR> Login(T usuario);
    }
}
