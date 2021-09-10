using Domain.Entities;
using Repository;
using Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TelefoneService
    {
        TelefoneRepository telefoneRepository = new TelefoneRepository();
        public List<TipoTelefone> TelefoneTipo(int IdCliente)
        {
            return telefoneRepository.CarregarTelefone(IdCliente);
        }

        public void InserirTelefone(TipoTelefone telefone)
        {
            telefoneRepository.GravarTelefone(telefone);
        }
        public TipoTelefone EditarTelefone(int IdTelefone)
        {
             return telefoneRepository.EditarTelefone(IdTelefone);
        }
        public void DeletarTelefone(int IdCodigo)
        {
            telefoneRepository.Delete(IdCodigo);
        }
    }
}
