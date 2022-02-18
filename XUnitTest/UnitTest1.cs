using Xunit;
using System;
using ctesp2022_final_gg;
using ctesp2022_final_gg.BLL;
using System.Collections.Generic;

namespace XunitTest
{
    public class UnitTest1
    {

        Cliente client = new Cliente()
        {
            ClienteId = 1,
            NomeCliente = "Bruno",
            Morada = "Rua da esquina",
            Contacto = 911111111,
            ContaBancarias = new List<ContaBancaria>()
            {
                new ContaBancaria()
                {
                    ContaBancariaId = 2,
                    NumeroConta = 123456789,
                    IBAN = "Bruno",
                    SaldoCorrente = 500,
                    ClienteId = 1,
                    Transacoes = new List<Transacao>()
                    {
                        new Transacao()
                        {
                            TransacaoId = 1,
                            Dia = System.DateTime.Now,
                            Valor = 500,
                            ContaBancariaId = 2,
                            TipoTransacaoId = 1,
                            TipoTransacao = new TipoTransacao()
                            {
                                TipoTransacaoId = 1,
                                NomeTipoTransacao = "Teste"
                            }
                        }
                    }
                }
            }
        };
        [Fact]
        public void extratoFinalTest()
        {
            ExtratoBancarioBLL extratoBancarioBLL = new ExtratoBancarioBLL();
        }
        [Fact]
        public void SaldoDiarioTransacaoTest()
        {
            ExtratoBancarioBLL extratoBancarioBLL = new ExtratoBancarioBLL();

        }
        [Fact]
        public void CalculoSaldoDiarioTest_ShouldReturnTrue()
        {
            ExtratoBancarioBLL extratoBancarioBLL = new ExtratoBancarioBLL();
            double expected = 0;
            //double result = extratoBancarioBLL.CalculoSaldoDiario(40, 20, 20);
           // Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculoSaldoDiarioTest_ShouldReturnFalse()
        {
            ExtratoBancarioBLL extratoBancarioBLL = new ExtratoBancarioBLL();
            double expected = 0;
            //double result = extratoBancarioBLL.CalculoSaldoDiario(50, 20, 20);
            //Assert.NotEqual(expected, result);
        }
    }
}
