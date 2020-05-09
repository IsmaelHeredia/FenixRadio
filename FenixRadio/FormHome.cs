// Fenix Radio 1.0
// Copyright © Ismael Heredia 2020

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using NAudio.Wave;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Newtonsoft.Json;
using System.Data;

namespace FenixRadio
{
    public partial class FormHome : Telerik.WinControls.UI.RadForm
    {

        public string database;
        public string program_title;
        FormAdd formAdd = new FormAdd(null);
        FormEdit formEdit = new FormEdit(null, 0);
        Functions function = new Functions();

        enum StreamingPlaybackState
        {
            Stopped,
            Playing,
            Buffering,
            Paused
        }

        public FormHome()
        {
            InitializeComponent();

            database = System.Configuration.ConfigurationManager.AppSettings["database_name"];
            program_title = System.Configuration.ConfigurationManager.AppSettings["program_title"];

            vsVolume.VolumeChanged += OnVolumeSliderChanged;
            Disposed += MP3StreamingPanel_Disposing;

            miEdit.Click += miEdit_Click;
            miDelete.Click += miDelete_Click;

            notifyIcon.Text = program_title;

            RadMessageBox.SetThemeName("TelerikMetro");
        }

        public void sendStatus(string text)
        {
            lblStatus.Text = text;
            ssStatus.LayoutManager.UpdateLayout();
            ssStatus.Refresh();
        }

        public void loadStations(string search)
        {
            if(search == "")
            {
                search = txtSearch.Text;
            }

            lvStations.Items.Clear();
            if (File.Exists(Path.GetFullPath(database)))
            {
                DataAccess da = new DataAccess();
                ArrayList listStations = da.listStations(search);
                foreach (Station station in listStations)
                {
                    int id_station = station.Id_station;
                    string name = station.Name;
                    string link = station.Link;
                    string categories = station.Categories;
                    ListViewDataItem item = new ListViewDataItem();
                    item.SubItems.Add(id_station);
                    item.SubItems.Add(name);
                    item.SubItems.Add(link);
                    item.SubItems.Add(categories);
                    lvStations.Items.Add(item);
                }
                gbStations.Text = "Stations : " + lvStations.Items.Count + " found";
            }
        }

        public void play_stream()
        {
            if (lvStations.SelectedIndex > -1)
            {
                string name = lvStations.SelectedItem[1].ToString();
                string url = lvStations.SelectedItem[2].ToString();
                stop_stream();
                if (function.check_url(url))
                {
                    sendStatus("Playing station " + name + " ...");

                    if (playbackState == StreamingPlaybackState.Stopped)
                    {
                        playbackState = StreamingPlaybackState.Buffering;
                        bufferedWaveProvider = null;
                        ThreadPool.QueueUserWorkItem(StreamMp3, url);
                        timerStream.Enabled = true;
                    }
                    else if (playbackState == StreamingPlaybackState.Paused)
                    {
                        playbackState = StreamingPlaybackState.Buffering;
                    }
                }
                else
                {
                    RadMessageBox.Show("Station " + name + " not work", program_title, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                RadMessageBox.Show("Select station", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
            }
        }

        void OnVolumeSliderChanged(object sender, EventArgs e)
        {
            if (volumeProvider != null)
            {
                volumeProvider.Volume = vsVolume.Volume;
            }
        }

        private BufferedWaveProvider bufferedWaveProvider;
        private IWavePlayer waveOut;
        private volatile StreamingPlaybackState playbackState;
        private volatile bool fullyDownloaded;
        private HttpWebRequest webRequest;
        private VolumeWaveProvider16 volumeProvider;

        delegate void ShowErrorDelegate(string message);

        private void ShowError(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ShowErrorDelegate(ShowError), message);
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void StreamMp3(object state)
        {
            fullyDownloaded = false;
            var url = (string)state;
            webRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status != WebExceptionStatus.RequestCanceled)
                {
                    ShowError(e.Message);
                }
                return;
            }
            var buffer = new byte[16384 * 4];

            IMp3FrameDecompressor decompressor = null;
            try
            {
                using (var responseStream = resp.GetResponseStream())
                {
                    var readFullyStream = new ReadFullyStream(responseStream);
                    do
                    {
                        if (IsBufferNearlyFull)
                        {
                            Thread.Sleep(500);
                        }
                        else
                        {
                            Mp3Frame frame;
                            try
                            {
                                frame = Mp3Frame.LoadFromStream(readFullyStream);
                            }
                            catch (EndOfStreamException)
                            {
                                fullyDownloaded = true;
                                break;
                            }
                            catch (WebException)
                            {
                                break;
                            }
                            if (frame == null) break;
                            if (decompressor == null)
                            {

                                decompressor = CreateFrameDecompressor(frame);
                                bufferedWaveProvider = new BufferedWaveProvider(decompressor.OutputFormat);
                                bufferedWaveProvider.BufferDuration =
                                    TimeSpan.FromSeconds(20);
                            }
                            int decompressed = decompressor.DecompressFrame(frame, buffer, 0);
                            bufferedWaveProvider.AddSamples(buffer, 0, decompressed);
                        }

                    } while (playbackState != StreamingPlaybackState.Stopped);
                    decompressor.Dispose();
                }
            }
            finally
            {
                if (decompressor != null)
                {
                    decompressor.Dispose();
                }
            }
        }

        private static IMp3FrameDecompressor CreateFrameDecompressor(Mp3Frame frame)
        {
            WaveFormat waveFormat = new Mp3WaveFormat(frame.SampleRate, frame.ChannelMode == ChannelMode.Mono ? 1 : 2,
                frame.FrameLength, frame.BitRate);
            return new AcmMp3FrameDecompressor(waveFormat);
        }

        private bool IsBufferNearlyFull
        {
            get
            {
                return bufferedWaveProvider != null &&
                       bufferedWaveProvider.BufferLength - bufferedWaveProvider.BufferedBytes
                       < bufferedWaveProvider.WaveFormat.AverageBytesPerSecond / 4;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            play_stream();
        }

        private void stop_stream()
        {
            if (playbackState != StreamingPlaybackState.Stopped)
            {
                if (!fullyDownloaded)
                {
                    webRequest.Abort();
                }

                playbackState = StreamingPlaybackState.Stopped;
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                    waveOut = null;
                }
                timerStream.Enabled = false;
                Thread.Sleep(500);
                ShowBufferState(0);
            }
            sendStatus("Done");
        }

        private void ShowBufferState(double totalSeconds)
        {
            lblBuffer.Text = String.Format("{0:0.0}s", totalSeconds);
            pbBarBuffer.Value1 = (int)(totalSeconds * 1000);
        }

        private void Play()
        {
            waveOut.Play();
            playbackState = StreamingPlaybackState.Playing;
        }

        private void Pause()
        {
            playbackState = StreamingPlaybackState.Buffering;
            waveOut.Pause();
        }

        private IWavePlayer CreateWaveOut()
        {
            return new WaveOut();
        }

        private void MP3StreamingPanel_Disposing(object sender, EventArgs e)
        {
            stop_stream();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (playbackState == StreamingPlaybackState.Playing || playbackState == StreamingPlaybackState.Buffering)
            {
                waveOut.Pause();
                playbackState = StreamingPlaybackState.Paused;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stop_stream();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (e.Exception != null)
            {
                MessageBox.Show(String.Format("Playback Error {0}", e.Exception.Message));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (playbackState != StreamingPlaybackState.Stopped)
            {
                if (waveOut == null && bufferedWaveProvider != null)
                {
                    waveOut = CreateWaveOut();
                    waveOut.PlaybackStopped += OnPlaybackStopped;
                    volumeProvider = new VolumeWaveProvider16(bufferedWaveProvider);
                    volumeProvider.Volume = vsVolume.Volume;
                    waveOut.Init(volumeProvider);
                    pbBarBuffer.Maximum = (int)bufferedWaveProvider.BufferDuration.TotalMilliseconds; // ACA
                }
                else if (bufferedWaveProvider != null)
                {
                    var bufferedSeconds = bufferedWaveProvider.BufferedDuration.TotalSeconds;
                    ShowBufferState(bufferedSeconds);
                    if (bufferedSeconds < 0.5 && playbackState == StreamingPlaybackState.Playing && !fullyDownloaded)
                    {
                        Pause();
                    }
                    else if (bufferedSeconds > 4 && playbackState == StreamingPlaybackState.Buffering)
                    {
                        Play();
                    }
                    else if (fullyDownloaded && bufferedSeconds == 0)
                    {
                        stop_stream();
                    }
                }

            }
        }

        private void miAddNewStation_Click(object sender, EventArgs e)
        {
            if (!formAdd.Visible)
            {
                stop_stream();
                formAdd = new FormAdd(this);
                formAdd.Show();
            }
        }

        private void miValidateStations_Click(object sender, EventArgs e)
        {
            stop_stream();
            ArrayList listStationsFail = new ArrayList();
            string message = "";
            foreach (ListViewDataItem item in lvStations.Items)
            {
                Station station = new Station();
                station.Id_station = Convert.ToInt32(item[0]);
                station.Name = item[1].ToString();
                station.Link = item[2].ToString();

                sendStatus("Checking station : " + station.Name + " ...");

                if (!function.check_url(station.Link))
                {
                    listStationsFail.Add(station);
                    message += "Radio name : " + station.Name + "\n";
                }
            }
            if (listStationsFail.Count > 0)
            {
                RadMessageBox.Show(message, program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);

                DialogResult ds = RadMessageBox.Show(this, "You want delete this stations ?", program_title, MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (ds.ToString() == "Yes")
                {
                    DataAccess da = new DataAccess();
                    foreach (Station station in listStationsFail)
                    {
                        da.deleteStation(station.Id_station);
                    }
                }
            }
            else
            {
                RadMessageBox.Show("All stations works", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
            }
            sendStatus("Done");
        }

        private void rmiImportStations_Click(object sender, EventArgs e)
        {
            stop_stream();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Title = "Save JSON File";
            openFileDialog.DefaultExt = "json";
            openFileDialog.Filter = "JSON File (.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sendStatus("Importing ...");
                string json_file = openFileDialog.FileName;
                ArrayList listStations = new ArrayList();
                string json_content = File.ReadAllText(json_file);
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(json_content, (typeof(DataTable)));
                foreach (DataRow row in dt.Rows)
                {
                    Station station = new Station();
                    station.Name = Convert.ToString(row["name"]);
                    station.Link = Convert.ToString(row["link"]);
                    station.Categories = Convert.ToString(row["categories"]);
                    listStations.Add(station);
                }
                Installer install = new Installer();
                install.create_database();
                DataAccess da = new DataAccess();
                foreach (Station station in listStations)
                {
                    da.addStation(station);
                }
                loadStations("");
                sendStatus("Done");
                RadMessageBox.Show("Table imported", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
            }
        }

        private void rmiExportStations_Click(object sender, EventArgs e)
        {
            stop_stream();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.Title = "Save JSON File";
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.Filter = "JSON File (.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json_file = saveFileDialog.FileName;
                if (File.Exists(json_file))
                {
                    File.Delete(json_file);
                }
                DataAccess da = new DataAccess();
                sendStatus("Exporting ...");
                DataTable dt = da.loadStationTable();
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(dt, Formatting.Indented);
                StreamWriter sw = File.CreateText(json_file);
                sw.Write(JSONString);
                sw.Close();
                sendStatus("Done");
                RadMessageBox.Show("Table exported", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
            }
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Path.GetFullPath(database)))
            {
                sendStatus("Creating database ...");
                Installer install = new Installer();
                install.create_database();
                install.load_stations();
                sendStatus("Done");
                RadMessageBox.Show("Database created", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
            }
            loadStations("");
        }

        private void lvStations_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            play_stream();
        }

        private void miEdit_Click(object sender, EventArgs e)
        {
            if (!formEdit.Visible)
            {
                stop_stream();
                var id_station = Convert.ToInt32(lvStations.SelectedItem[0]);
                formEdit = new FormEdit(this, id_station);
                formEdit.Show();
            }
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            DialogResult ds = RadMessageBox.Show(this, "Are you sure ?", program_title, MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (ds.ToString() == "Yes")
            {
                stop_stream();
                var id_station = Convert.ToInt32(lvStations.SelectedItem[0]);
                DataAccess da = new DataAccess();
                if (da.deleteStation(id_station))
                {
                    RadMessageBox.Show("Station deleted", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    RadMessageBox.Show("Error deleting station", program_title, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
                loadStations("");
            }
        }

        private void lvStations_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvStations.SelectedIndex > -1)
                {
                    cmOptions.Show(Cursor.Position);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadStations(txtSearch.Text);
        }

        private void FormHome_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;

                if (formAdd.Visible)
                {
                    formAdd.Visible = false;
                }

                if (formEdit.Visible)
                {
                    formEdit.Visible = false;
                }

                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void rmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rmiAbout_Click(object sender, EventArgs e)
        {
            RadMessageBox.Show("Copyright © Ismael Heredia 2020", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
        }

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop_stream();
            DialogResult ds = RadMessageBox.Show(this, "Are you sure ?", program_title, MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (ds.ToString() != "Yes")
            {
                e.Cancel = true;
                this.Activate();
            }
        }
    }
}
