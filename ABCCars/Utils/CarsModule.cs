using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace ABCCars.Utils
{
    internal class CarsModule
    {
        QueryExecutor qe = new QueryExecutor();

        // ================================= Get All Cars ======================================
        public List<CarList> GetCars()
        {
            try
            {
                var reader = qe.ListAll("SELECT * FROM cars WHERE deletedAt IS NULL");
                List<CarList> carList = new List<CarList>();

                foreach (var item in reader)
                {
                    carList.Add(new CarList
                    {
                        carID = Convert.ToString(item["id"]),
                        Name = item["carName"].ToString(),
                        Model = item["carModel"].ToString(),
                        Description = item["carDescription"].ToString(),
                        Condition = item["carCondition"].ToString(),
                        Price = item["carPrice"].ToString(),
                        qty = item["carQty"].ToString(),
                        Image = item["carImage"].ToString(),
                        CreatedAt = item["createdAt"].ToString(),
                        UpdatedAt = item["updatedAt"].ToString()
                    });
                }

                return carList;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // ===================================================================================

        // ================================= Get Car by ID ====================================
        public List<CarList> GetCarById(string id)
        {
            try
            {
                var reader = qe.ListAll("SELECT * FROM cars WHERE id = @id", new SqlParameter[] { new SqlParameter("@id", id) });

                List<CarList> carList = new List<CarList>();

                foreach (var item in reader)
                {
                    carList.Add(new CarList
                    {
                        carID = item["carId"].ToString(),
                        Name = item["carName"].ToString(),
                        Model = item["carModel"].ToString(),
                        Description = item["carDescription"].ToString(),
                        Condition = item["carCondition"].ToString(),
                        Price = item["carPrice"].ToString(),
                        qty = item["carQty"].ToString(),
                        Image = item["carImage"].ToString(),
                        CreatedAt = item["createdAt"].ToString(),
                        UpdatedAt = item["updatedAt"].ToString()
                    });
                }

                return carList;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // ===================================================================================

        // =================================== Delete a Car ===================================
        public bool DeleteCar(string id)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE cars SET deletedAt = @date WHERE id = @id ",
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
        // ===================================================================================

        // ================================ Add a new Car =====================================
        public bool AddCar(string id, string name, string model, string qty, string image, string description, string condition, string price)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "INSERT INTO cars (carId, carName, carModel, carImage, carDescription, carCondition, carPrice, createdAt, carQty) VALUES (@id, @name, @model, @image, @description, @condition, @price, @createdAt, @qty)",
                new SqlParameter("@id", id),
                new SqlParameter("@name", name),
                new SqlParameter("@model", model),
                new SqlParameter("@description", description),
                new SqlParameter("@condition", condition),
                new SqlParameter("@price", price),
                new SqlParameter("@image", image),
                new SqlParameter("@qty", qty),
                new SqlParameter("@createdAt", DateTime.Now));

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ===================================================================================

        // ================================ Update a Car ======================================
        public bool UpdateCar(string id, string name, string model, string image, string description, string condition, string price, string qty)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE cars SET carName = @name, carModel = @model, carImage = @image, carDescription = @description, carCondition = @condition, carPrice = @price, updatedAt = @updatedAt, carQty=@qty WHERE id = @id",
                new SqlParameter("@id", id),
                new SqlParameter("@name", name),
                new SqlParameter("@model", model),
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
        //  ===================================================================================

        // ============================= add to Cart =================================
        public bool AddToCart(string id, string name, string model, string qty, string image, string description, string condition, string price)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "INSERT INTO cart (carId, carName, carModel, carImage, carDescription, carCondition, carPrice, createdAt, carQty) VALUES (@id, @name, @model, @image, @description, @condition, @price, @createdAt, @qty)",
                new SqlParameter("@id", id),
                new SqlParameter("@name", name),
                new SqlParameter("@model", model),
                new SqlParameter("@description", description),
                new SqlParameter("@condition", condition),
                new SqlParameter("@price", price),
                new SqlParameter("@image", image),
                new SqlParameter("@qty", qty),
                new SqlParameter("@createdAt", DateTime.Now));

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // ====================================== Get Last ID ======================================
        public string GetLastID()
        {
            try
            {
                var reader = qe.ListAll("SELECT TOP 1 * FROM cars ORDER BY id DESC");

                foreach (var item in reader)
                {
                    return item["carId"].ToString();
                }

                return null;
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
