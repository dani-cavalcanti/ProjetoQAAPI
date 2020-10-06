using ProjetoPilotoQA.Models;
using ProjetoPilotoQA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPilotoQA.Business.Implementation
{
    public class SinistroBusinessImpl : ISinistroBusiness
    {
        private readonly ISinistroRepository _repository;

        public SinistroBusinessImpl(ISinistroRepository repository)
        {
            _repository = repository;
        }
        public Sinistro Create(Sinistro sinistro)
        {
            return _repository.Create(sinistro);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Sinistro> FindAll()
        {
            return _repository.FindAll();
        }

        public Sinistro FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Sinistro Update(Sinistro sinistro)
        {
            return _repository.Update(sinistro);
        }
    }
}
