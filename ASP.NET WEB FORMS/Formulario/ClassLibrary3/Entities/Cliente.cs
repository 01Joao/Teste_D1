using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Dados do Cliente
    /// </summary>
   public class Cliente
    { 
        /// <summary>
        /// Identificador do Cliente
        /// </summary>
        public int IdCliente { get; set; }
        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Numero do CPF do Cliente
        /// </summary>
        public string Cpf { get; set; }
        /// <summary>
        /// Data de Nascimento do Cliente
        /// </summary>
        public string DataNascimento { get; set; }
        /// <summary>
        /// Numero do RG do Cliente
        /// </summary>
        public string RG { get; set; }     
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
    }   
}
