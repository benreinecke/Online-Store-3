using MySqlConnector;

namespace OnlineStore.OnlineStore.Accessor
{
    public static class ProductAccessor : Interfaces.IProductAccessor
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

        private static string getProductStringProperty(MySqlConnection conn, string SKU, string property)
        {
            string sql = "SELECT " + property + " FROM Product WHERE SKU = " + SKU;
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader result = command.ExecuteReader();
            return result.GetString(0);
        }

        private static string getProductIntProperty(MySqlConnection conn, string SKU, string property)
        {
            string sql = "SELECT " + property + " FROM Product WHERE SKU = " + SKU;
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader result = command.ExecuteReader();
            return result.GetInt64(0);
        }

        private static Category getProductCategory(MySqlConnection conn, string SKU)
        {
            string categoryName = getProductStringCategory(MySqlConnection conn, string SKU);
            Category category = Inventory.lookupCategoryByString(categoryName);
            if (category == null)
            {
                category = new Category(categoryName);
                Inventory.addCategory(category);
            }
            return category;
        }

        private static string getProductName(MySqlConnection conn, string SKU)
        {
            return getProductStringProperty(conn, SKU, "name");
        }

        private static string getProductDescription(MySqlConnection conn, string SKU)
        {
            return getProductStringProperty(conn, SKU, "description");
        }

        private static string getProductManufacturerInfo(MySqlConnection conn, string SKU)
        {
            return getProductStringProperty(conn, SKU, "manufacturerInfo");
        }

        private static int getProductRating(MySqlConnection conn, string SKU)
        {
            return getProductIntProperty(conn, SKU, "rating");
        }

        private static int getProductWeight(MySqlConnection conn, string SKU)
        {
            return getProductIntProperty(conn, SKU, "weight");
        }

        private static int getProductPriceInCents(MySqlConnection conn, string SKU)
        {
            return getProductIntProperty(conn, SKU, "priceInCents");
        }

        private static string getProductDimensions(MySqlConnection conn, string SKU)
        {
            return getProductStringProperty(conn, SKU, "dimensions");
        }

        //Interface methods

        public static Product getProductFromDatabaseBySKU(MySqlConnection conn, string SKU)
        {
            Category category = getProductCategory(conn, SKU);
            string name = getProductName(conn, SKU);
            string description = getProductDescription(conn, SKU);
            string manufacturerInfo = getProductManufacturerInfo(conn, SKU);
            int rating = getProductRating(conn, SKU);
            int weight = getProductWeight(conn, SKU);
            int priceInCents = getProductPriceInCents(conn, SKU);
            string dimensions = getProductDimensions(conn, SKU);

            Product product = new Product(category, SKU, name, description, manufacturerInfo, rating, weight, priceInCents, dimensions);
            category.addProduct(product);

            return product;
        }

        public static Product getProductFromDatabaseBySKU(string SKU)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                Category category = getProductCategory(conn, SKU);
                string name = getProductName(conn, SKU);
                string description = getProductDescription(conn, SKU);
                string manufacturerInfo = getProductManufacturerInfo(conn, SKU);
                int rating = getProductRating(conn, SKU);
                int weight = getProductWeight(conn, SKU);
                int priceInCents = getProductPriceInCents(conn, SKU);
                string dimensions = getProductDimensions(conn, SKU);

                Product product = new Product(category, SKU, name, description, manufacturerInfo, rating, weight, priceInCents, dimensions);
                category.addProduct(product);

                return product;
            }
        }

        public static removeProductFromDatabaseBySKU(string SKU)
        {
            string sql = "DELETE FROM Product WHERE SKU = " + SKU;
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader result = command.ExecuteReader();
            return result.GetString(0);
        }

        public static List<Product> getAllProductsFromDatabase()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = "SELECT SKU FROM Product";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader result = command.ExecuteReader();
                while (result.Read())
                {
                    string SKU = result.GetString(0);
                    getProductFromDatabaseBySKU(SKU);
                }
            }
        }
    }
}
