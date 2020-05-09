using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace FenixRadio
{
    class DataAccess
    {
        public DataAccess()
        {
        }

        public Boolean update_database(ArrayList listStations)
        {
            Boolean response = false;

            Connection connection = new Connection();
            connection.open();

            string sql_drop = "DROP TABLE IF EXISTS stations;";

            SQLiteCommand cmd_drop = new SQLiteCommand(sql_drop, connection.connection);
            cmd_drop.ExecuteNonQuery();

            string sql_create_table = "CREATE TABLE stations(id_station integer PRIMARY KEY autoincrement,name nvarchar(100),link nvarchar(100), categories nvarchar(100));";

            SQLiteCommand cmd_create = new SQLiteCommand(sql_create_table, connection.connection);
            cmd_create.ExecuteNonQuery();

            try
            {
                foreach (Station station in listStations)
                {
                    string name = station.Name;
                    string link = station.Link;
                    string categories = station.Categories;

                    var query = new SQLiteCommand("INSERT INTO stations(name, link, categories) VALUES (@p0, @p1, @p2)", connection.connection);

                    query.Parameters.AddWithValue("@p0", name);
                    query.Parameters.AddWithValue("@p1", link);
                    query.Parameters.AddWithValue("@p2", categories);

                    query.ExecuteNonQuery();
                }

                response = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            connection.close();

            return response;
        }

        public ArrayList listStations(string search)
        {
            ArrayList listStations = new ArrayList();
            Connection connection = new Connection();
            connection.open();

            var query = new SQLiteCommand("SELECT id_station, name, link, categories FROM stations WHERE name LIKE @p0 OR categories LIKE @p0", connection.connection);
            query.Parameters.AddWithValue("@p0", "%" + search + "%");

            var reader = query.ExecuteReader();

            while (reader.Read())
            {
                Station station = new Station();
                if (!reader.IsDBNull(0))
                {
                    station.Id_station = reader.GetInt32(0);
                }
                if (!reader.IsDBNull(1))
                {
                    station.Name = reader.GetString(1);
                }
                if (!reader.IsDBNull(2))
                {
                    station.Link = reader.GetString(2);
                }
                if (!reader.IsDBNull(3))
                {
                    station.Categories = reader.GetString(3);
                }
                listStations.Add(station);
            }
            reader.Close();
            connection.close();
            return listStations;
        }

        public Boolean addStation(Station station)
        {
            Boolean response = false;

            Connection connection = new Connection();
            connection.open();

            try
            {
                string name = station.Name;
                string link = station.Link;
                string categories = station.Categories;

                var query = new SQLiteCommand("INSERT INTO stations(name, link, categories) VALUES (@p0, @p1, @p2)", connection.connection);

                query.Parameters.AddWithValue("@p0", name);
                query.Parameters.AddWithValue("@p1", link);
                query.Parameters.AddWithValue("@p2", categories);

                query.ExecuteNonQuery();

                response = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            connection.close();

            return response;
        }

        public Station loadStation(int id_station)
        {
            Station station = new Station();
            Connection connection = new Connection();
            connection.open();

            var query = new SQLiteCommand("SELECT id_station, name, link, categories FROM stations WHERE id_station = @p0", connection.connection);
            query.Parameters.AddWithValue("@p0", id_station);

            var reader = query.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                if (!reader.IsDBNull(0))
                {
                    station.Id_station = reader.GetInt32(0);
                }
                if (!reader.IsDBNull(1))
                {
                    station.Name = reader.GetString(1);
                }
                if (!reader.IsDBNull(2))
                {
                    station.Link = reader.GetString(2);
                }
                if (!reader.IsDBNull(3))
                {
                    station.Categories = reader.GetString(3);
                }
            }
            reader.Close();
            connection.close();
            return station;
        }

        public Boolean editStation(Station station)
        {
            Boolean response = false;

            Connection connection = new Connection();
            connection.open();

            try
            {
                int id_station = station.Id_station;
                string name = station.Name;
                string link = station.Link;
                string categories = station.Categories;

                var query = new SQLiteCommand("UPDATE stations SET name = @p0, link = @p1, categories = @p2 WHERE id_station = @p3", connection.connection);

                query.Parameters.AddWithValue("@p0", name);
                query.Parameters.AddWithValue("@p1", link);
                query.Parameters.AddWithValue("@p2", categories);
                query.Parameters.AddWithValue("@p3", id_station);

                query.ExecuteNonQuery();

                response = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            connection.close();

            return response;
        }

        public Boolean deleteStation(int id_station)
        {
            Boolean response = false;

            Connection connection = new Connection();
            connection.open();

            try
            {
                var query = new SQLiteCommand("DELETE FROM stations WHERE id_station = @p0", connection.connection);

                query.Parameters.AddWithValue("@p0", id_station);

                query.ExecuteNonQuery();

                response = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            connection.close();

            return response;
        }

        public bool check_name_station_make(string name)
        {
            Boolean response = false;

            Connection connection = new Connection();
            connection.open();
            var query = new SQLiteCommand("SELECT COUNT(*) FROM stations WHERE name = @p0", connection.connection);
            query.Parameters.AddWithValue("@p0", name);
            var result = query.ExecuteScalar().ToString();
            int count = Convert.ToInt32(result);
            if (count >= 1)
            {
                response = true;
            }
            connection.close();

            return response;
        }

        public bool check_name_station_edit(int id_station, string name)
        {
            Boolean response = false;

            Connection connection = new Connection();
            connection.open();
            var query = new SQLiteCommand("SELECT COUNT(*) FROM stations WHERE name = @p0 AND id_station != @p1", connection.connection);
            query.Parameters.AddWithValue("@p0", name);
            query.Parameters.AddWithValue("@p1", id_station);
            var result = query.ExecuteScalar().ToString();
            int count = Convert.ToInt32(result);
            if (count >= 1)
            {
                response = true;
            }
            connection.close();

            return response;
        }

        public bool check_link_station_make(string link)
        {
            Boolean response = false;

            Connection connection = new Connection();
            connection.open();
            var query = new SQLiteCommand("SELECT COUNT(*) FROM stations WHERE link = @p0", connection.connection);
            query.Parameters.AddWithValue("@p0", link);
            var result = query.ExecuteScalar().ToString();
            int count = Convert.ToInt32(result);
            if (count >= 1)
            {
                response = true;
            }
            connection.close();

            return response;
        }

        public bool check_link_station_edit(int id_station, string link)
        {
            Boolean response = false;

            Connection connection = new Connection();
            connection.open();
            var query = new SQLiteCommand("SELECT COUNT(*) FROM stations WHERE link = @p0 AND id_station != @p1", connection.connection);
            query.Parameters.AddWithValue("@p0", link);
            query.Parameters.AddWithValue("@p1", id_station);
            var result = query.ExecuteScalar().ToString();
            int count = Convert.ToInt32(result);
            if (count >= 1)
            {
                response = true;
            }
            connection.close();

            return response;
        }

        public DataTable loadStationTable()
        {
            Connection connection = new Connection();
            connection.open();
            DataTable dt = new DataTable();
            connection.command.CommandText = "SELECT name, link, categories FROM stations";
            dt.Load(connection.command.ExecuteReader());
            connection.close();
            return dt;
        }

    }
}
