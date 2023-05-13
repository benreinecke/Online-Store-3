public class Category
{
    private string categoryName;
    private List<Product> products;

    public Category(string categoryName)
    {
        this.categoryName = categoryName;
        this.products = new List<Product>();
    }

    public void addProduct(Product product)
    {
        products.Add(product);
    }

    public string getCategoryName()
    {
        return this.categoryName;
    }

    public string getProducts()
    {
        return this.products;
    }

    public bool lookupProduct(Product product)
    {
        this.products.Contains(product);
        return true;
    }
}
