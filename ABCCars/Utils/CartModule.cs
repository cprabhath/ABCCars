using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Documents;

namespace ABCCars.Utils
{
    internal class CartModule
    {
        QueryExecutor qe = new QueryExecutor();

        // ============================ Update Part ID by Customer ID ============================
        public bool UpdatePartID(int customerID, int partID)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE cart SET partId = @partID WHERE customerId = @id",
                new SqlParameter("@partID", partID),
                new SqlParameter("@id", customerID),
                new SqlParameter("@updatedAt", DateTime.Now));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // ========================== Update Vehicle ID by Customer ID ==========================
        public bool UpdateVehicleID(int customerID, int vehicleID)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE cart SET vehicleId = @vehicleID WHERE customerId = @id",
                new SqlParameter("@vehicleID", vehicleID),
                new SqlParameter("@id", customerID),
                new SqlParameter("@updatedAt", DateTime.Now));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // ========================== Create a new Cart for a Customer ==========================
        public bool CreateCart(int customerID)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "INSERT INTO cart (customerId, createdAt) VALUES (@customerID, @createdAt)",
                new SqlParameter("@customerID", customerID),
                new SqlParameter("@createdAt", DateTime.Now));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // ================================= Get Count of Items in Cart =================================
        public int GetCartCount(int customerID)
        {
            try
            {
                return qe.ExecuteScalar<int>(
                "SELECT COUNT(*) FROM cart WHERE customerId = @id",
                new SqlParameter("@id", customerID));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        // ============================================ Get All by Customer ID ============================================
        public List<CartList> GetAllByCustomerID(int customerID)
        {
            try
            {
                var reader = qe.ListAll("SELECT * FROM cart WHERE customerId = @id", new SqlParameter[] { new SqlParameter("@id", customerID) });

                List<CartList> carList = new List<CartList>();

                foreach (var item in reader)
                {
                    carList.Add(new CartList
                    {
                        id = item["id"].ToString(),
                        customerID = item["customerId"].ToString(),
                        vehicleID = item["vehicleId"].ToString(),
                        partID = item["partId"].ToString(),
                        createAt = item["createdAt"].ToString(),
                    });
                }

                return carList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return new List<CartList>();
            }
        }

        // ================================================== Delete by customer ID ==================================================
        public bool DeleteByCustomerID(int customerID)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "INSERT INTO cart (customerId, deletedAt) VALUES (@customerID, @deletedAt)",
                new SqlParameter("@id", customerID),
                new SqlParameter("@deletedAt", DateTime.Now)
                );
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
