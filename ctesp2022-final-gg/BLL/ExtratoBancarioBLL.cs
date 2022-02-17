using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ctesp2022_final_gg.ModelView;
namespace ctesp2022_final_gg.BLL
{
    public class ExtratoBancarioBLL
    {
        private double saldoBalanco;

        private double totalCredito;
        private double totalDebito;


        //inilicializar saldos diarios
        private double totalCreditoDiario;
        private double totalDebitoDiario;

        public ExtratoBancario extratoFinal(ContaBancaria contaBancaria)
        {
            // se não houver transações retorna nulo
            if (!contaBancaria.Transacoes.Any())
            {
                return null;
            }

            // saldo inicial da conta bancária
           saldoBalanco = contaBancaria.SaldoCorrente;


            // Novo Extrato bancario
            ExtratoBancario extrato = new ExtratoBancario();
            extrato.Historico = new List<SaldoDiario>();

            //ultimo dia ou primeiro inversamente
            DateTime dia = contaBancaria.Transacoes.LastOrDefault().Dia;

            // Método
            foreach (var transacao in contaBancaria.Transacoes.OrderByDescending(x => x.Dia))
            {

                //mudança de data
                if (!dia.Equals(transacao.Dia))
                {

                    extrato.Historico.Add(
                        saldoDiarioTransacao(dia, calculoSaldoDiario(
                             saldoBalanco, totalCreditoDiario, totalDebitoDiario
                           )
                        )
                    );

                    //repor os saldos débito/créditos diários e nova data
                    totalDebitoDiario = 0;
                    totalCreditoDiario = 0;
                    
                    dia = transacao.Dia;
                }

                somaTotalDiarioDebitoCredito(transacao);
                somaTotalDebitoCredito(transacao);

            }


            //calculo do saldo no fim


            extrato.Historico.Add(
                    saldoDiarioTransacao(dia, calculoSaldoDiario(saldoBalanco, totalCreditoDiario, totalDebitoDiario
                        )
                    )
                );

            extrato.TotalCredito = totalCredito;
            extrato.TotalDebito = totalDebito;
            
            return extrato;


        }

        public SaldoDiario saldoDiarioTransacao(DateTime dia, double saldoBalanco)
        {
            SaldoDiario saldoDiarioFinal = new SaldoDiario();
            saldoDiarioFinal.DataSaldoDiario = dia;
            saldoDiarioFinal.ValorDoSaldoDiario = saldoBalanco;
            return saldoDiarioFinal;
        }

        public double calculoSaldoDiario(double saldoBalanco,double totalCreditoDiario,double totalDebitoDiario)
        {
            return saldoBalanco - totalCreditoDiario - totalDebitoDiario;
        }

        public void somaTotalDiarioDebitoCredito(Transacao transacao)
        {

            if (transacao.TipoTransacaoId == TipoTransacao.Credito)
            {
                //total diário
                totalCreditoDiario += transacao.Valor;
            }
            else
            {
                //total débito diário
                totalDebitoDiario += transacao.Valor;
            }
        }

        public void somaTotalDebitoCredito(Transacao transacao)
        {
            if (transacao.TipoTransacaoId == TipoTransacao.Credito)
            {
                //total Crédito global
                totalCredito += transacao.Valor;
            }
            else
            {
                // total de débito global
                totalDebito += transacao.Valor;
            }

        }
    }

    }

