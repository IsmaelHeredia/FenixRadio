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
    public partial class FormAdd : Telerik.WinControls.UI.RadForm
    {
        public string program_title;
        public FormHome formHome;

        public FormAdd(FormHome formHome_here)
        {
            InitializeComponent();
            program_title = System.Configuration.ConfigurationManager.AppSettings["program_title"];
            formHome = formHome_here;
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
                    if (da.check_name_station_make(name))
                    {
                        RadMessageBox.Show("Name exists", program_title, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        if (da.check_link_station_make(link))
                        {
                            RadMessageBox.Show("Link exists", program_title, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            Station station = new Station(name, link, categories);
                            if (da.addStation(station))
                            {
                                RadMessageBox.Show("Saved", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                                formHome.loadStations("");
                                FormAdd.ActiveForm.Close();
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
    }
}
