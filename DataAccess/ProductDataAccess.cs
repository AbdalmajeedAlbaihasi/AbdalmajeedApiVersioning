namespace DataAccess
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class ProductDataAccess
    {

        public async Task<Product> GetProduct()
        {
            var product = new Product { Id = 1, Name = "Laptop", Price = 25000, CategoryName = "Electronics" };
            return await Task.FromResult(product);
        }
    }
}