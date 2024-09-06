using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ABCCars.Utils
{
    internal class OrderModule
    {
        QueryExecutor qe = new QueryExecutor();

        // ===================================== Create new order =============================================
        public bool CreateOrder(string orderID, string customerID, string partID, string vehicleID, string total, string status)
        {
            try
            {
                qe.ExecuteNonQuery("INSERT INTO orders (orderID, customerID, partID, vehicleID, total, status, createdAt) VALUES (@orderID, @customerID ,@partID, @vehicleID, @total, @status, @createdAt)",
                    new SqlParameter("@orderID", orderID),
                    new SqlParameter("@customerID", customerID),
                    new SqlParameter("@partID", partID),
                    new SqlParameter("@vehicleID", vehicleID),
                    new SqlParameter("@total", total),
                    new SqlParameter("@status", status),
                    new SqlParameter("@createdAt", DateTime.Now));
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ========================================================================================================

        // ===================================== Update order =================================================
        public bool UpdateOrder(string orderID, string status)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE orders SET status = @status WHERE orderID = @orderID",
                new SqlParameter("@orderID", orderID),
                new SqlParameter("@status", status));

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ========================================================================================================

        // ===================================== Delete order =====================================================
        public bool DeleteOrder(string orderID)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE orders SET cancelledAt = @date WHERE id = @id",
                new SqlParameter("@date", DateTime.Now),
                new SqlParameter("@orderID", orderID));

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ========================================================================================================

        // ===================================== Get order by ID ==================================================
        public List<OrderList> GetOrderById(string orderID)
        {
            try
            {
                List<OrderList> orderList = new List<OrderList>();
                var reader = qe.ListAll("SELECT * FROM orders WHERE orderID = @orderID", new SqlParameter[] { new SqlParameter("@orderID", orderID) });
                
                foreach (var item in reader)
                {
                    orderList.Add(new OrderList
                    {
                        OrderID = Convert.ToString(item["orderID"]),
                        CustomerID  = item["customerID"].ToString(),
                        PartID = item["partID"].ToString(),
                        VehicleID = item["vehicleID"].ToString(),
                        Total = item["total"].ToString(),
                        Status = item["status"].ToString(),
                        CreatedAt = item["createdAt"].ToString(),
                    });
                }

                return orderList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;

            }
        }
        // ========================================================================================================

        // ===================================== Get all orders ===================================================
        public List<OrderList> GetAllOrders()
        {
            try
            {
                List<OrderList> orderList = new List<OrderList>();
                var reader = qe.ListAll("SELECT * FROM orders");

                foreach (var item in reader)
                {
                    orderList.Add(new OrderList
                    {
                        OrderID = Convert.ToString(item["orderID"]),
                        CustomerID = item["customerID"].ToString(),
                        PartID = item["partID"].ToString(),
                        VehicleID = item["vehicleID"].ToString(),
                        Total = item["total"].ToString(),
                        Status = item["status"].ToString(),
                        CreatedAt = item["createdAt"].ToString(),
                    });
                }

                return orderList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // ========================================================================================================

        // ========================================== Get order by customer ID ====================================
        public List<OrderList> GetOrderByCustomerID(string customerID)
        {
            try
            {
                List<OrderList> orderList = new List<OrderList>();
                var reader = qe.ListAll("SELECT * FROM orders WHERE customerID = @customerID", new SqlParameter[] { new SqlParameter("@customerID", customerID) });

                foreach (var item in reader)
                {
                    orderList.Add(new OrderList
                    {
                        OrderID = Convert.ToString(item["orderID"]),
                        CustomerID = item["customerID"].ToString(),
                        PartID = item["partID"].ToString(),
                        VehicleID = item["vehicleID"].ToString(),
                        Total = item["total"].ToString(),
                        Status = item["status"].ToString(),
                        CreatedAt = item["createdAt"].ToString(),
                        UpdatedAt = item["updatedAt"].ToString()
                    });
                }

                return orderList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // ========================================================================================================

        // ================================== Get order status ====================================================
        public List<OrderList> GetOrderByStatus(string status)
        {
            try
            {
                List<OrderList> orderList = new List<OrderList>();
                var reader = qe.ListAll("SELECT * FROM orders WHERE status = @status", new SqlParameter[] { new SqlParameter("@status", status) });

                foreach (var item in reader)
                {
                    orderList.Add(new OrderList
                    {
                        OrderID = Convert.ToString(item["orderID"]),
                        CustomerID = item["customerID"].ToString(),
                        PartID = item["partID"].ToString(),
                        VehicleID = item["vehicleID"].ToString(),
                        Total = item["total"].ToString(),
                        Status = item["status"].ToString(),
                        CreatedAt = item["createdAt"].ToString(),
                    });
                }

                return orderList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // ========================================================================================================


        // ==================================== get Total sale ====================================================
        public string GetTotalSale()
        {
            try
            {
                var reader = qe.ListAll("SELECT SUM(total) as total FROM orders", null);
                return reader[0]["total"].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // ========================================================================================================

        // ================================== Get order count =====================================================
        public string GetOrderCount()
        {
            try
            {
                var reader = qe.ListAll("SELECT COUNT(*) as total FROM orders", null);
                return reader[0]["total"].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
