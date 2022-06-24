using JeffersonLocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeffersonLocadora.Repository
{

    /// <summary>
    ///  Classe que simulará operações no Banco de Dados com a tabela Filme
    /// </summary>
    public class FilmeRepository
    {
        private static List<Filme> Filmes = new List<Filme>();

        /// <summary>
        /// Lista todos os filmes na memória
        /// </summary>
        /// <returns></returns>
        public static List<Filme> ListarFilmes()
        {
            return Filmes;
        }

        /// <summary>
        /// Salva um novo Filme na memória
        /// </summary>
        /// <param name="filme"></param>
        /// <returns></returns>
        public static string CadastrarFilme(Filme filme)
        {
            if (string.IsNullOrWhiteSpace(filme.Nome))
                return "É obrigatorio informar o nome do filme!!";

            if (Filmes.Where(x => x.Nome == filme.Nome).FirstOrDefault() == null)
            {
                if (!Filmes.Any())
                {
                    filme.Id = 1;
                }
                else
                {
                    filme.Id = Filmes.Max(x => x.Id) + 1;
                }

                Filmes.Add(filme);
                return "Salvo com sucesso!";
            }
            else
            {
                return "Filme já cadastrado!";
            }
        }
    }
}
