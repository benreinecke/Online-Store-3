namespace OnlineStore.OnlineStore.Accessor.Interfaces
{
    public interface IUserAccessor
    {
        User GetUserFromDatabase(int userId);
        void RemoveUserFromDatabase(int userId);
    }
}
