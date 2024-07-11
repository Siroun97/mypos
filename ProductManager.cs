using System.Data.SqlClient;
using System.Data;
using System;
using SimplePOS;

public class productManager
{
    private readonly string connectionString = "Server=WIN-CEARVOQ7M2N\\SQLEXPRESS;Database=pos;Integrated Security=True;";

    public productManager()
    {
    }

    public DataTable GetAllProducts()
    {
        DataTable dataTable = new DataTable();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error fetching products: " + ex.Message);
            // Consider throwing a more specific exception or returning an error code
        }

        return dataTable;
    }

    public void DeleteProduct(int ProductID)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ProductID", ProductID);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Product deleted successfully.");
                }
                else
                {
                    Console.WriteLine("No product found with ID: " + ProductID);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting product: " + ex.Message);
            // Consider throwing a more specific exception or logging the error
        }
    }



    public decimal endOfDayAmount()
    {
        decimal totalSum = 0;

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Corrected SQL query to retrieve the sum of TotalAmount
                string query = "SELECT SUM(TotalAmount) FROM todaySales";
                SqlCommand command = new SqlCommand(query, connection);
                

                // ExecuteScalar() is used to retrieve a single value (the sum) from the query
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    totalSum = Convert.ToDecimal(result);
                    Console.WriteLine("Sum of TotalAmount: " + totalSum);
                }
                else
                {
                    Console.WriteLine("No sales found");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving sum of TotalAmount: " + ex.Message);
            // Consider throwing a more specific exception or logging the error
        }

        return totalSum;
    }




    public void endOfDay()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Delete all records from todaySaleItems table
                string querySaleItems = "DELETE FROM todaySaleItems";
                SqlCommand commandSaleItems = new SqlCommand(querySaleItems, connection);
                int rowsAffectedSaleItems = commandSaleItems.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffectedSaleItems} records deleted from todaySaleItems table.");

                // Delete all records from todaySales table
                string querySales = "DELETE FROM todaySales";
                SqlCommand commandSales = new SqlCommand(querySales, connection);
                int rowsAffectedSales = commandSales.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffectedSales} records deleted from todaySales table.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting products: " + ex.Message);
            // Consider throwing a more specific exception or logging the error
        }
    }



    public DataTable SearchProducts(string searchText, int quantity)
    {
        DataTable dataTable = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Products WHERE (Name LIKE @searchText OR Barcode LIKE @searchText) AND Quantity >= @quantity and isActive=1";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                command.Parameters.AddWithValue("@quantity", quantity);

                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
        }

        return dataTable;
    }


    

    public bool DecrementProductQuantity(int productId, int quantityToDecrement)
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.Transaction = connection.BeginTransaction(); // Start transaction

                try
                {
                    // Decrement quantity and check if it becomes zero
                    string updateSql = "UPDATE Products SET Quantity = CASE WHEN Quantity - @QuantityToDecrement < 0 THEN 0 ELSE Quantity - @QuantityToDecrement END WHERE ProductID = @ProductID; SELECT Quantity FROM Products WHERE ProductID = @ProductID";
                    command.CommandText = updateSql;
                    command.Parameters.AddWithValue("@ProductID", productId);
                    command.Parameters.AddWithValue("@QuantityToDecrement", quantityToDecrement);

                    int remainingQuantity = Convert.ToInt32(command.ExecuteScalar());
                    if (remainingQuantity == 0)
                    {
                        // Update IsActive to 0 (inactive) instead of deleting
                        string updateSqlactivity = "UPDATE Products SET IsActive = 0 WHERE ProductID = @ProductID";
                        command.CommandText = updateSqlactivity;
                        command.ExecuteNonQuery();
                    }


                    success = true;
                    command.Transaction.Commit(); // Commit transaction if successful
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error decrementing product quantity: " + ex.Message);
                    command.Transaction.Rollback(); // Rollback on error
                }
            }
        }

        return success;
    }

    internal int GetAvailableStockForProduct(string productName)
    {
        int availableStock = 0;

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Quantity FROM Products WHERE Name = @ProductName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        availableStock = Convert.ToInt32(result);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error getting available stock for product: " + ex.Message);
            // Consider throwing a more specific exception or logging the error
        }

        return availableStock;
    }
    public DataTable GetSalesHistory()
    {
        DataTable salesHistory = new DataTable();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT SaleID, UserID, SaleDate, TotalAmount " +
                               "FROM todaySales " +
                               "ORDER BY SaleDate DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(salesHistory);
                    }
                }
            }
        }
        catch (SqlException sqlEx)
        {
            // Handle SQL specific exceptions
            Console.WriteLine("SQL Error retrieving sales history: " + sqlEx.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine("Error retrieving sales history: " + ex.Message);
        }

        return salesHistory;
    }


}
