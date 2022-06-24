using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeffersonLocadora.Models
{
    
    /// <summary>
    /// Classe que servirá de base para as classes CLiente e Filme que farão herança dessa
    /// </summary>
    public class BaseModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
