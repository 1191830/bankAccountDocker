using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ctesp2022_final_gg.Database;
using ctesp2022_final_gg.ModelView;
using ctesp2022_final_gg.Domain;
using ctesp2022_final_gg.BLL;

namespace ctesp2022_final_gg.Controllers
{
    /// <summary>
    /// ContaBancaria Controller responsible for GET/POST/GETTRANSACTION Operations
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ContaBancariaController : ControllerBase
    {
        

        private readonly ILogger<ContaBancariaController> _logger;
        private BankContext db;

        public ContaBancariaController(ILogger<ContaBancariaController> logger)
        {
            db = new BankContext();
            _logger = logger;
        }

        /// <summary>
        /// GET ContaBancaria by ID return ContaBancaria with ID given
        /// </summary>
        /// <returns>A ContaBancaria with given Id</returns>
        [HttpGet("{Id}")]
        public DadosConta Get(int Id)
        {
            var result = db.ContaBancaria.Where(x => x.ContaBancariaId == Id).FirstOrDefault();

            if (result == null) {
                return null;
            }

            var novoId = result.ClienteId;

            var novoResult = db.Cliente.Where(y => y.ClienteId == novoId).FirstOrDefault();

            DadosConta novosDados = new DadosConta();
            novosDados.DadosSaldo = result.SaldoCorrente;
            novosDados.DadosNomeTitular = novoResult.NomeCliente;
            novosDados.DadosMorada = novoResult.Morada;
            novosDados.DadosContactoTitular = novoResult.Contacto;

            return novosDados;
           
        }

        /// <summary>
        /// POST Create a new Transaction
        /// </summary>
        [HttpPost]
        public IActionResult Create(PostTransacao novaTransacao)
        {
            int Id = novaTransacao.IdDaConta;

            var result = db.ContaBancaria.Where(x => x.ContaBancariaId == Id).FirstOrDefault();

            if (result == null )
            {
                return null;
            }

            Transacao trans = new Transacao();

            trans.Dia = DateTime.Now;
            trans.Valor = novaTransacao.ValorDaTransacao;
            trans.ContaBancariaId = novaTransacao.IdDaConta;
            if (novaTransacao.ValorDaTransacao < 0)
            {
                trans.TipoTransacaoId = 1;
            }
            else
            {

                trans.TipoTransacaoId = 2;
            }
            db.Transacao.Add(trans);
            db.SaveChanges();

            result.SaldoCorrente += novaTransacao.ValorDaTransacao;
            db.ContaBancaria.Update(result);
            db.SaveChanges();


            // Vai gravar a transacao e update do saldo e retornar um resultado
            return Content("success");
        }

        /// <summary>
        /// GET ContaBancaria/Transacao by ID return ContaBancaria with ID given
        /// </summary>
        /// <returns>A ContaBancaria with given Id</returns>
        [HttpGet("{Id}/Transacao")]
        public ExtratoBancario GetTransacao(int Id)
        {
            // contabancaria pelo Id
            var contaBancaria = db.ContaBancaria.Where(x => x.ContaBancariaId == Id).FirstOrDefault();

            //Caso a conta não existe
            if (contaBancaria == null)
            {
                return null;
            }

            //Data a 30 dias atrás as 00:00
            DateTime LocalTimeFinal = DateTime.Now.Date.Subtract(TimeSpan.FromDays(30));

            //Buscar as ultimos 30 dias de transações desta conta 
            List<Transacao> transacoes = db.Transacao.Where(x => x.ContaBancariaId == Id && x.Dia <= DateTime.Now && x.Dia >= LocalTimeFinal).OrderBy(x =>x.Dia).ToList();

            //adicionar as Transações a conta bancária
            contaBancaria.Transacoes = transacoes;


            //inializar extrato bancário
            ExtratoBancario extracto = new ExtratoBancario();

            extracto = ExtratoBancarioBLL.extratoFinal(contaBancaria);

            //Caso a conta não tenha transacoes
            if (extracto == null)
            {
                return null;
            }

            return extracto;
        }

    }
}
