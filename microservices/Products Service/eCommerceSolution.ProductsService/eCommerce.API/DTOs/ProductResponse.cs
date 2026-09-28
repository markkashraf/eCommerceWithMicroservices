namespace eCommerce.API.DTOs
{
    public class ProductResponse
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
    }
}
