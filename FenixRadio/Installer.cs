using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace FenixRadio
{
    class Installer
    {

        public Boolean create_database()
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

            connection.close();

            return response;
        }

        public bool load_stations()
        {
            bool response = false;
            DataAccess da = new DataAccess();
            try
            {
                //da.addStation(new Station("", "", ""));

                // Rock

                da.addStation(new Station("Alternative Rock", "http://7579.live.streamtheworld.com:80/977_ALTERN_SC", "Rock"));
                da.addStation(new Station("Bulldogs-Radio", "http://198.58.98.83:8062/stream", "Rock, Heavy Metal"));
                da.addStation(new Station("Classic Rock 2", "http://7599.live.streamtheworld.com:80/977_CLASSROCK_SC", "Rock"));
                da.addStation(new Station("Classic Rock Florida HD", "http://198.58.98.83:8258/stream", "Rock"));
                da.addStation(new Station("KNKl Pirate Radio Sturgis", "http://us4.internet-radio.com:8223/stream", "Rock"));
                da.addStation(new Station("Meat Liquor", "http://uk1.internet-radio.com:8011/stream", "Rock"));
                da.addStation(new Station("San Franciscos 70s HITS", "http://198.178.123.17:10922/stream", "Rock, Oldies"));
                da.addStation(new Station("Magic 80s Florida", "http://airspectrum.cdnstream1.com:8018/1606_192", "Rock, Oldies"));
                da.addStation(new Station("Radio Bloodstream", "http://uk1.internet-radio.com:8294/stream", "Rock, Metal"));
                da.addStation(new Station("Hard Rock Radio Live", "http://listen.radionomy.com/hardrockradioliveclassicrock", "Rock, Classic Rock"));
                
                // Electronic

                da.addStation(new Station("#MUSIK.TECHHOUSE (PROGRESSIVE) - WWW.RAUTEMUSIK.FM - 24H MIXED PROGRESSIVE ELECTRO MINIMAL AND MORE!", "http://techhouse-high.rautemusik.fm", "Techno"));
                da.addStation(new Station("Eye Of Destiny Radio", "http://uk6.internet-radio.com:8428/stream", "Chillout"));
                da.addStation(new Station("LOUNGE-RADIO.COM swiss made", "http://77.235.42.90:80/stream", "Chillout"));
                da.addStation(new Station("MoveDaHouse", "http://212.71.250.12:8000/stream", "House"));
                da.addStation(new Station("PARTY VIBE RADIO : ALL THE HITS ALL THE TIME", "http://uk6.internet-radio.com:8124/stream", "Dance"));
                da.addStation(new Station("PARTY VIBE RADIO : AMBIENT + CHILLOUT + RELAXATION", "http://www.partyviberadio.com:8056/stream", "Meditation"));
                da.addStation(new Station("PARTY VIBE RADIO : DUBSTEP + TRAP + BASS", "http://www.partyviberadio.com:8040/stream", "Dubstep"));
                da.addStation(new Station("PARTY VIBE RADIO : TECHNO + HOUSE + TRANCE + ELECTRONIC", "http://www.partyviberadio.com:8046/stream", "Techno"));
                da.addStation(new Station("PulseEDM Dance Music Radio", "http://pulseedm.cdnstream1.com:8124/1373_128", "Dubstep"));
                da.addStation(new Station("Radio Play Emotions", "http://5.39.82.157:8054/stream", "Dubstep"));
                da.addStation(new Station("SOUL CENTRAL RADIO", "http://178.79.158.160:8179/stream", "Deep House"));

                // Country

                // ?

                // Alternative

                da.addStation(new Station("The Zone- Dublin", "http://uk1.internet-radio.com:8355/stream", "Alternative"));

                // Classic

                da.addStation(new Station("Venice Classic Radio Italia", "http://174.36.206.197:8000/stream", "Classical"));

                // Jazz

                da.addStation(new Station("JAZZGROOVE.org", "http://199.180.72.2:8015/stream", "Jazz"));

                // Rap - Hip hop

                da.addStation(new Station("Faymus Radio", "http://uk7.internet-radio.com:8078/stream", "Rap"));
                da.addStation(new Station("HOT 108 JAMZ - #1 FOR HIP HOP - www.hot108.com (a Powerhitz.com station)", "http://hot108jamz.hot108.com:4040", "Hip Hop"));
                da.addStation(new Station("PARTY VIBE RADIO : RAP + HIP HOP + TRAP + DUBSTEP", "http://www.partyviberadio.com:8016/stream", "Rap, Hip Hop, Trap, Dubstep"));
                da.addStation(new Station("The Grammar Club Radio", "http://us4.internet-radio.com:8212/stream", "Rap"));
                da.addStation(new Station("Power 95 Bermuda", "http://us3.internet-radio.com:8026/stream", "Hip Hop"));
                da.addStation(new Station("Pigpen Radio", "http://178.79.158.160:8213/stream", "Hip Hop"));

                // Top 40

                da.addStation(new Station("Merge 104.8", "http://212.71.250.12:8040/stream", "Top40"));

                // Pop

                da.addStation(new Station("PopTron: Electro-Pop and Indie Dance Rock [SomaFM]", "http://ice3.somafm.com/poptron-128-mp3", "Pop"));
                da.addStation(new Station("Yabloki Radio", "http://uk6.internet-radio.com:8365/stream", "Pop"));

                response = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
