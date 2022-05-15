namespace Inventory.Domain.Entities
{
    public class InvoiceDetail
    {
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitPrice { get; set; }
        public int QuantitySold { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        // relationshipt
        public Product Product { get; set; }
        public Invoice Invoice { get; set; }
    }
}
