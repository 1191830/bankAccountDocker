using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ctesp2022_final_gg
{
    public class ContaBancaria
    {
        /// <summary>
        /// ContaBancaria ID
        /// </summary>
        public int ContaBancariaId { get; set; }
        
        public int NumeroConta { get; set; }
        [MaxLength(50)]
        public string IBAN { get; set; }
        public double SaldoCorrente { get; set; }


        /// <summary>
        /// ID do cliente da conta bancaria
        /// </summary>
        public int ClienteId { get; set; }

        /// <summary>
        /// Cliente da conta bancaria
        /// </summary>
        public Cliente Cliente { get; set; }


        /// <summary>
        /// Lista das transações
        /// </summary>
        public List<Transacao> Transacoes { get; set; }

    }
}
