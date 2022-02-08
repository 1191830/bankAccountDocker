using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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
     //   private CodeContext db;

        public ContaBancariaController(ILogger<ContaBancariaController> logger)
        {
       //     db = new CodeContext();
            _logger = logger;
        }

        /// <summary>
        /// GET ContaBancaria return   in the buildings list
        /// </summary>
        /// <returns>All the ContaBancaria in the ContaBancaria list</returns>
        [HttpGet]
        public IEnumerable<ContaBancaria> Get()
        {
            // List<ContaBancaria> result = db.ContaBancaria.ToList();
            List<ContaBancaria> list = new List<ContaBancaria>();
            return list;
         //  return result;
        }

        /// <summary>
        /// GET ContaBancaria by ID return ContaBancaria with ID given
        /// </summary>
        /// <returns>A ContaBancaria with given Id</returns>
        [HttpGet("{Id}")]
        public ContaBancaria Get(int Id)
        {
            //   var result = db.ContaBancaria.Where(x => x.ContaId == Id).FirstOrDefault();
            return new ContaBancaria();
           // return result;
        }

        /// <summary>
        /// CREATE building creates a new ContaBancaria assigning new ID and adding to the ContaBancaria list
        /// </summary>
        [HttpPost]
        public IActionResult Create(ContaBancaria contaBancaria)
        {
          //  db.ContaBancaria.Add(contaBancaria);
          //  db.SaveChanges();
            // This code will save the ContaBancaria and return a result
            return CreatedAtAction(nameof(Create), new { id = contaBancaria.ContaId }, contaBancaria);
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
