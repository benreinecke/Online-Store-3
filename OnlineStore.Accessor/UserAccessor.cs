using MySqlConnector;

namespace OnlineStore.OnlineStore.Accessor
{
    public class UserAccessor : Interfaces.IUserAccessor
    {
        private const string connectionString = ""; //Use connection string to your own local database

        private static bool TestConnection(MySqlConnection conn)
        {
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        //Accessors for each individual field

        private static string GetUsername(MySqlConnection conn, int userId)
        {
            string sql = "SELECT username FROM User WHERE userId = " + userId;
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader result = command.ExecuteReader();
            return result.GetString(0);
        }

        private static string GetPassword(MySqlConnection conn, int userId)
        {
            string sql = "SELECT password FROM User WHERE userId = " + userId;
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader result = command.ExecuteReader();
            return result.GetString(0);
        }

        //Interface methods

        public User GetUserFromDatabase(int userId)
        {
            string username = "";
            string password = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                if (TestConnection(conn))
                {
                    username = GetUsername(conn, userId);
                    password = GetPassword(conn, userId);
                }
                conn.Close();
            }

            return new User(username, password, false);
        }

        public void RemoveUserFromDatabase(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                if (TestConnection(conn))
                {
                    string sql = "DELETE FROM User WHERE userId = " + userId;
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
