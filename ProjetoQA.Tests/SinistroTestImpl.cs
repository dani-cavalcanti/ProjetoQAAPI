using ProjetoPilotoQA.Business;
using ProjetoPilotoQA.Models;
using ProjetoPilotoQA.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProjetoQA.Tests
{
    public class SinistroTestImp : ISinistroBusiness
    {
        private readonly List<Sinistro> _sinistrotest;
        public SinistroTestImp()
        {
            DateTime dataSinistro = new DateTime(2020, 10, 1);
            DateTime dataNasc = new DateTime(1987, 9, 22);
            DateTime dataSinistro1 = new DateTime(2020, 09, 30);
            DateTime dataNasc1 = new DateTime(1977, 5, 27);
            DateTime dataSinistro2 = new DateTime(2020, 09, 18);
            DateTime dataNasc2 = new DateTime(1968, 12, 09);
            
            _sinistrotest = new List<Sinistro>()
            {
                new Sinistro(){
                    SinistroId = 1,
                    DataSinistro = dataSinistro,
                    NomeVitima = "Elaine Bárbara Emilly",
                    CPF = "717.458.865-40",
                    DataNasc = dataNasc},

                new Sinistro (){ 
                    SinistroId = 2,
                    DataSinistro = dataSinistro1,
                    NomeVitima = "Elaine Bárbara Emilly",
                    CPF = "717.458.865-40",
                    DataNasc = dataNasc1},

                new Sinistro()
                {
                    SinistroId = 3,
                    DataSinistro = dataSinistro2,
                    NomeVitima = "Elaine Bárbara Emilly",
                    CPF = "717.458.865-40",
                    DataNasc = dataNasc2
                }
            };        
         }
        public Sinistro Create(Sinistro sinistro)
        {
            sinistro.SinistroId = GeraSinistroId();
            _sinistrotest.Add(sinistro);
            return sinistro;
        }

        public void Delete(long id)
        {
            var result = _sinistrotest.First(a => a.SinistroId == id);
            _sinistrotest.Remove(result);
        }

        public List<Sinistro> FindAll()
        {
            return _sinistrotest;
        }



        public Sinistro FindById(long id)
        {
            return _sinistrotest.Where(a => a.SinistroId == id)
                .FirstOrDefault();
        }

        static int GeraSinistroId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }

        public Sinistro Update(Sinistro sinistro)
        {
            throw new NotImplementedException();
        }
    }
}
