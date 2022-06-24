using LocadoraJefferson.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraJefferson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public List<Cliente> Get()
        {
            return Repository.ClienteRepository.ListarClientes();
        }

        [HttpPost]
        public string Post(Cliente cliente)
        {
            return Repository.ClienteRepository.CadastrarCliente(cliente);
        }
    }
}
