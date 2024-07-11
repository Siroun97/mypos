using SimplePOS;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;

internal class salesmaager
{
    private readonly databaseManager dbManager;
    string connectionString = "Server=WIN-CEARVOQ7M2N\\SQLEXPRESS;Database=pos;Integrated Security=True;";

    public int SaleID { get; private set; }
    public int UserID { get; private set; }
    public DateTime SaleDate { get; private set; }
    public decimal TotalAmount { get; private set; }

    public class SaleItem
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }

    public salesmaager(string username, DateTime saleDate, decimal totalAmount, List<SaleItem> items)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                // Fetch the UserID based on the provided username
                int userId = GetUserId(username, connection, transaction);

                if (userId > 0)
                {
                    // Insert the sale record and get the SaleID
                    int saleId = InsertSale2(userId, saleDate, totalAmount, connection, transaction);

                    if (saleId > 0)
                    {
                        // Insert sale items using the retrieved SaleID
                        InsertSaleItems2(saleId, items, connection, transaction);

                        // Commit the transaction if everything is successful
                        transaction.Commit();

                        MessageBox.Show("Sale added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add sale.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"User with username '{username}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Rollback transaction on error
                transaction?.Rollback();
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private int GetUserId(string username, SqlConnection connection, SqlTransaction transaction)
    {
        string getUserIdQuery = "SELECT UserID FROM Users WHERE Username = @Username";
        SqlCommand getUserIdCommand = new SqlCommand(getUserIdQuery, connection, transaction);
        getUserIdCommand.Parameters.AddWithValue("@Username", username);
        object userIdResult = getUserIdCommand.ExecuteScalar();
        return (userIdResult != null) ? Convert.ToInt32(userIdResult) : 0;
    }

   

   


  
    private int InsertSale2(int userId, DateTime saleDate, decimal totalAmount, SqlConnection connection, SqlTransaction transaction)
    {
        string insertQuery = "INSERT INTO todaySales (UserID, SaleDate, TotalAmount) VALUES (@UserID, @SaleDate, @TotalAmount); SELECT SCOPE_IDENTITY();";
        SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction);
        insertCommand.Parameters.AddWithValue("@UserID", userId);
        insertCommand.Parameters.AddWithValue("@SaleDate", saleDate);
        insertCommand.Parameters.AddWithValue("@TotalAmount", totalAmount);

        // Execute scalar to get the inserted SaleID
        return Convert.ToInt32(insertCommand.ExecuteScalar());
    }

    private void InsertSaleItems2(int saleId, List<SaleItem> items, SqlConnection connection, SqlTransaction transaction)
    {
        foreach (var item in items)
        {
            string insertItemQuery = "INSERT INTO todaySaleItems (SaleID, ProductID, Quantity, Subtotal) VALUES (@SaleID, @ProductID, @Quantity, @Subtotal)";
            SqlCommand insertItemCommand = new SqlCommand(insertItemQuery, connection, transaction);
            insertItemCommand.Parameters.AddWithValue("@SaleID", saleId);  // Use the correct SaleID here
            insertItemCommand.Parameters.AddWithValue("@ProductID", item.ProductID);
            insertItemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
            insertItemCommand.Parameters.AddWithValue("@Subtotal", item.Subtotal);
            insertItemCommand.ExecuteNonQuery();
        }
    }

   



}
