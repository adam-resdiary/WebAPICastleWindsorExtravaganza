using System.Collections.Generic;

namespace HandheldServer.Models
{
    interface IExpenseRepository
    {
        //int Get();
        IEnumerable<Expense> Get(int ID, int CountToFetch);
        Expense Add(Expense item);
    }
}
