using ProjetoPilotoQA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPilotoQA.Business
{
   public interface ISinistroBusiness
    {
        Sinistro Create(Sinistro sinistro);
        Sinistro FindById(long id);
        List<Sinistro> FindAll();
        Sinistro Update(Sinistro sinistro);
        void Delete(long id);
      
    }
}
