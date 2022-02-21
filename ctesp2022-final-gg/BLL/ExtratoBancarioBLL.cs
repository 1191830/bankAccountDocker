using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ctesp2022_final_gg.ModelView;
namespace ctesp2022_final_gg.BLL
{
    public class ExtratoBancarioBLL
    {
        public static ExtratoBancario extratoFinal(ContaBancaria contaBancaria)
        {

            double saldoBalanco = contaBancaria.SaldoCorrente;

            //inicializar saldo totais
            double totalCredito = 0;
            double totalDebito = 0;


            // Novo Extrato bancario
            ExtratoBancario extrato = new ExtratoBancario();
            extrato.Historico = new List<SaldoDiario>();


            if (!contaBancaria.Transacoes.Any())
            {

                Console.Write("vazio");

            }

            //ultimo dia ou primeiro inversamente
            DateTime dia = contaBancaria.Transacoes.LastOrDefault().Dia.Date;


            //inilicializar saldos diarios
            double totalCreditoDiario = 0;
            double totalDebitoDiario = 0;

            // Método
            foreach (var transacao in contaBancaria.Transacoes.OrderByDescending(x => x.Dia.Date))
            {


                //mudança de data
                if (!dia.Equals(transacao.Dia.Date))
                {

                    //calculo do novo saldo
                    saldoBalanco = CalculoSaldoDiario(saldoBalanco, totalCreditoDiario, totalDebitoDiario);
                    
                    extrato.Historico.Add(SaldoDiarioTransacao(dia, saldoBalanco));
                  
                    //repor os saldos débito/créditos diários e nova data
                    totalDebitoDiario = 0;
                    totalCreditoDiario = 0;
                    dia = transacao.Dia.Date;
                }

                if (transacao.TipoTransacaoId == TipoTransacao.Credito)
                {
                    //total Crédito global
                    totalCredito += transacao.Valor;
                    //total diário
                    totalCreditoDiario += transacao.Valor;
                }
                else
                {
                    // total de débito global
                    totalDebito += transacao.Valor;
                    //total débito diário
                    totalDebitoDiario += transacao.Valor;
                }


            }


            //calculo do novo saldo
            saldoBalanco = CalculoSaldoDiario(saldoBalanco ,totalCreditoDiario,totalDebitoDiario);
            extrato.Historico.Add(SaldoDiarioTransacao(dia,saldoBalanco));


            extrato.TotalCredito = totalCredito;
            extrato.TotalDebito = totalDebito;
           
            return extrato;


        }
        public static SaldoDiario SaldoDiarioTransacao(DateTime dia, double saldoBalanco)
        {
            SaldoDiario saldoDiarioFinal = new SaldoDiario();
            saldoDiarioFinal.DataSaldoDiario = dia.Date;
            saldoDiarioFinal.ValorDoSaldoDiario = saldoBalanco;
            return saldoDiarioFinal;
        }

        public static double CalculoSaldoDiario(double saldoBalanco, double totalCreditoDiario, double totalDebitoDiario)
        {
            return saldoBalanco - totalCreditoDiario - totalDebitoDiario;
        }

    }

}