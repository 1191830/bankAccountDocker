using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ctesp2022_final_gg
{
    public class Cliente
    {
        /// <summary>
        /// Cliente ID
        /// </summary>
        public int ClienteId { get; set; }
        [MaxLength(50)]
        public string NomeCliente { get; set; }
        [MaxLength(50)]
        public string Morada { get; set; }
        public int Contacto { get; set; }
     
   
        /// <summary>
        /// Lista da Contas Bancarias do cliente
        /// </summary>
        public List<ContaBancaria> ContaBancarias { get; set; }
    }
}
