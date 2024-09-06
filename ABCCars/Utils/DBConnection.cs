using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ABCCars.Utils;

// This class is used to connect to the database and execute queries
namespace ABCCars
{
    internal class DBConnection
    {
        // ================== Create an instance of the QueryExecutor class ==================
        QueryExecutor qe = new QueryExecutor();
        // ===================================================================================

        // ========================= Check if the user is an customer ========================
        public bool UserLogin(string username, string password)
        {
            try
            {
                qe.ExecuteReader(
                "SELECT * FROM customers WHERE cusEmail = @username AND hashedpassword = @password AND status = 1",
                new SqlParameter("@username", username),
                new SqlParameter("@password", password));

                var hashedpassword = qe.ExecuteReaderQueries(
                    "SELECT hashedpassword FROM customers WHERE cusEmail = @username",
                    new SqlParameter("@username", username)).ToString();

                return BCrypt.Net.BCrypt.Verify(password, hashedpassword);

            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ===================================================================================

        // ========================= Check if the user is an admin ===========================
        public bool AdminLogin(string username, string password)
        {
            try
            {
                qe.ExecuteNonQuery(
                "SELECT * FROM admin WHERE username = @username AND password = @password",
                new SqlParameter("@username", username),
                new SqlParameter("@password", password));

                var hashedpassword = qe.ExecuteReaderQueries(
                    "SELECT password FROM admin WHERE username = @username",
                    new SqlParameter("@username", username)).ToString();

                return BCrypt.Net.BCrypt.Verify(password, hashedpassword);

            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ===================================================================================

        // ============================ Register a new Customer ==============================
        public bool RegisterCustomer(string fullName, string address, string mobile, string email, string password, int emailVerified)
        {
            try
            {
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);

                return qe.ExecuteNonQuery(
                    "INSERT INTO customers (cusName, cusAddress, cusMobile, cusEmail, hashedpassword, isEmailVerified, status) VALUES (@fullName, @address, @mobile, @email, @password, @isEmailVerified, 1)",
                    new SqlParameter("@fullName", fullName),
                    new SqlParameter("@address", address),
                    new SqlParameter("@mobile", mobile),
                    new SqlParameter("@email", email),
                    new SqlParameter("@password", hashPassword),
                    new SqlParameter("@isEmailVerified", emailVerified));
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ===================================================================================

        // ================================= Update Email Verification =======================
        public bool UpdateEmailVerification(string email)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE customers SET isEmailVerified = 1 WHERE cusEmail = @email",
                new SqlParameter("@email", email));
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ===================================================================================

        // ========================= Get the customer details ================================
        public List<CustomersList> customersLists()
        {
            try
            {
                var reader = qe.ListAll("SELECT * FROM customers WHERE deletedAt IS NULL");
                List<CustomersList> customersList = new List<CustomersList>();

                foreach (var item in reader)
                {
                    customersList.Add(new CustomersList
                    {
                        Id = Convert.ToInt32(item["id"]),
                        image = Properties.Resources.Black_and_Red_Modern_Automotive_Car_Logo,
                        Name = item["cusName"].ToString(),
                        Address = item["cusAddress"].ToString(),
                        Email = item["cusEmail"].ToString(),
                        Phone = item["cusMobile"].ToString()
                    });
                }

                return customersList;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // ===================================================================================

        // ============================ Delete a Customer ====================================
        public bool DeleteCustomer(int id)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE customers SET deletedAt = @date WHERE id = @id ",
                new SqlParameter("@date", DateTime.Now),
                new SqlParameter("@id", id));
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ===================================================================================

        // ==================================== Get customer by ID ==========================
        public List<CustomersList> GetCustomerById(int id)
        {
            try
            {
                var reader = qe.ListAll("SELECT * FROM customers WHERE id = @id", new SqlParameter[] { new SqlParameter("@id", id) });
                List<CustomersList> customersList = new List<CustomersList>();

                foreach (var item in reader)
                {
                    customersList.Add(new CustomersList
                    {
                        Id = Convert.ToInt32(item["id"]),
                        image = Properties.Resources.Black_and_Red_Modern_Automotive_Car_Logo,
                        Name = item["cusName"].ToString(),
                        Address = item["cusAddress"].ToString(),
                        Email = item["cusEmail"].ToString(),
                        Phone = item["cusMobile"].ToString()
                    });
                }

                return customersList;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // ===================================================================================

        // ================================== Get customer by Email =============================
        public List<CustomersList> GetCustomerByEmail(string email)
        {
            try
            {
                var reader = qe.ListAll("SELECT * FROM customers WHERE cusEmail = @email", new SqlParameter[] { new SqlParameter("@email", email) });
                List<CustomersList> customersList = new List<CustomersList>();

                foreach (var item in reader)
                {
                    customersList.Add(new CustomersList
                    {
                        Id = Convert.ToInt32(item["id"]),
                        image = Properties.Resources.Black_and_Red_Modern_Automotive_Car_Logo,
                        Name = item["cusName"].ToString(),
                        Address = item["cusAddress"].ToString(),
                        Email = item["cusEmail"].ToString(),
                        Phone = item["cusMobile"].ToString()
                    });
                }

                return customersList;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }
       
        // ===================================================================================

        // =================================== Block a Customer ==============================
        public bool BlockCustomer(int id)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE customers SET status = 0 WHERE id = @id",
                new SqlParameter("@id", id));
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // ================================= Unblock a Customer ==============================
        public bool UnblockCustomer(int id)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE customers SET status = 1 WHERE id = @id",
                new SqlParameter("@id", id));
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // ================================= Get All Emails ==================================
        public List<string> GetAllEmails()
        {
            try
            {
                var reader = qe.GetList("SELECT cusEmail FROM customers");
                return reader;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // ===================================================================================

        // ============================ Change Admin Password ================================
        public bool ChangeAdminPassword(string username, string password)
        {
            try
            {
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);

                return qe.ExecuteNonQuery(
                "UPDATE admin SET password = @password, updatedAt = @update WHERE username = @username",
                new SqlParameter("@password", hashPassword),
                new SqlParameter("@update", DateTime.Now),
                new SqlParameter("@username", username));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ===================================================================================

        // ============================= Change Customer password =============================
        public bool ChangeCustomerPassword(string email, string password)
        {
            try
            {
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);

                return qe.ExecuteNonQuery(
                "UPDATE customers SET hashedpassword = @password, updatedAt = @update WHERE cusEmail = @email",
                new SqlParameter("@password", hashPassword),
                new SqlParameter("@update", DateTime.Now),
                new SqlParameter("@email", email));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ===================================================================================

        // ========================== Update Customer by Email ===============================
        public bool UpdateCustomerByEmail(string email, string name, string address, string mobile)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE customers SET cusName = @name, cusAddress = @address, cusMobile = @mobile, updatedAt = @update WHERE cusEmail = @email",
                new SqlParameter("@name", name),
                new SqlParameter("@address", address),
                new SqlParameter("@mobile", mobile),
                new SqlParameter("@update", DateTime.Now),
                new SqlParameter("@email", email));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }


        // =========================== ChangeAdminUsername ================================
        public bool ChangeAdminUsername(string oldUsername, string newUsername)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE admin SET username = @newUsername, updatedAt = @update WHERE username = @oldUsername",
                new SqlParameter("@newUsername", newUsername),
                new SqlParameter("@update", DateTime.Now),
                new SqlParameter("@oldUsername", oldUsername));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
        // ===================================================================================

        // ========================================= ChangeAdminEmail ==========================
        public bool ChangeAdminEmail(string existingEmail, string newEmail)
        {
            try
            {
                return qe.ExecuteNonQuery(
                "UPDATE admin SET email = @newEmail, updatedAt = @update WHERE email = @existingEmail",
                new SqlParameter("@newEmail", newEmail),
                new SqlParameter("@update", DateTime.Now),
                new SqlParameter("@existingEmail", existingEmail));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    // ===================================================================================
}
