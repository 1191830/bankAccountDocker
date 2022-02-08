using System;
using System.Collections.Generic;


namespace ctesp2022_final_gg
{
    public class Transacao
    {
        /// <summary>
        /// ContaBancaria ID
        /// </summary>
        public int TransacaoId { get; set; }
        public DateTime Dia { get; set; }
        public double Valor { get; set; }


        /// <summary>
        /// ID da conta bancaria
        /// </summary>
        public int ContaId { get; set; }

        /// <summary>
        /// Conta Bancaria
        /// </summary>
        public ContaBancaria ContaBancaria { get; set; }

        /// <summary>
        /// ID da transacao
        /// </summary>
        public int TipoId { get; set; }

        /// <summary>
        /// Tipo de transacao
        /// </summary>
        public TipoTransacao TipoTransacao { get; set; }



    }
}
