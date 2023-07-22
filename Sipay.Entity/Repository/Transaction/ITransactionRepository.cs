using Sipay.Entity.Entity;

namespace Sipay.Entity.Repository.TransactionRepository
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        List<Transaction> GetByReference(string reference);
        IEnumerable<Transaction> GetByFilter(int? accountNumber, string referenceNumber,
                                              decimal? minAmountCredit, decimal? maxAmountCredit,
                                              decimal? minAmountDebit, decimal? maxAmountDebit,
                                              string description, DateTime? beginDate, DateTime? endDate);

    }
}