using System.Data;
using Microsoft.Data.SqlClient;
using Kutuphane.Utils;
using Kutuphane.Models;

namespace Kutuphane.Services;


        class KitapService
        {
            readonly DB _dB;

        public KitapService()
        {
            _dB = new DB();
        }
            public List<Kitaplar> GetAllKitap() 
        {
            List<Kitaplar> kitaplar = new List<Kitaplar>();
            try 
            {
                // Changed query to match column access - removed AS yazar_id since we're using yid directly
                string query = "SELECT kid, baslik, yayin_yili, isbn, yid FROM Kitap";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Kitaplar kitap = new Kitaplar();
                    kitap.Kitap_ID = Convert.ToInt32(reader["kid"]);
                    kitap.Baslik = reader["baslik"].ToString();
                    kitap.Yayin_Yili = Convert.ToDateTime(reader["yayin_yili"]);
                    kitap.ISBN = reader["isbn"].ToString();
                    kitap.YazarID = Convert.ToInt32(reader["yid"]); // Accessing yid directly
                    kitaplar.Add(kitap);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dB.CloseConnection();
            }
            return kitaplar;
        }



        public int AddKitap(Kitaplar kitap)
        {
            int result = 0;
            try
            {
                // insert query
                string query = "INSERT INTO Kitap (baslik, isbn, yayin_yili) VALUES (@baslik, @isbn, @yayin_yili); SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@baslik", kitap.Baslik);
                command.Parameters.AddWithValue("@isbn", kitap.ISBN);
                command.Parameters.AddWithValue("@yayin_yili", kitap.Yayin_Yili);
                

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
        public int DeletedKitap(int kid) {
            int result = 0;
            try 
            {
                string query = "delete from kitap where kid = @kid";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@kid", kid);
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

