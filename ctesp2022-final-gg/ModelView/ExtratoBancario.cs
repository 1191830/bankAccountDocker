using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ctesp2022_final_gg.ModelView
{
    public class ExtratoBancario
    {
        /// <summary>
        /// Model View extract account
        /// </summary>
        public double TotalCredito { get; set; }
        public double TotalDebito { get; set; }
        public List<SaldoDiario> Historico { get; set; }

    }
}
