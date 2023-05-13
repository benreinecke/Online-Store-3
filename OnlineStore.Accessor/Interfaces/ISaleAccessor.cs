namespace OnlineStore.OnlineStore.Accessor.Interfaces
{
    public interface ISaleAccessor
    {
        Sale GetSaleFromDatabase(int saleId);
        void RemoveSaleFromDatabase(int saleId);
    }
}
