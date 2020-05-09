using System;
using System.Collections.Generic;
using System.Text;

namespace FenixRadio
{
    class Station
    {
        int id_station;
        string name;
        string link;
        string categories;

        public int Id_station
        {
            get
            {
                return id_station;
            }

            set
            {
                id_station = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Link
        {
            get
            {
                return link;
            }

            set
            {
                link = value;
            }
        }

        public string Categories
        {
            get
            {
                return categories;
            }

            set
            {
                categories = value;
            }
        }

        public Station()
        {

        }

        public Station(string namez, string linkz, string categoriesz)
        {
            name = namez;
            link = linkz;
            categories = categoriesz;
        }
    }
}
