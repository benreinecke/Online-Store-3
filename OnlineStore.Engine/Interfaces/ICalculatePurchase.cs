//Avery Penn
//Interface for general Calculations used afer an user has decided they want to checkout

public interface ICalculatePurchase
{
    double calculateTotal(Cart cart);
    double applyDiscount(Product product, Sale sale);
}