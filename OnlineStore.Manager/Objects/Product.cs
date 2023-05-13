public class Product
{
    private Category category;
    private string SKU;
    private string name;
    private string description;
    private string manufacturerInfo;
    private int rating;
    private int weight;
    private int priceInCents; //To be used with Money Class
    private string dimensions;

    public Product(Category category, string SKU, string name, string description, string manufacturerInfo,
                    int rating, int weight, int priceInCents, string dimensions)
    {
        this.category = category;
        this.SKU = SKU;
        this.name = name;
        this.description = description;
        this.manufacturerInfo = manufacturerInfo;
        this.rating = rating;
        this.weight = weight;
        this.priceInCents = priceInCents;
        this.dimensions = dimensions;
    }

    public Category getCategory()
    {
        return this.category;
    }
    public string getSKU()
    {
        return this.SKU;
    }
    public int getName()
    {
        return this.name;
    }
    public string getDescription()
    {
        return this.description;
    }
    public string getManufacturerInfo()
    {
        return this.manufacturerInfo;
    }
    public void updateRating(int rating)
    {
        this.rating = rating;
    }
    public int getRating()
    {
        return this.rating;
    }
    public int getWeight()
    {
        return this.weight;
    }
    public int getPriceInCents()
    {
        return this.priceInCents;
    }
    public string getDimensions()
    {
        return this.dimensions;
    }
}

