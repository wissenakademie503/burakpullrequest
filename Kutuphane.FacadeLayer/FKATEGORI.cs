using Kutuphane.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.FacadeLayer
{
    public class FKATEGORI
    {
        public static int Insert(EKATEGORI item)
        {
            int etkilenen = 0;
            try
            {
                SqlCommand com = new SqlCommand("KATEGORI_Insert", Baglanti.Con);

                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }

                com.Parameters.AddWithValue("ADI", item.ADI);
                etkilenen= com.ExecuteNonQuery();

            }
            catch (Exception)
            {

                etkilenen = -1;
            }

            return etkilenen;
        }

        public static bool Update(EKATEGORI item)
        {
            bool sonuc = false;
            try
            {
                SqlCommand com = new SqlCommand("KATEGORI_Update", Baglanti.Con);

                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("ID", item.ID);
                com.Parameters.AddWithValue("ADI", item.ADI);
                sonuc = com.ExecuteNonQuery()>0;

            }
            catch (Exception)
            {

              sonuc = false;
            }

            return sonuc;
        }
        public static bool Delete(int _ID)
        {
            bool sonuc = false;
            try
            {
                SqlCommand com = new SqlCommand("KATEGORI_Delete", Baglanti.Con);

                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }

                com.Parameters.AddWithValue("ID", _ID);
              
                sonuc = com.ExecuteNonQuery() > 0;

            }
            catch (Exception)
            {

                sonuc = false;
            }

            return sonuc;
        }

        public static EKATEGORI Select (int _ID)
        {
            EKATEGORI item = null;
            try
            {
                SqlCommand com = new SqlCommand("KATEGORI_Select", Baglanti.Con);

                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }

                com.Parameters.AddWithValue("ID", _ID);
                SqlDataReader rdr = com.ExecuteReader();
                if(rdr.HasRows)
                {
                  while(rdr.Read())
                    {
                      
                        item.ID = int.Parse(rdr["ID"].ToString());
                        item.ADI=rdr["ADI"].ToString();
                    }

                }
            }
            catch (Exception)
            {

                item = null;
            }

            return item;
        }

        public static List<EKATEGORI> SelectList()
        {
           List <EKATEGORI> itemList = null;
            SqlCommand com = new SqlCommand("KATEGORI_SelectList", Baglanti.Con);
            try
            {
             

                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }

                
                SqlDataReader rdr = com.ExecuteReader();
                if (rdr.HasRows)
                {
                    itemList = new List<EKATEGORI>();
                    while (rdr.Read())
                    {
                        EKATEGORI item = new EKATEGORI();
                        item.ID = int.Parse(rdr["ID"].ToString());
                        item.ADI = rdr["ADI"].ToString();
                        itemList.Add(item);
                    }

                }
            }
            catch (Exception)
            {

                itemList = null;
            }
            finally
            {
                com.Connection.Close();
            }

            return itemList;
        }
    }
}
