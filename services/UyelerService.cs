using System.Data;
using Microsoft.Data.SqlClient;
using Kutuphane.Utils;
using Kutuphane.Models;

namespace Kutuphane.Services;

    class UyelerService
    {
        readonly DB _dB;

        public UyelerService()
        {
            _dB = new DB();
        }

        public int AddUye(Uyeler uye)
        {
            int result = 0;
            try
            {
                // insert query
                string query = "INSERT INTO uyeler (uye_ad, uye_soyad, email, phone ) VALUES (@uye_ad, @uye_soyad, @email, @phone ); SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@uye_ad", uye.Uye_Ad);
                command.Parameters.AddWithValue("@uye_soyad", uye.Uye_Soyad);
                command.Parameters.AddWithValue("@email", uye.Email);
                command.Parameters.AddWithValue("@phone", uye.Phone);

                

                
                result = command.ExecuteNonQuery();

            }catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dB.CloseConnection();
            }
            return result;
        }

        public int DeletedUyeler(int uid) {
            int result = 0;
            try 
            {
                string query = "delete from uyeler where uid = @uid";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@uid", uid);
                result = command.ExecuteNonQuery();
            }catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dB.CloseConnection();
            }
            return result;
        }

        public int DeletedUye(int uid) 
        {
            int result = 0;
            try 
            {
                string query = "delete from Uyeler where uid = @uid";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@uid", uid);
                result = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dB.CloseConnection();
            }
            return result;
        }

        public List<Uyeler> GetAllUye() 
        {
            List<Uyeler> uyeler = new List<Uyeler>();
            try 
            {
                string query = "select * from Uyeler";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Uyeler uye = new Uyeler();
                    uye.UyeID = Convert.ToInt32(reader["uid"]);
                    uye.Uye_Ad = reader["uye_ad"].ToString();
                    uye.Uye_Soyad = reader["uye_soyad"].ToString();
                    uye.Email = reader["email"].ToString();
                    uye.Phone = reader["phone"].ToString();
                    uyeler.Add(uye);
                }
            }catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dB.CloseConnection();
            }
            return uyeler;
        }



        public int UpdateUye(Uyeler uyeler) {
            int result = 0;
            try 
            {
                string query = "update uyeler set uye_ad = @uye_ad, uye_soyad = @uye_soyad, email = @email, phone = @phone where uid = @uid";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@uid", uyeler.UyeID);         
                command.Parameters.AddWithValue("@uye_ad", uyeler.Uye_Ad);
                command.Parameters.AddWithValue("@uye_soyad", uyeler.Uye_Soyad); 
                command.Parameters.AddWithValue("@email", uyeler.Email);       
                command.Parameters.AddWithValue("@phone", uyeler.Phone);       
                result = command.ExecuteNonQuery();
            }catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dB.CloseConnection();
            }
            return result;
        }
    }