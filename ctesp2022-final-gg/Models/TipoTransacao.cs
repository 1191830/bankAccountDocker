using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ctesp2022_final_gg
{
    public class TipoTransacao
    {
        /// <summary>
        /// tipoTransacao ID
        /// </summary>
        public int TipoTransacaoId { get; set; }
        [Required]
        [MaxLength(20)]
        public string NomeTipoTransacao { get; set; }



    }
}
