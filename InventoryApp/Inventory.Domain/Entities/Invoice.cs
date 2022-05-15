namespace Inventory.Domain.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Concept { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public bool Anulado { get; set; }
        public int UserId { get; set; }

        // relationshipt
        public User User { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
