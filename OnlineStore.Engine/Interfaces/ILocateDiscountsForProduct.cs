//Avery Penn
//Interface for support methods to find if any sale belongs to a product
//ThEse Interface is likely to be unneeded after Including Michael's Objects, which
//Might have better ways for getting the highest discount/percent

public interface ILocateDiscountsForProduct
{ 
    public int findDiscountPrecentFromProduct(Product product);
    public int findDiscountPercentFromCatagory(Category catagory);

    public int findHighestDiscountPercentForProduct(Product product);
}

