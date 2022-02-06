using System.Collections.Generic;

namespace ctesp2022_final_gg
{
    public class Cliente
    {
        /// <summary>
        /// Cliente ID
        /// </summary>
        public int ClientId { get; set; }
        public string NomeCliente { get; set; }
        public string Morada { get; set; }
        public int Contacto { get; set; }
     
   
        /// <summary>
        /// Lista da Contas Bancarias do cliente
        /// </summary>
        public List<ContaBancaria> ContaBancarias { get; set; }
    }
}
