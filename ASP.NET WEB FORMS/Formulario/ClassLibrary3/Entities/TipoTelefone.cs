using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Dados do Tipo de Telefone
    /// </summary>
    public class TipoTelefone
    {
        /// <summary>
        /// Identificador do Cliente
        /// </summary>
        public int IdCliente { get; set; }
        /// <summary>
        /// Identificador do Tipo de Telefone
        /// </summary>
        public int IdTipoTelefone { get; set; }
        /// <summary>
        /// Identificador do Telefone
        /// </summary>
        public int IdTelefone { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        /// <summary>
        /// Complemento
        /// </summary>
        public string Descricao { get; set; }
    }
}
