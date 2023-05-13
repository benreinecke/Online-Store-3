//Avery Penn
//Interface for Ensuring before purchases/Adding to cart that there is an item in stock
public interface IVerifyStock
{
    public bool verifyProductQuantityInStorage(Product product, int amount);
}
