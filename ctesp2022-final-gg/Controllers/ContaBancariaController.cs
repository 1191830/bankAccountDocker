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
        /// GET ContaBancaria return   in the buildings list
        /// </summary>
        /// <returns>All the ContaBancaria in the ContaBancaria list</returns>
        [HttpGet]
        public IEnumerable<ContaBancaria> Get()
        {
            List<ContaBancaria> result = db.ContaBancaria.ToList();
            return result;

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
        /// CREATE building creates a new ContaBancaria assigning new ID and adding to the ContaBancaria list
        /// </summary>
        [HttpPost]
        public IActionResult Create(ContaBancaria contaBancaria)
        {
            db.ContaBancaria.Add(contaBancaria);
            db.SaveChanges();
            // Vai gravar a conta e retornar um resultado
            return CreatedAtAction(nameof(Create), new { id = contaBancaria.ContaBancariaId }, contaBancaria);

        }


        /// <summary>
        /// GET ContaBancaria/Transacao by ID return ContaBancaria with ID given
        /// </summary>
        /// <returns>A ContaBancaria with given Id</returns>
        [HttpGet("{Id}/Transacao")]
        public IEnumerable<ContaBancaria> GetTransacao(int Id)
        {
            //   var result = db.ContaBancaria.Where(x => x.ContaId == Id).FirstOrDefault();
            return new List<ContaBancaria>(); 
            // return result;
        }



    }
}
