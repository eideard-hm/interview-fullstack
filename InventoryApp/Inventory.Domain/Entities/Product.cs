namespace Inventory.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // relationshipt
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
