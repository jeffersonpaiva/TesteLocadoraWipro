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
    public class ClienteController : ControllerBase
    {
       /// <summary>
       /// Lista todos Clientes
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public List<Cliente> Get()
        {
            return Repository.ClienteRepository.ListarClientes();
        }

        /// <summary>
        /// Cadastra um novo Cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost]
        public string Post(Cliente cliente)
        {
            try
            {
                return Repository.ClienteRepository.CadastrarCliente(cliente);
            }
            catch (Exception e)
            {
                return e.Message;

            }

        }
    }
}
