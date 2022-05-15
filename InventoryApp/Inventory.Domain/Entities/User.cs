namespace Inventory.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public byte Age { get; set; }

        // relationshipt
        public List<Invoice> Invoices { get; set; }
    }
}
