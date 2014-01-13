using System;
using System.Collections.Generic;
using System.Linq;

namespace HandheldServer.Models
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly List<Expense> expenses = new List<Expense>();

        public ExpenseRepository()
        {
            // TODO: Replace this test data with the actual data, which, in the legacy app, is sent as an XML file that the client then parses
            Add(new Expense { Id = 0, account_id = "7.0", name = "Expense 7", use_on_items = 0 });
            Add(new Expense { Id = 1, account_id = "8.0", name = "Expense 8", use_on_items = 1 });
            Add(new Expense { Id = 2, account_id = "9.0", name = "Expense 9", use_on_items = 1 });
            Add(new Expense { Id = 3, account_id = "10.42", name = "Expense 7", use_on_items = 0 });
            Add(new Expense { Id = 4, account_id = "11.0", name = "Expense 7", use_on_items = 0 });
            Add(new Expense { Id = 5, account_id = "12.5", name = "Expense 8", use_on_items = 1 });
        }

        public IEnumerable<Expense> Get(int ID, int CountToFetch)
        {
            return expenses.Where(i => i.Id > ID).Take(CountToFetch);
        }

        public Expense Add(Expense item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            expenses.Add(item);
            return item;
        }

    }
}