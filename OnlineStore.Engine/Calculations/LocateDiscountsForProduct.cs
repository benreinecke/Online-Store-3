public static class LocateDiscountsForProduct : ILocateDiscountsForProduct
{
    //Used to return the higher of either the catagory discount or product discount
    public static int findHighestDiscount(Product product)
    {
        int categoryDiscount = findDiscountFromCatagory(product.getCategory());
        int productDisount = findDiscountFromProduct(product);
        return Math.Max(categoryDiscount, productDisount);
    }

    public static int findDiscountFromCatagory(Category catagory)
    {
        int maxDiscount = -1;
        //Get All Sales
        foreach (Sale sale in DatabaseObjectsOverview.getSaleList())
        {
            int newDiscount = sale.checkCategory(category);
            maxDiscount = Math.Max(maxDiscount, newDiscount);
        }
        return maxDiscount;
    }

    public static int findDiscountFromProduct(Product product)
    {
        int maxDiscount = -1;
        //Get All Sales
        foreach (Sale sale in Inventory.getSales())
        {
            int newDiscount = sale.checkProduct(product);
            maxDiscount = Math.Max(maxDiscount, newDiscount);
        }
        return maxDiscount;
    }

}
