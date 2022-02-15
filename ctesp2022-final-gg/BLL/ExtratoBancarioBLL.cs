using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ctesp2022_final_gg.ModelView;
namespace ctesp2022_final_gg.BLL
{
    public class ExtratoBancarioBLL
    {
        public ExtratoBancario extratoFinal(ContaBancaria contaBancaria)
        {

            // saldo inicial da conta bancária
            double saldoBalanco = contaBancaria.SaldoCorrente;

            //inicializar saldo totais
            double totalCredito = 0;
            double totalDebito = 0;


            //inilicializar saldos diarios
            double totalCreditoDiario = 0;
            double totalDebitoDiario = 0;


            // Novo Extrato bancario
            ExtratoBancario extrato = new ExtratoBancario();
            extrato.Historico = new List<SaldoDiario>();

            // se não houver transações retorna nulo
            if (!contaBancaria.Transacoes.Any()) {

                return null;
            }

            //ultimo dia ou primeiro inversamente
            DateTime dia = contaBancaria.Transacoes.LastOrDefault().Dia;



            

            // Método
            foreach (var transacao in contaBancaria.Transacoes.OrderByDescending(x => x.Dia))
            {


                //mudança de data
                if (!dia.Equals(transacao.Dia))
                {


                    //calculo do novo saldo
                    saldoBalanco = saldoBalanco - totalCreditoDiario - totalDebitoDiario;
                    Console.WriteLine(dia);
                    Console.WriteLine("total debito diário: " + totalDebitoDiario);
                    Console.WriteLine("total credito diário: " + totalCreditoDiario);
                    Console.WriteLine("total balanço: " + saldoBalanco);
                    SaldoDiario saldoDiario = new SaldoDiario();
                    saldoDiario.DataSaldoDiario = dia;
                    saldoDiario.ValorDoSaldoDiario = saldoBalanco;
                    extrato.Historico.Add(saldoDiario);
                    Console.WriteLine("----------------------------------------------");
                    //repor os saldos débito/créditos diários e nova data
                    totalDebitoDiario = 0;
                    totalCreditoDiario = 0;
                    dia = transacao.Dia;
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


            //calculo do saldo no fim
            saldoBalanco = saldoBalanco - totalCreditoDiario - totalDebitoDiario;
            Console.WriteLine(dia);
            Console.WriteLine("total debito diário: " + totalDebitoDiario);
            Console.WriteLine("total credito diário: " + totalCreditoDiario);
            Console.WriteLine("total balanço: " + saldoBalanco);
            SaldoDiario saldoDiarioFinal = new SaldoDiario();
            saldoDiarioFinal.DataSaldoDiario = dia;
            saldoDiarioFinal.ValorDoSaldoDiario = saldoBalanco;
            extrato.Historico.Add(saldoDiarioFinal);


            Console.WriteLine("###############################################################");


            Console.WriteLine("Total Crédito: " + totalCredito);
            extrato.TotalCredito = totalCredito;
            Console.WriteLine("Total de débito: " + totalDebito);
            extrato.TotalDebito = totalDebito;

            Console.WriteLine("###############################################################");

            Console.WriteLine("TOTAL CREDITO:  " + extrato.TotalCredito);
            Console.WriteLine("TOTAL DEBITO:  " + extrato.TotalDebito);
            foreach (var saldia in extrato.Historico)
            {

                Console.WriteLine(saldia.DataSaldoDiario + "  " + saldia.ValorDoSaldoDiario);

            }

            return extrato;


        }


    }

    }

