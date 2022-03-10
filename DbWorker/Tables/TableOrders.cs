using DbWorker.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbEntities;
using MySql.Data.MySqlClient;

namespace DbWorker.Tables
{
  public  class TableOrders
    {
        public List<Order> GetOrders()
        {
            try
            {
                List<Order> orders = new List<Order>();

                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = $"SELECT * From orders Where status={true}";

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read() == true)
                            {
                                orders.Add(new Order
                                {
                                    Id = mySqlDataReader.GetInt32("id"),
                                    IdCourier = mySqlDataReader.GetInt32("id_couriers"),
                                    Lat = mySqlDataReader.GetFloat("lat"),
                                    Long = mySqlDataReader.GetFloat("long"),
                                    Coast = mySqlDataReader.GetInt32("coast"),
                                    Status = mySqlDataReader.GetBoolean("status"),
                                    User = null
                                });
                            }
                        }
                    }
                }

                return orders;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool UpdateStatus(int idOrder, int idCourier)
        {
            try
            {
                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = $"UPDATE `orders` SET `status` = {false} ,orders.id_couriers={idCourier}" +
                            $" WHERE `id` = {idOrder};";
                        mySqlCommand.ExecuteNonQuery();

                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public List<Order> GetOrderInfo(int idCourier)
        {
            try
            {
                List<Order> orders = new List<Order>();

                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = $"SELECT * From orders Where id_couriers={idCourier}";

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read() == true)
                            {
                                orders.Add(new Order
                                {
                                    Id = mySqlDataReader.GetInt32("id"),
                                    IdCourier = mySqlDataReader.GetInt32("id_couriers"),
                                    Lat = mySqlDataReader.GetFloat("lat"),
                                    Long = mySqlDataReader.GetFloat("long"),
                                    Coast = mySqlDataReader.GetInt32("coast"),
                                    Status = mySqlDataReader.GetBoolean("status"),
                                    User = null
                                });
                            }
                        }
                    }
                }

                return orders;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool InsertOrder(float lat, float long1, int coast)
        {
            try
            {
                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = $"INSERT orders(lat,`long`,coast,status,id_couriers) VALUES({lat},{long1}, {coast},{true},{0})";
                        mySqlCommand.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
