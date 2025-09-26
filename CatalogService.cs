namespace Shopmarket
{
    public class CatalogService
    {
        private static List<Product> _products = new List<Product>();
        public CatalogService()
        {

        }
        public void AddProduct(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }
    }
}
