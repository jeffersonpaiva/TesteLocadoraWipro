using JeffersonLocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeffersonLocadora.Repository
{
    
    
    /// <summary>
    /// Classe que simulará operações no Banco de Dados com a tabela Cliente
    /// </summary>
    
    public class ClienteRepository
    {
        private static List<Cliente> Clientes = new List<Cliente>();

        
        /// <summary>
        /// Lista todos os clientes salvo em memória
        /// </summary>
        /// <returns></returns>
        public static List<Cliente> ListarClientes()
        {
            return Clientes;
        }


        /// <summary>
        /// Salva um novo cliente na memória
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static string CadastrarCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nome))
                return "É obrigatorio informar o nome do cliente!!";

            if (Clientes.Where(x => x.Nome == cliente.Nome).FirstOrDefault() == null)
            {
                if (!Clientes.Any())
                {
                    cliente.Id = 1;
                }
                else
                {
                    cliente.Id = Clientes.Max(x => x.Id) + 1;
                }

                Clientes.Add(cliente);
                return "Salvo com sucesso!";
            }
            else
            {
                return "Cliente já cadastrado!";
            }
        }
    }
}
