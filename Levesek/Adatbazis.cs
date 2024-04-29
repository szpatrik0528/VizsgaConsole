using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levesek
{
    internal class Adatbazis
    {

        MySqlCommand sqlCommand;
        MySqlConnection connection;

        public Adatbazis()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "levesek";
            connection = new MySqlConnection(builder.ConnectionString);
            sqlCommand = connection.CreateCommand();
            try
            {
                kapcsolatNyit();
                kapcsolatZar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        private void kapcsolatZar()
        {
            if(connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        private void kapcsolatNyit()
        {
            if(connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        internal List<Levesek> getAllLevesek()
        {
            List<Levesek> levesek = new List<Levesek>();
            sqlCommand.CommandText = "SELECT `megnevezes`, `kaloria`, `feherje`, `zsir`, `szenhidrat`, `hamu`, `rost` FROM `levesek`";
            kapcsolatNyit();
            using(MySqlDataReader dr = sqlCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    Levesek leveseks = new Levesek(dr.GetString("megnevezes"), dr.GetInt32("kaloria"), dr.GetDouble("feherje"), dr.GetDouble("zsir"), dr.GetDouble("szenhidrat"), dr.GetDouble("hamu"), dr.GetDouble("rost"));
                    levesek.Add(leveseks);
                }
                return levesek;
            }
            kapcsolatZar();
        }
    }
}
