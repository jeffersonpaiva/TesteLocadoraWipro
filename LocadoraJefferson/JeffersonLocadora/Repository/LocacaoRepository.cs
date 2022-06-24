using JeffersonLocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeffersonLocadora.Repository
{
    /// <summary>
    ///  Classe que simulará operações no Banco de Dados com a tabela Locacao
    /// </summary>
    public class LocacaoRepository
    {
        private static List<Locacao> Locacoes = new List<Locacao>();

        
        /// <summary>
        /// Lista todas as locações
        /// </summary>
        /// <returns></returns>
        public static List<Locacao> ListarLocacoes()
        {
            return Locacoes;
        }

        /// <summary>
        ///  Salva uma locação na memoória
        ///  O campo DataQueEntregou terá que ser preenchido com NULL, pois a data de entrega do filme so será preenchida durante a devolução do filme
        /// </summary>
        /// <param name="locacao"></param>
        /// <returns></returns>
        public static string LocarFilme(Locacao locacao)
        {
            if(locacao.DataQueEntregou != null)
            {
                return "Preencher data de entrega APENAS na devolução";
            }

            if (locacao.DataParaDevolver.Equals(DateTime.MinValue))
                return "Por Favor, Preencha a data de devolução";

            if (FilmeRepository.ListarFilmes().Where(x => x.Id == locacao.FilmeId).FirstOrDefault() == null)
                return "Filme não existe!";

            if (ClienteRepository.ListarClientes().Where(x => x.Id == locacao.ClienteId).FirstOrDefault() == null)
                return "Cliente não cadastrado!";

            if (locacao.ClienteId == 0)
                return "É preciso informar o cliente";

            if (locacao.FilmeId == 0)
                return "É preciso informar o filme";
                   

            if (Locacoes.Where(x => x.FilmeId == locacao.FilmeId && x.DataQueEntregou == null).FirstOrDefault() != null)
                return "Filme Locado!";


            if (!Locacoes.Any())
            {
                locacao.Id = 1;
            }
            else
            {
                locacao.Id = Locacoes.Max(x => x.Id) + 1;
            }

            Locacoes.Add(locacao);

            return "Locado com SUCESSO!";


        }

        /// <summary>
        /// Da UPDATE na Locação, informando e validando a Data de Entrega
        /// </summary>
        /// <param name="locacao"></param>
        /// <returns></returns>

        public static string DevolverFilme(Locacao locacao)
        {
            if (locacao.DataQueEntregou == null)
            {
                return "Preencher a data de entrega!!";
            }

            if (locacao.DataParaDevolver.Equals(DateTime.MinValue))
                return "Por Favor, Preencha a data de devolução";

            if (FilmeRepository.ListarFilmes().Where(x => x.Id == locacao.FilmeId).FirstOrDefault() == null)
                return "Filme não existe!";

            if (ClienteRepository.ListarClientes().Where(x => x.Id == locacao.ClienteId).FirstOrDefault() == null)
                return "Cliente não cadastrado!";

            if (locacao.ClienteId == 0)
                return "É preciso informar o cliente";

            if (locacao.FilmeId == 0)
                return "É preciso informar o filme";

            if(Locacoes.Where(x => x.FilmeId == locacao.FilmeId && x.DataQueEntregou == null).FirstOrDefault() == null)
            {
                return "O filme não está locado";
            }
            else
            {
                Locacoes.Where(x => x.FilmeId == locacao.FilmeId && x.DataQueEntregou == null).FirstOrDefault().DataQueEntregou = locacao.DataQueEntregou;

                if (locacao.DataQueEntregou > locacao.DataParaDevolver)
                {
                    return "Data de entrega em atraso, PAGUE A MULTA!";
                }
                else
                {
                    return "Devolvido com SUCESSO!";
                }

                    
            }


        }

    }
}
