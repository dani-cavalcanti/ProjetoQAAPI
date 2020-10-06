using ProjetoPilotoQA.Models;
using ProjetoPilotoQA.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPilotoQA.Repository.Implementations
{
    public class SinistroRepositoryImpl : ISinistroRepository
    {
        private readonly MySQLContext _context;

        public SinistroRepositoryImpl (MySQLContext context)
        {
            _context = context;
        }
        public Sinistro Create(Sinistro sinistro)
        {
            try
            {
                _context.Add(sinistro);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sinistro;
        }

        public void Delete(long id)
        {
            var result = _context.Sinistros.SingleOrDefault(s => s.SinistroId.Equals(id));

            try
            {
                if (result != null) _context.Sinistros.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         public List<Sinistro> FindAll()
        {
            return _context.Sinistros.ToList();
        }

        public Sinistro FindById(long id)
        {
            return _context.Sinistros.SingleOrDefault(s => s.SinistroId.Equals(id));
        }

        public Sinistro Update(Sinistro sinistro)
        {
            if (!Exists(sinistro.SinistroId)) return null;

            var result = _context.Sinistros.SingleOrDefault(s => s.SinistroId == sinistro.SinistroId);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(sinistro);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return sinistro;
        }

        public bool Exists(long? id)
        {
            return _context.Sinistros.Any(s => s.SinistroId.Equals(id));
        }
    }
}
