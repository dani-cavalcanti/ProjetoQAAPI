using ProjetoPilotoQA.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProjetoQA.Tests
{
    public class SinistroTests
    {
        [Fact]
        public void GetAllSinistros_SholdReturnAllSinistros()
        {
            var testSinistros = GetTestSinistros();
        }

        private List<Sinistro> GetTestSinistros()
        {
            DateTime dataSinistro = new DateTime(2020, 10, 1);
            DateTime dataNasc = new DateTime(1987, 9, 22);
            DateTime dataSinistro1 = new DateTime(2020, 09, 30);
            DateTime dataNasc1 = new DateTime(1977, 5, 27);
            DateTime dataSinistro2 = new DateTime(2020, 09, 18);
            DateTime dataNasc2 = new DateTime(1968, 12, 09);

            var testSinistros = new List<Sinistro>();

            testSinistros.Add(new Sinistro
            {
                SinistroId = 1,
                DataSinistro = dataSinistro,
                NomeVitima = "Elaine Bárbara Emilly",
                CPF = "717.458.865-40",
                DataNasc = dataNasc
            });

            testSinistros.Add(new Sinistro
            {
                SinistroId = 2,
                DataSinistro = dataSinistro1,
                NomeVitima = "Elaine Bárbara Emilly",
                CPF = "717.458.865-40",
                DataNasc = dataNasc1
            });

            testSinistros.Add(new Sinistro
            {
                SinistroId = 1,
                DataSinistro = dataSinistro2,
                NomeVitima = "Elaine Bárbara Emilly",
                CPF = "717.458.865-40",
                DataNasc = dataNasc2
            });
            return testSinistros;
        }
    }
}
