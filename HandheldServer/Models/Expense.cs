namespace HandheldServer.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string account_id { get; set; }
        public string name { get; set; }
        public int use_on_items { get; set; }
    }
}