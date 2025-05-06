using System.Data;
using Microsoft.Data.SqlClient;
using Kutuphane.Utils;
using Kutuphane.Models;


namespace Kutuphane.Services;

    class YazarService
    {
        readonly DB _dB;

        public YazarService()
        {
            _dB = new DB();
        }

        // Olan Yazarları Getir
        public List<Yazarlar> GetAllYazar() 
        {
            List<Yazarlar> yazarlar = new List<Yazarlar>();
            try 
            {
                string query = "select * from Yazarlar";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Yazarlar yazar = new Yazarlar();
                    yazar.YazarID = Convert.ToInt32(reader["yid"]);
                    yazar.Ad = reader["yazar_ad"].ToString();
                    yazar.Soyad = reader["yazar_soyad"].ToString();
                    yazarlar.Add(yazar);
                }
            }catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dB.CloseConnection();
            }
            return yazarlar;
        }

        // Yazar Ekle

        public int AddYazar(Yazarlar yazar)
        {
            int result = 0;
            try
            {
                // insert query
                string query = "INSERT INTO Yazarlar (yazar_ad, yazar_soyad ) VALUES (@yazar_ad, @yazar_soyad ); SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@yazar_ad", yazar.Ad);
                command.Parameters.AddWithValue("@yazar_soyad", yazar.Soyad);
                

                //result = Convert.ToInt32(command.ExecuteScalar()); // SCOPE_IDENTITY() ile eklenen kaydın ID'sini alır
                result = command.ExecuteNonQuery(); // etkilenen satır sayısını döndürür

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

        // Yazar Sil
        public int DeletedYazar(int yid) {
            int result = 0;
            try 
            {
                string query = "delete from Yazarlar where yid = @yid";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@yid", yid);
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
