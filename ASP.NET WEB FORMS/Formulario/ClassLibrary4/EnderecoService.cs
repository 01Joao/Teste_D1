using Domain.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EnderecoService
    {
        EnderecoRepository enderecoRepository = new EnderecoRepository();
        public List<TipoEndereco> EnderecoTipo(int IdCliente)
        {
            return enderecoRepository.CarregarEndereco(IdCliente);
        }

        public void InserirEndereco(TipoEndereco endereco)
        {
            enderecoRepository.GravarEndereco(endereco);
        }
        public TipoEndereco EditarEndereco(int IdEndereco)
        {
            return enderecoRepository.EditarEndereco(IdEndereco);
        }
        public void DeletarEndereco(int IdCodigo)
        {
            enderecoRepository.Delete(IdCodigo);
        }
    }
}
