using MySqlConnector;

namespace OnlineStore.OnlineStore.Accessor
{
    public class SaleAccessor : Interfaces.ISaleAccessor
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

        private static double GetPercentOff(MySqlConnection conn, int saleId)
        {
            string sql = "SELECT percentOff FROM Sale WHERE saleId = " + saleId;
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader result = command.ExecuteReader();
            return result.GetDouble(0);
        }

        private static DateTime GetStartDate(MySqlConnection conn, int saleId)
        {
            string sql = "SELECT startDate FROM Sale WHERE saleId = " + saleId;
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader result = command.ExecuteReader();
            return result.GetDateTime(0);
        }

        private static DateTime GetEndDate(MySqlConnection conn, int saleId)
        {
            string sql = "SELECT endDate FROM Sale WHERE saleId = " + saleId;
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader result = command.ExecuteReader();
            return result.GetDateTime(0);
        }
        
        //Interface methods

        public Sale GetSaleFromDatabase(int saleId)
        {
            double percentOff = 0;
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                if (TestConnection(conn))
                {
                    percentOff = GetPercentOff(conn, saleId);
                    startDate = GetStartDate(conn, saleId);
                    endDate = GetEndDate(conn, saleId);
                }
                conn.Close();
            }

            return new Sale(null, startDate, endDate, percentOff);
        }

        public void RemoveSaleFromDatabase(int saleId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                if (TestConnection(conn))
                {
                    string sql = "DELETE FROM Sale WHERE saleId = " + saleId;
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
