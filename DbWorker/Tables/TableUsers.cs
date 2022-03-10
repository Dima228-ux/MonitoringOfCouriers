using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbEntities;
using DbWorker.Tools;
using ExceptionEntities2;
using MySql.Data.MySqlClient;


namespace DbWorker.Tables
{
    public class TableUsers
    {
        public User GetUserByLoginPassword(string login, string password)
        {
            try
            {
                User user = null;

                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = $"SELECT * FROM `users` WHERE `login`='{login}' AND `password`='{password}';";

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            if (mySqlDataReader.HasRows == true)
                            {
                                mySqlDataReader.Read();

                                user = new User
                                {
                                    Id = mySqlDataReader.GetInt32("id"),
                                    Login = mySqlDataReader.GetString("login"),
                                    Password = mySqlDataReader.GetString("password"),
                                    Type = mySqlDataReader.GetString("type"),
                                    Name = mySqlDataReader.GetString("name"),
                                    Surname = mySqlDataReader.GetString("surname"),
                                    Status = mySqlDataReader.GetBoolean("status")

                                };
                            }
                            else
                            {
                                throw new WrongLoginPasswordException();
                            }
                        }
                    }
                }

                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CheckLoginUser(string login)
        {

            using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                {
                    mySqlCommand.CommandText = $"SELECT * FROM `users` WHERE `login`='{login}';";

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.HasRows == true)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
        }

        public float[] GetCoordinatCourier(int idCourier)
        {
            
            using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                {
                    mySqlCommand.CommandText = $"SELECT lat, long FROM `users` WHERE `id`={idCourier};";

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        while (mySqlDataReader.Read() == true)
                        {
                            return new float[] {
                                 mySqlDataReader.GetFloat("lat"),
                                 mySqlDataReader.GetFloat("long")
                            
                        };
                    }
                    }
                }
            }
            return null;
        }

        public void RegistedNewUser(string login, string password, string type, string name, string surname)
        {
            try
            {
                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = $"INSERT users(login,password,type,name,surname,status) VALUES('{login}','{password}','{type}','{name}','{surname}',{true})";
                        mySqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateStatusCourier(int idCourier)
        {
            try
            {
                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = $"UPDATE `users` SET `status` = {false} " +
                            $"WHERE `id` = {idCourier};";
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



        public bool UpdateCoordinateCourier(int idCourier,float lat,float lon)
        {
            try
            {
                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = $"UPDATE `users` SET lat={lat},long={lon} " +
                            $"WHERE `id` = {idCourier};";
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

        public bool UpdateInfoAboutCourier(int idCourier,string login,string password,string name,string surname,string type)
        {
            try
            {
                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        if (type.Trim() != string.Empty) 
                        {
                            mySqlCommand.CommandText = $"UPDATE `users` SET login='{login}',password='{password}'" +
                           $"type='{type}',name='{name}',surname='{surname}'" +
                           $"WHERE `id` = {idCourier};";
                        }
                        else
                        {
                            mySqlCommand.CommandText = $"UPDATE `users` SET login='{login}',password='{password}'" +
                           $"name='{name}',surname='{surname}'" +
                           $"WHERE `id` = {idCourier};";
                        }
                       
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

        //public Admin GetAdmin(User user)
        //{
        //    try
        //    {
        //        Admin admin = null;

        //        using (MySqlConnection mySqlConnection = DbConection.GetConnection())
        //        {
        //            mySqlConnection.Open();

        //            using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
        //            {
        //                mySqlCommand.CommandText = $"SELECT * FROM `table_users` WHERE `login`='{login}' AND `password`='{password}';";

        //                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
        //                {
        //                    if (mySqlDataReader.HasRows == true)
        //                    {
        //                        mySqlDataReader.Read();

        //                        admin = new Admin
        //                        {
        //                            Id = mySqlDataReader.GetInt32("id"),
        //                            Name = mySqlDataReader.GetString("name"),
        //                            SurName = mySqlDataReader.GetString("surname")
        //                        };
        //                    }
        //                    else
        //                    {
        //                        throw new WrongLoginPasswordException();
        //                    }
        //                }
        //            }
        //        }

        //        return admin;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }
}
