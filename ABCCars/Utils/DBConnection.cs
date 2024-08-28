﻿using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

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
                "SELECT * FROM customers WHERE cusEmail = @username AND hashedpassword = @password",
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
                    "INSERT INTO customers (cusName, cusAddress, cusMobile, cusEmail, hashedpassword, isEmailVerified) VALUES (@fullName, @address, @mobile, @email, @password, @isEmailVerified)",
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
        public DataTable GetCustomerDetails()
        {
            return qe.TableExecutor("SELECT * FROM customers");
        }
        // ===================================================================================


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
    }
}
