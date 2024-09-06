using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;


namespace ABCCars.Utils
{
    internal class CarPartsModule
    {
        QueryExecutor qe = new QueryExecutor();

        // ===================================== Create new car parts =============================================
        public bool CreateCarParts(string name, string image, string description, string condition, string price, string qty, string id)
        {
            try
            {
                qe.ExecuteNonQuery("INSERT INTO CarParts (partPrice, partName, partDescription, partCondition, partImage, qty, createdAt, carID) VALUES (@price, @name, @description ,@condition, @image, @qty, @createdAt, @carID)",
                    new SqlParameter("@price", price),
                    new SqlParameter("@name", name),
                    new SqlParameter("@description", description),
                    new SqlParameter("@condition", condition),
                    new SqlParameter("@image", image),
                    new SqlParameter("@createdAt", DateTime.Now),
                    new SqlParameter("@qty", qty),
                    new SqlParameter("@carID", id));
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

        // ===================================== Update car parts =================================================
        public bool UpdateCarParts(string id, string name, string image, string description, string condition, string price, string qty, string carID)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE CarParts SET partPrice = @price, partName = @name, partDescription = @description, partCondition = @condition, partImage = @image, qty=@qty, updatedAt = @updatedAt, carID= @carID WHERE id = @id",
                new SqlParameter("@id", id),
                new SqlParameter("@name", name),
                new SqlParameter("@image", image),
                new SqlParameter("@description", description),
                new SqlParameter("@condition", condition),
                new SqlParameter("@price", price),
                new SqlParameter("@qty", qty),
                new SqlParameter("@updatedAt", DateTime.Now),
                new SqlParameter("@carID", carID)
                );

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ========================================================================================================

        // ===================================== Delete car parts =================================================
        public bool DeleteCarParts(string id)
        {
            try
            {
               return qe.ExecuteNonQuery("UPDATE CarParts SET deletedAt = @date WHERE id = @id",
                    new SqlParameter("@date", DateTime.Now),
                    new SqlParameter("@id", id));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ========================================================================================================

        // ===================================== Get car parts by ID ==============================================
        public List<CarPartsList> GetCarPartsById(string id)
        {
            List<CarPartsList> carParts = new List<CarPartsList>();
            try
            {
                var reader = qe.ListAll("SELECT * FROM CarParts WHERE id = @id", new SqlParameter[] { new SqlParameter("@id", id) });
                List<CarPartsList> carPartsLists = new List<CarPartsList>();

                foreach (var item in reader)
                {
                    carParts.Add(new CarPartsList
                    {
                        id = item["carID"].ToString(),
                        Name = item["partName"].ToString(),
                        Image = item["partImage"].ToString(),
                        Description = item["partDescription"].ToString(),
                        Condition = item["partCondition"].ToString(),
                        Price = item["partPrice"].ToString(),
                        qty = item["qty"].ToString(),
                        CreatedAt = item["createdAt"].ToString(),
                        UpdatedAt = item["updatedAt"].ToString()
                    });
                }

                return carParts;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // ========================================================================================================

        // ======================================== Get all car parts =============================================
        public List<CarPartsList> GetAllCarParts()
        {
            List<CarPartsList> carParts = new List<CarPartsList>();
            try
            {
                var reader = qe.ListAll("SELECT * FROM CarParts WHERE deletedAt IS NULL");
                List<CarPartsList> carPartsLists = new List<CarPartsList>();

                foreach (var item in reader)
                {
                    carParts.Add(new CarPartsList
                    {
                        id = Convert.ToString(item["id"]),
                        Name = item["partName"].ToString(),
                        Image = item["partImage"].ToString(),
                        Description = item["partDescription"].ToString(),
                        Condition = item["partCondition"].ToString(),
                        Price = item["partPrice"].ToString(),
                        qty = item["qty"].ToString(),
                        CreatedAt = item["createdAt"].ToString(),
                        UpdatedAt = item["updatedAt"].ToString()
                    });
                }

                return carParts;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // ========================================================================================================

        // ======================================== Get last part ID =============================================
        public string GetLastPartID()
        {
            try
            {
                var reader = qe.ListAll("SELECT TOP 1 * FROM CarParts ORDER BY id DESC", null);
                string id = "";
                foreach (var item in reader)
                {
                    id = item["carID"].ToString();
                }
                return id;
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
