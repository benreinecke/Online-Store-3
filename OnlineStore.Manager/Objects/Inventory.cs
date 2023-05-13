public static class Inventory
{
    private static List<Sale> sales = new List<Sale>();
    private static List<Product> products = new List<Product>();
    private static List<Category> categories = new List<Category>();

    public static List<Category> getCategories()
    {
        return this.categories;
    }
    public static List<Product> getProducts()
    {
        return this.products;
    }
    public static List<Sale> getSales()
    {
        return this.sales;
    }
    public static void addCategory(Category category)
    {
        this.categories.Add(category);
    }
    public static void addProducts(Product product)
    {
        this.products.Add(product);
    }
    public static void addSales(Sale sale)
    {
        this.sales.Add(sale);
    }
    public static bool lookupProduct(Product product)
    {
        return this.products.Contains(product);
    }
    public static bool lookupSale(Sale sale)
    {
        return this.sales.Contains(sale);
    }
    public static bool lookupCategory(Category category)
    {
        return this.categories.Contains(category);
    }
    public static Category lookupCategoryByString(string categoryName)
    {
        IEnumerable<Category> category = this.categories.Where(category => category.name == categoryName);
        if (category.ToList().Count == 0)
        {
            return null;
        }
        return category[0];
    }
}
