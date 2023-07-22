using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipay.Entity.Repository.TransactionRepository;

namespace Sipay.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository repository;
        public TransactionController(ITransactionRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet("GetByParameter")]
        public IActionResult GetByParameter(int? accountNumber, string referenceNumber,
                                        decimal? minAmountCredit, decimal? maxAmountCredit,
                                        decimal? minAmountDebit, decimal? maxAmountDebit,
                                        string description, DateTime? beginDate, DateTime? endDate)
        {
            var transactions = repository.GetByFilter(accountNumber, referenceNumber,
                                                                 minAmountCredit, maxAmountCredit,
                                                                 minAmountDebit, maxAmountDebit,
                                                                 description, beginDate, endDate);

            return Ok(transactions);
        }
    }
}