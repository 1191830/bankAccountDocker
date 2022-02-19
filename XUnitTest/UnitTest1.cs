using Xunit;
using System;
using ctesp2022_final_gg;
using ctesp2022_final_gg.BLL;
using System.Collections.Generic;
using ctesp2022_final_gg.ModelView;

namespace XunitTest
{
    public class UnitTest1
    {

                ContaBancaria contaBancaria = new ContaBancaria()
                {
                    ContaBancariaId = 2,
                    NumeroConta = 123456789,
                    IBAN = "Bruno",
                    SaldoCorrente = 100,
                    ClienteId = 1,
                    Transacoes = new List<Transacao>()
                    {
                        new Transacao()
                        {
                            TransacaoId = 1,
                            Dia = DateTime.Parse( "2022-02-14T00:00:00"),
                            Valor = 100,
                            ContaBancariaId = 1,
                            TipoTransacaoId = 1,
                            TipoTransacao = new TipoTransacao()
                            {
                                TipoTransacaoId = 1,
                                NomeTipoTransacao = "Credito"
                            }
                        },
                         new Transacao()
                        {
                            TransacaoId = 2,
                            Dia = DateTime.Parse( "2022-02-14T15:00:00"),
                            Valor = -50,
                            ContaBancariaId = 1,
                            TipoTransacaoId = 2,
                            TipoTransacao = new TipoTransacao()
                            {
                                TipoTransacaoId = 2,
                                NomeTipoTransacao = "Debito"
                            }
                        },
                          new Transacao()
                        {
                            TransacaoId = 3,
                            Dia = DateTime.Parse( "2022-02-15T00:00:00"),
                            Valor = -20,
                            ContaBancariaId = 1,
                            TipoTransacaoId = 2,
                            TipoTransacao = new TipoTransacao()
                            {
                                TipoTransacaoId = 2,
                                NomeTipoTransacao = "Debito"
                            }
                        },
                           new Transacao()
                        {
                            TransacaoId = 4,
                            Dia = DateTime.Parse( "2022-02-15T15:00:00"),
                            Valor = 10,
                            ContaBancariaId = 1,
                            TipoTransacaoId = 1,
                            TipoTransacao = new TipoTransacao()
                            {
                                TipoTransacaoId = 1,
                                NomeTipoTransacao = "Credito"
                            }
                        },
                            new Transacao()
                        {
                            TransacaoId = 5,
                            Dia = DateTime.Parse( "2022-02-16T00:00:00"),
                            Valor = -20,
                            ContaBancariaId = 1,
                            TipoTransacaoId = 2,
                            TipoTransacao = new TipoTransacao()
                            {
                                TipoTransacaoId = 2,
                                NomeTipoTransacao = "Debito"
                            }
                        },
                             new Transacao()
                        {
                            TransacaoId = 6,
                            Dia = DateTime.Parse( "2022-02-16T12:00:00"),
                            Valor = 10,
                            ContaBancariaId = 1,
                            TipoTransacaoId = 1,
                            TipoTransacao = new TipoTransacao()
                            {
                                TipoTransacaoId = 1,
                                NomeTipoTransacao = "Credito"
                            }
                        }
                    }
        };

        ExtratoBancario extrato = new ExtratoBancario();
        List<SaldoDiario> SaldoDiarios = new List<SaldoDiario>();
        SaldoDiario saldoDiario1 = new SaldoDiario() {
            DataSaldoDiario = DateTime.Parse("2022-02-16T00:00:00"),
            ValorDoSaldoDiario = 110
        };
        SaldoDiario saldoDiario2 = new SaldoDiario()
        {
            DataSaldoDiario = DateTime.Parse("2022-02-15T00:00:00"),
            ValorDoSaldoDiario = 120
        };
        SaldoDiario saldoDiario3 = new SaldoDiario()
        {
            DataSaldoDiario = DateTime.Parse("2022-02-14T00:00:00"),
            ValorDoSaldoDiario = 70

        };
        


        [Fact]
        public void ExtratoFinalTest()
        {
            SaldoDiarios.Add(saldoDiario1);
            SaldoDiarios.Add(saldoDiario2);
            SaldoDiarios.Add(saldoDiario3);

            extrato.Historico = SaldoDiarios;
            extrato.TotalCredito = 120;
            extrato.TotalDebito = -90;
            
            Assert.Equal(extrato, ExtratoBancarioBLL.extratoFinal(contaBancaria));
        }
        

        [Fact]
        public void CalculoSaldoDiarioTest_ShouldReturnTrue()
        {
           // ExtratoBancarioBLL extratoBancarioBLL = new ExtratoBancarioBLL();
            double expected = 0;
            double result = ExtratoBancarioBLL.CalculoSaldoDiario(40, 20, 20);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculoSaldoDiarioTest_ShouldReturnFalse()
        {
            //ExtratoBancarioBLL extratoBancarioBLL = new ExtratoBancarioBLL();
            double expected = 0;
            double result = ExtratoBancarioBLL.CalculoSaldoDiario(50, 20, 20);
            Assert.NotEqual(expected, result);
        }
    }
}
