//Avery Penn 
//Calculations for when an user is going to checkout
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

public class CalculatePurchase : ICalculatePurchase
{ 

    public int applyDiscount(Product product, Sale sale)
    {
        int Cost = product.getPriceInCents() * (1-sale.getPercent());
        return Cost;
    }
    public int applyDiscount(Product product, int discountPercent)
    {
        int Cost = product.getPriceInCents() * (1-discountPercent);
        return Cost;
    }

    //Finds the best discount for each product and applys the discount to all items
    public int calculateTotal(Cart cart)
    {
        int TotalCost = 0;
        foreach (Product product in cart.getProducts().Keys)
        {
            int amount_product = 1;
            bool productHasAmount = cart.getProducts().TryGetValue(product, out amount_product);
            int productFinalPrice = product.getPriceInCents();
            int bestDiscount = LocateDiscountsForProduct.findHighestDiscount(product);
            if(bestDiscount != -1)
            {
                productFinalPrice = applyDiscount(product,bestDiscount);
            }

            TotalCost += productFinalPrice * amount_product;
        }
        return TotalCost;
    }
}