using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPilotoQA.Models
{
    public class Sinistro
    {
        public long? SinistroId { get; set; }
        public DateTime DataSinistro { get; set; }
        public string NomeVitima { get; set; }
        public string  CPF { get; set; }
        public DateTime DataNasc { get; set; }
    }
}

