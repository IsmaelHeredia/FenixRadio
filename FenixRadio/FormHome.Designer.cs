namespace FenixRadio
{
    partial class FormHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn5 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "ID");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn6 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Name");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn7 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Link");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn8 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 3", "Categories");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.timerStream = new System.Windows.Forms.Timer(this.components);
            this.progressBarBuffer = new System.Windows.Forms.BindingSource(this.components);
            this.rmOptions = new Telerik.WinControls.UI.RadMenu();
            this.rmFile = new Telerik.WinControls.UI.RadMenuItem();
            this.miAddNewStation = new Telerik.WinControls.UI.RadMenuItem();
            this.miValidateStations = new Telerik.WinControls.UI.RadMenuItem();
            this.rmiImportStations = new Telerik.WinControls.UI.RadMenuItem();
            this.rmiExportStations = new Telerik.WinControls.UI.RadMenuItem();
            this.rmiExit = new Telerik.WinControls.UI.RadMenuItem();
            this.rmHelp = new Telerik.WinControls.UI.RadMenuItem();
            this.rmiAbout = new Telerik.WinControls.UI.RadMenuItem();
            this.btnPlay = new Telerik.WinControls.UI.RadButton();
            this.lblBuffered = new Telerik.WinControls.UI.RadLabel();
            this.btnPause = new Telerik.WinControls.UI.RadButton();
            this.btnStop = new Telerik.WinControls.UI.RadButton();
            this.lblBuffer = new Telerik.WinControls.UI.RadLabel();
            this.vsVolume = new NAudio.Gui.VolumeSlider();
            this.pbBarBuffer = new Telerik.WinControls.UI.RadProgressBar();
            this.lvStations = new Telerik.WinControls.UI.RadListView();
            this.lblSearch = new Telerik.WinControls.UI.RadLabel();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBox();
            this.gbStations = new Telerik.WinControls.UI.RadGroupBox();
            this.telerikMetroTheme = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.ssStatus = new Telerik.WinControls.UI.RadStatusStrip();
            this.lblStatus = new Telerik.WinControls.UI.RadLabelElement();
            this.cmOptions = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.miEdit = new Telerik.WinControls.UI.RadMenuItem();
            this.miDelete = new Telerik.WinControls.UI.RadMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarBuffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuffered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarBuffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvStations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbStations)).BeginInit();
            this.gbStations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ssStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // timerStream
            // 
            this.timerStream.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rmOptions
            // 
            this.rmOptions.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.rmFile,
            this.rmHelp});
            this.rmOptions.Location = new System.Drawing.Point(0, 0);
            this.rmOptions.Name = "rmOptions";
            this.rmOptions.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.rmOptions.Size = new System.Drawing.Size(587, 29);
            this.rmOptions.TabIndex = 12;
            this.rmOptions.Text = "rmMenu";
            this.rmOptions.ThemeName = "TelerikMetro";
            // 
            // rmFile
            // 
            this.rmFile.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.miAddNewStation,
            this.miValidateStations,
            this.rmiImportStations,
            this.rmiExportStations,
            this.rmiExit});
            this.rmFile.Name = "rmFile";
            this.rmFile.Text = "File";
            // 
            // miAddNewStation
            // 
            this.miAddNewStation.Name = "miAddNewStation";
            this.miAddNewStation.Text = "Add new station";
            this.miAddNewStation.Click += new System.EventHandler(this.miAddNewStation_Click);
            // 
            // miValidateStations
            // 
            this.miValidateStations.Name = "miValidateStations";
            this.miValidateStations.Text = "Validate stations";
            this.miValidateStations.Click += new System.EventHandler(this.miValidateStations_Click);
            // 
            // rmiImportStations
            // 
            this.rmiImportStations.Name = "rmiImportStations";
            this.rmiImportStations.Text = "Import stations";
            this.rmiImportStations.Click += new System.EventHandler(this.rmiImportStations_Click);
            // 
            // rmiExportStations
            // 
            this.rmiExportStations.Name = "rmiExportStations";
            this.rmiExportStations.Text = "Export stations";
            this.rmiExportStations.Click += new System.EventHandler(this.rmiExportStations_Click);
            // 
            // rmiExit
            // 
            this.rmiExit.Name = "rmiExit";
            this.rmiExit.Text = "Exit";
            this.rmiExit.Click += new System.EventHandler(this.rmiExit_Click);
            // 
            // rmHelp
            // 
            this.rmHelp.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.rmiAbout});
            this.rmHelp.Name = "rmHelp";
            this.rmHelp.Text = "Help";
            // 
            // rmiAbout
            // 
            this.rmiAbout.Name = "rmiAbout";
            this.rmiAbout.Text = "About";
            this.rmiAbout.Click += new System.EventHandler(this.rmiAbout_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(105, 449);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(110, 24);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.ThemeName = "TelerikMetro";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblBuffered
            // 
            this.lblBuffered.Location = new System.Drawing.Point(11, 390);
            this.lblBuffered.Name = "lblBuffered";
            this.lblBuffered.Size = new System.Drawing.Size(58, 16);
            this.lblBuffered.TabIndex = 3;
            this.lblBuffered.Text = "Buffered : ";
            this.lblBuffered.ThemeName = "TelerikMetro";
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(233, 449);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(110, 24);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.ThemeName = "TelerikMetro";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(361, 449);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(110, 24);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.ThemeName = "TelerikMetro";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblBuffer
            // 
            this.lblBuffer.Location = new System.Drawing.Point(311, 394);
            this.lblBuffer.Name = "lblBuffer";
            this.lblBuffer.Size = new System.Drawing.Size(28, 16);
            this.lblBuffer.TabIndex = 8;
            this.lblBuffer.Text = "0,0s";
            this.lblBuffer.ThemeName = "TelerikMetro";
            // 
            // vsVolume
            // 
            this.vsVolume.Location = new System.Drawing.Point(463, 396);
            this.vsVolume.Name = "vsVolume";
            this.vsVolume.Size = new System.Drawing.Size(96, 16);
            this.vsVolume.TabIndex = 9;
            // 
            // pbBarBuffer
            // 
            this.pbBarBuffer.Location = new System.Drawing.Point(74, 390);
            this.pbBarBuffer.Name = "pbBarBuffer";
            this.pbBarBuffer.Size = new System.Drawing.Size(222, 24);
            this.pbBarBuffer.TabIndex = 10;
            this.pbBarBuffer.ThemeName = "TelerikMetro";
            // 
            // lvStations
            // 
            this.lvStations.AllowEdit = false;
            this.lvStations.AllowRemove = false;
            listViewDetailColumn5.HeaderText = "ID";
            listViewDetailColumn5.Visible = false;
            listViewDetailColumn6.HeaderText = "Name";
            listViewDetailColumn6.Width = 300F;
            listViewDetailColumn7.HeaderText = "Link";
            listViewDetailColumn7.Visible = false;
            listViewDetailColumn8.HeaderText = "Categories";
            listViewDetailColumn8.Width = 190F;
            this.lvStations.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn5,
            listViewDetailColumn6,
            listViewDetailColumn7,
            listViewDetailColumn8});
            this.lvStations.ItemSpacing = -1;
            this.lvStations.Location = new System.Drawing.Point(29, 90);
            this.lvStations.Name = "lvStations";
            this.lvStations.Size = new System.Drawing.Size(511, 214);
            this.lvStations.TabIndex = 0;
            this.lvStations.Text = "radListView1";
            this.lvStations.ThemeName = "TelerikMetro";
            this.lvStations.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.lvStations.ItemMouseDoubleClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.lvStations_ItemMouseDoubleClick);
            this.lvStations.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvStations_MouseClick);
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(29, 40);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(51, 16);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search : ";
            this.lblSearch.ThemeName = "TelerikMetro";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(86, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(321, 24);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.ThemeName = "TelerikMetro";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // gbStations
            // 
            this.gbStations.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbStations.Controls.Add(this.txtSearch);
            this.gbStations.Controls.Add(this.lblSearch);
            this.gbStations.Controls.Add(this.lvStations);
            this.gbStations.HeaderText = "Stations";
            this.gbStations.Location = new System.Drawing.Point(12, 44);
            this.gbStations.Name = "gbStations";
            this.gbStations.Size = new System.Drawing.Size(557, 322);
            this.gbStations.TabIndex = 11;
            this.gbStations.Text = "Stations";
            this.gbStations.ThemeName = "TelerikMetro";
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.lblStatus});
            this.ssStatus.Location = new System.Drawing.Point(0, 503);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(587, 25);
            this.ssStatus.TabIndex = 13;
            this.ssStatus.Text = "radStatusStrip1";
            this.ssStatus.ThemeName = "TelerikMetro";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Bounds = new System.Drawing.Rectangle(0, 0, 506, 19);
            this.lblStatus.DefaultSize = new System.Drawing.Size(300, 0);
            this.lblStatus.Name = "lblStatus";
            this.ssStatus.SetSpring(this.lblStatus, true);
            this.lblStatus.Text = "Done";
            this.lblStatus.TextWrap = true;
            // 
            // cmOptions
            // 
            this.cmOptions.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.miEdit,
            this.miDelete});
            // 
            // miEdit
            // 
            this.miEdit.Name = "miEdit";
            this.miEdit.Text = "Edit";
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Text = "Delete";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 528);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.rmOptions);
            this.Controls.Add(this.gbStations);
            this.Controls.Add(this.pbBarBuffer);
            this.Controls.Add(this.vsVolume);
            this.Controls.Add(this.lblBuffer);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.lblBuffered);
            this.Controls.Add(this.btnPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormHome";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Fenix Radio 1.0";
            this.ThemeName = "TelerikMetro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHome_FormClosing);
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.Resize += new System.EventHandler(this.FormHome_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarBuffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuffered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarBuffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvStations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbStations)).EndInit();
            this.gbStations.ResumeLayout(false);
            this.gbStations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ssStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerStream;
        private System.Windows.Forms.BindingSource progressBarBuffer;
        private Telerik.WinControls.UI.RadMenu rmOptions;
        private Telerik.WinControls.UI.RadMenuItem rmFile;
        private Telerik.WinControls.UI.RadMenuItem miAddNewStation;
        private Telerik.WinControls.UI.RadMenuItem rmiImportStations;
        private Telerik.WinControls.UI.RadMenuItem rmiExportStations;
        private Telerik.WinControls.UI.RadMenuItem rmiExit;
        private Telerik.WinControls.UI.RadMenuItem rmHelp;
        private Telerik.WinControls.UI.RadMenuItem rmiAbout;
        private Telerik.WinControls.UI.RadButton btnPlay;
        private Telerik.WinControls.UI.RadLabel lblBuffered;
        private Telerik.WinControls.UI.RadButton btnPause;
        private Telerik.WinControls.UI.RadButton btnStop;
        private Telerik.WinControls.UI.RadLabel lblBuffer;
        private NAudio.Gui.VolumeSlider vsVolume;
        private Telerik.WinControls.UI.RadProgressBar pbBarBuffer;
        private Telerik.WinControls.UI.RadListView lvStations;
        private Telerik.WinControls.UI.RadLabel lblSearch;
        private Telerik.WinControls.UI.RadTextBox txtSearch;
        private Telerik.WinControls.UI.RadGroupBox gbStations;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme;
        private Telerik.WinControls.UI.RadMenuItem miValidateStations;
        private Telerik.WinControls.UI.RadStatusStrip ssStatus;
        private Telerik.WinControls.UI.RadLabelElement lblStatus;
        private Telerik.WinControls.UI.RadContextMenu cmOptions;
        private Telerik.WinControls.UI.RadMenuItem miEdit;
        private Telerik.WinControls.UI.RadMenuItem miDelete;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}