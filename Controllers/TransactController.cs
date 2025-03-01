using AutoMapper;
using commander.Data;
using commander.Dtos;
using commander.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace commander.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class TransactController : ControllerBase
    {
        private readonly TransactionRepo  _repository;
        private readonly IRateRepo _raterepo;

        public TransactController(TransactionRepo transactionRepo , IRateRepo rateRepo)
  {
    _repository = transactionRepo;
    _raterepo = rateRepo;
  }

    [HttpGet("Transfer")]
    public ActionResult<IEnumerable<Trans>> GetTransactionsWithTransact ()
    {
         _repository.Transact();
        var transactions = _repository.GetAllTransactions();
        return Ok(transactions);
    }
  [HttpGet("Use")]
    public ActionResult<IEnumerable<Trans>> UseAndGetTransactions ()
    {
         _repository.Use();
        var rate = _raterepo.GetRateById(2);
        return Ok(rate);
    }




    }

}
