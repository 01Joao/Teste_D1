using Domain.Entities;
using Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClienteService
    { 
        ClienteRepository repository = new ClienteRepository();
        public void GravarPessoa(Cliente cliente)
        {
            repository.GravarPessoa(cliente);
        }

        public Cliente CarregarPessoa(int codigo)
        {
            return repository.CarregarPessoa(codigo);
        }        

        public List<Cliente> ListarPessoa(string nome)
        {
            return repository.ListarPessoa(nome);
        }

        public void Deletar(int codigo)
        {
            repository.Delete(codigo);
        }
    }
}
