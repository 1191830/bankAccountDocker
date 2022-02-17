using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ctesp2022_final_gg.Database;

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
        public ContaBancaria Get(int Id)
        {
            var result = db.ContaBancaria.Where(x => x.ContaBancariaId == Id).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Create a new Transaction
        /// </summary>
        [HttpPost]
        public IActionResult Create(Transacao transacao)
        {
            db.Transacao.Add(transacao);
            db.SaveChanges();
            // Vai gravar a conta e retornar um resultado
            return CreatedAtAction(
                nameof(Create), 
                new { 
                contraBancariaId = transacao.ContaBancariaId,
                dia = DateTime.Now,
                valor = transacao.Valor,
                tipoTransacaoId = transacao.TipoTransacaoId
                },
                transacao);
        }


        /// <summary>
        /// GET ContaBancaria/Transacao by ID return ContaBancaria with ID given
        /// </summary>
        /// <returns>A ContaBancaria with given Id</returns>
        [HttpGet("{Id}/Transacao")]
        public IEnumerable<Transacao> GetTransacao(int Id)
        {
            List<Transacao> result = db.Transacao.Where(x => x.ContaBancariaId == Id).ToList();
            return result;
        }

    }
}
