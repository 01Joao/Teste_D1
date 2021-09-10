using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Dados do Tipo de Endereco
    /// </summary>
    public class TipoEndereco
    {
        /// <summary>
        /// Identificador do Cliente
        /// </summary>
        public int IdCliente { get; set; }
        /// <summary>
        /// Identificador do Tipo de Endereco
        /// </summary>
        public int IdTipoEndereco { get; set; }
        /// <summary>
        /// Identificador do Endereco
        /// </summary>
        public int IdEndereco { get; set; }
        /// <summary>
        /// Logradouro
        /// </summary>
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        /// <summary>
        /// Complemento
        /// </summary>
        public string DescricaoEndereco { get; set; }
    }
}
