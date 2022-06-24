using LocadoraJefferson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraJefferson.Repository
{
    public class ClienteRepository
    {
        private static List<Cliente> Clientes = new List<Cliente>();

        public static List<Cliente> ListarClientes()
        {
            return Clientes;
        }

        public static string CadastrarCliente(Cliente cliente)
        {
            if (Clientes.Where(x=>x.Nome == cliente.Nome).FirstOrDefault() == null)
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