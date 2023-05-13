import Money;

public class Cart
{
    private IDictionary<Product, int> products;
    private User user;

    public Cart(User user)
    {
        this.user = user;
        this.products = new IDictionary<Product, int>();
    }

    public IDictonary<Product, int> getProducts()
    {
        return this.products;
    }

    public string getTotal(bool afterSale)
    {
        int total = 0;
        // TODO: Calculate total of all products
        // If afterSale is true, then calculate
        // the price of the products with the
        // sale price included. If false, use
        // the original price.
        Money.centsToString(total);
        return totalString;
    }

    public void addProduct(Product product)
    {
        this.products.Add(product, 1);
    }

    public void increaseQuantity(Product product, int increment)
    {
        this.products[product] += increment;
    }

    public void decreaseQuantity(Product product, int decrement)
    {
        this.products[product] -= decrement;
        if (this.products[product] <= 0)
        {
            removeProduct(product);
        }
    }

    public void removeProduct(Product product)
    {
        this.products.Remove(product);
    }
}
