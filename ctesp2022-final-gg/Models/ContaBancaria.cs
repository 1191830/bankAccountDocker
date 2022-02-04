using System.Collections.Generic;


namespace ctesp2022_final_gg
{
    public class ContaBancaria
    {
        /// <summary>
        /// ContaBancaria ID
        /// </summary>
        public int ContaId { get; set; }
        public int NumeroConta { get; set; }
        public int IBAN { get; set; }
        public double SaldoCorrente { get; set; }


        /// <summary>
        /// ID do cliente da conta bancaria
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Cliente da conta bancaria
        /// </summary>
        public Cliente Cliente { get; set; }


        /// <summary>
        /// Lista das transações
        /// </summary>
        public List<Transacoes> Transacoes { get; set; }

    }
}
