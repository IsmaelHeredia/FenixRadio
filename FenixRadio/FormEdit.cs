using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace FenixRadio
{
    public partial class FormEdit : Telerik.WinControls.UI.RadForm
    {
        public string program_title;
        public FormHome formHome;
        public int id_station;

        public FormEdit(FormHome formHome_here, int id_station_here)
        {
            InitializeComponent();
            program_title = System.Configuration.ConfigurationManager.AppSettings["program_title"];
            formHome = formHome_here;
            id_station = id_station_here;
            RadMessageBox.SetThemeName("TelerikMetro");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string link = txtLink.Text;
            string categories = txtCategories.Text;

            if (name != "" && link != "" && categories != "")
            {
                Functions functions = new Functions();
                if (functions.check_url(link))
                {
                    DataAccess da = new DataAccess();
                    if (da.check_name_station_edit(id_station, name))
                    {
                        RadMessageBox.Show("Name exists", program_title, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        if (da.check_link_station_edit(id_station, link))
                        {
                            RadMessageBox.Show("Link exists", program_title, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            Station station = new Station();
                            station.Id_station = id_station;
                            station.Name = name;
                            station.Link = link;
                            station.Categories = categories;
                            if (da.editStation(station))
                            {
                                RadMessageBox.Show("Saved", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                                formHome.loadStations("");
                                FormEdit.ActiveForm.Close();
                            }
                            else
                            {
                                RadMessageBox.Show("Error saving", program_title, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                }
                else
                {
                    RadMessageBox.Show("Link not work", program_title, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                RadMessageBox.Show("Complete form", program_title, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            Station station = da.loadStation(id_station);
            txtName.Text = station.Name;
            txtLink.Text = station.Link;
            txtCategories.Text = station.Categories;
        }
    }
}
