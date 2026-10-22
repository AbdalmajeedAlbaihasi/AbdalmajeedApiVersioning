using DataAccess;

namespace Business
{
    public class ProductBusiness
    {
        private readonly ProductDataAccess _productDataAccess;


        public ProductBusiness(ProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }


        public async Task<Product> GetProduct()
        {
            return await _productDataAccess.GetProduct();
        }
    }
}