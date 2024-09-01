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
        public bool CreateCarParts(string name, string image, string description, string condition, string price, string qty)
        {
            try
            {
                qe.ExecuteNonQuery("INSERT INTO car_parts (price, name, description, condition, image, qty, createdAt) VALUES (@price, @name, @description ,@condition, @image, @price, @qty)",
                    new SqlParameter("@name", name),
                    new SqlParameter("@image", image),
                    new SqlParameter("@description", description),
                    new SqlParameter("@condition", condition),
                    new SqlParameter("@price", price),
                    new SqlParameter("@qty", qty),
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

        // ===================================== Update car parts =================================================
        public bool UpdateCarParts(string id, string name, string image, string description, string condition, string price, string qty)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE car_parts SET name = @name, image = @image, description = @description, condition = @condition, price = @price, updatedAt = @updatedAt, qty=@qty WHERE id = @id",
                new SqlParameter("@id", id),
                new SqlParameter("@name", name),
                new SqlParameter("@description", description),
                new SqlParameter("@condition", condition),
                new SqlParameter("@price", price),
                new SqlParameter("@image", image),
                new SqlParameter("@qty", qty),
                new SqlParameter("@updatedAt", DateTime.Now));

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
               return qe.ExecuteNonQuery("UPDATE car_parts SET deletedAt = @date WHERE id = @id",
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
                var reader = qe.ListAll("SELECT * FROM car_parts WHERE id = @id", new SqlParameter[] { new SqlParameter("@id", id) });
                List<CarPartsList> carPartsLists = new List<CarPartsList>();

                foreach (var item in reader)
                {
                    carParts.Add(new CarPartsList
                    {
                        id = Convert.ToString(item["id"]),
                        Name = item["name"].ToString(),
                        Image = Properties.Resources.bx_car,
                        Description = item["description"].ToString(),
                        Condition = item["condition"].ToString(),
                        Price = item["price"].ToString(),
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
                var reader = qe.ListAll("SELECT * FROM car_parts", null);
                List<CarPartsList> carPartsLists = new List<CarPartsList>();

                foreach (var item in reader)
                {
                    carParts.Add(new CarPartsList
                    {
                        id = Convert.ToString(item["id"]),
                        Name = item["name"].ToString(),
                        Image = Properties.Resources.bx_car,
                        Description = item["description"].ToString(),
                        Condition = item["condition"].ToString(),
                        Price = item["price"].ToString(),
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
    }
}
