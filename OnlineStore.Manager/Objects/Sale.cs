public class Sale
{
    private Category category;
    private Product product;

    private DateTime start;
    private DateTime end;

    private int percentOff;

    public Sale(Category category, DateTime start, DateTime end, int percentOff)
    {
        this.category = category;
        this.start = start;
        this.end = end;
        this.percentOff = percentOff;
    }

    public Sale(Product product, DateTime start, DateTime end, int percentOff)
    {
        this.product = product;
        this.start = start;
        this.end = end;
        this.percentOff = percentOff;
    }

    public int checkCategory(Category category)
    {
        if (category == null || category != this.category || new DateTimeOffset(DateTime.Now) - new DateTimeOffset(end) > 0)
        {
            return -1;
        }
        return this.percentOff;
    }

    public int checkProduct(Product product)
    {
        if (product == null || product != this.product || new DateTimeOffset(DateTime.Now) - new DateTimeOffset(end) > 0)
        {
            return -1;
        }
        return this.percentOff;
    }
}
