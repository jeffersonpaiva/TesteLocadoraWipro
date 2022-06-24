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
    public class FilmeController : ControllerBase
    {
        /// <summary>
        /// Lista todos os Filmes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Filme> Get()
        {
            return Repository.FilmeRepository.ListarFilmes();
        }

        /// <summary>
        /// Salva um novo Filme
        /// </summary>
        /// <param name="filme"></param>
        /// <returns></returns>
        [HttpPost]
        public string Post(Filme filme)
        {
            try
            {
                return Repository.FilmeRepository.CadastrarFilme(filme);
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
    }
}
