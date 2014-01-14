using System.Collections.Generic;
using System.Web.Http;
using HandheldServer.Models;

namespace HandheldServer.Controllers
{
    public class ExpensesController : ApiController
    {
        static readonly IExpenseRepository expensesRepository = new ExpenseRepository();
        
        public IEnumerable<Expense> GetBatchOfExpensesByStartingID(int ID, int CountToFetch)
        {
            return expensesRepository.Get(ID, CountToFetch);
        }

    }
}
