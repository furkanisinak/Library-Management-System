using System.Data;
using Microsoft.Data.SqlClient;
using Kutuphane.Utils;
using Kutuphane.Models;

namespace Kutuphane.Services;

    class OduncService
    {
        readonly DB _dB;

        public OduncService()
        {
            _dB = new DB();
        }

        public int AddOdunc(Oduncler odunc)
        {
            int result = 0;
            try
            {
                // insert query
                string query = "INSERT INTO odunckitaplar (uid, kid, odunc_tarih, iade_tarih) VALUES (@uid, @kid, @odunc_tarih, @iade_tarih); SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@uid", odunc.UyeID);
                command.Parameters.AddWithValue("@kid", odunc.Kitap_ID);
                command.Parameters.AddWithValue("@odunc_tarih", odunc.OduncTarihi);
                command.Parameters.AddWithValue("@iade_tarih", odunc.IadeTarihi);

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

        public int DeletedOdunc(int oid) {
            int result = 0;
            try 
            {
                string query = "delete from odunckitaplar where oid = @oid";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@oid", oid);
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