using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ctesp2022_final_gg.BLL
{
    public class ExtratoBancarioBLL
    {
        public List<ModelView.ExtratoBancario> extrato(ContaBancaria contaBancaria)
        {
            double saldoBalanco = contaBancaria.SaldoCorrente;
            foreach (var transacao in contaBancaria.Transacoes.OrderByDescending(x=> x.Dia))
            {
                
                double totalCredito = 0;
                double totalDebito = 0;
                DateTime data = transacao.Dia;
               // List < ModelView.ExtratoBancario > = new List<>();
                if(data == transacao.Dia)
                {

                    double totalCreditoBalanco = 0;
                    double totalDebitoBalanco = 0;
                    if(transacao.TipoTransacaoId == TipoTransacao.Credito)
                    {
                        totalCreditoBalanco += transacao.Valor;
                        saldoBalanco -= transacao.Valor; 

                    }
                    else
                    {
                        totalDebitoBalanco += transacao.Valor;
                        saldoBalanco += transacao.Valor;
                    }

                    totalCredito += totalCreditoBalanco;
                    totalDebito += totalDebitoBalanco;

                    
                }


            }

            return new List<ModelView.ExtratoBancario>();
        }

    }
}
