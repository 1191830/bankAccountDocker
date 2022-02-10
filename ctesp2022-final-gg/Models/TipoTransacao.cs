using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ctesp2022_final_gg
{
    public class TipoTransacao
    {
        public const int Credito = 1, Debito = 2;

        /// <summary>
        /// tipoTransacao ID
        /// </summary>
        public int TipoTransacaoId { get; set; }
        [Required]
        [MaxLength(20)]
        public string NomeTipoTransacao { get; set; }



    }
}
