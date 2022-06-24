using JeffersonLocadora.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeffersonLocadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        
        
        /// <summary>
        /// Lista todas as Locações
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Locacao> Get()
        {
            return Repository.LocacaoRepository.ListarLocacoes();
        }


        /// <summary>
        /// Loca um novo Filme, cadastrando na Locação
        /// </summary>
        /// <param name="locacao"></param>
        /// <returns></returns>
        [HttpPost]
        public string LocarFilme(Locacao locacao)
        {
            try
            {
                return Repository.LocacaoRepository.LocarFilme(locacao);
            }
            catch (Exception e)
            {
                return e.Message;
               
            }
        }

        /// <summary>
        /// Devolve um filme Locado, dando UPDATE na Locação
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="locacao"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public string DevolverFilme(int Id, Locacao locacao)
        {
            try
            {
                if (Id != locacao.Id)
                    return "Id não pertence a locação informada";
                
                return Repository.LocacaoRepository.DevolverFilme(locacao);
            }
            catch (Exception e)
            {
                return e.Message;

            }
        }


    }
}
