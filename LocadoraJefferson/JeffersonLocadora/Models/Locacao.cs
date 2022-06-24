using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeffersonLocadora.Models
{
    /// <summary>
    /// Representação da tabela Locacao
    /// </summary>
    public class Locacao 
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int FilmeId { get; set; }
        public DateTime DataParaDevolver { get; set; }
        public DateTime? DataQueEntregou { get; set; }

    }
}
