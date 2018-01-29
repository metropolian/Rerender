using DmShared.UI;
using EmergenceGuardian.FFmpeg;
using ShellLib;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Shell;
using Windows.UI.Notifications;

namespace Rerender
{
    public partial class FormMainConvertor : Form
    {
        private WorkingState CurrentState = WorkingState.Idle;
        private BackgroundWorker worker;
        private FFmpegProcess worker_process;
        private string Overlay_fname;

        private DateTime start_time;
        private TimeSpan inteval_time;
        private TaskbarItemInfo WindowsTaskbar;
        
        public FormMainConvertor()
        {
            InitializeComponent();
        }

        private void FormMainConvertor_Load(object sender, EventArgs e)
        {
            FFmpegConfig.FFmpegPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\ffmpeg.exe";
            FFmpegConfig.UserInterfaceManager = new FFmpegUserInterfaceManager(this);
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            WindowsTaskbar = new TaskbarItemInfo();

            AllowDrop = true;

        }

        private void FormMainConvertor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void FormMainConvertor_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (worker.IsBusy)
                MessageBox.Show("Convertor is working.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                LoadFiles(files);
        }

        private void LoadFiles(string[] files)
        {
            if (files.Length >= 2)
            {
                LoadFile(files[0]);
                Tx_src_fname.Text = string.Join(",", files);
            }
            else if (files.Length > 0)
                LoadFile(files[0]);
        }

        private void LoadFile(string fname)
        {
            var data = MediaInfo.GetFileInfo(fname);
            
            if (data.VideoStream != null)
            {
                Tx_src_fname.Text = fname;
                Tx_src_W.Text = data.VideoStream.Width.ToString();
                Tx_src_H.Text = data.VideoStream.Height.ToString();
                Tx_src_pixel_format.Text = data.VideoStream.ColorSpace;

                Tx_dst_fname.Text = Path.Combine(Path.GetDirectoryName(fname), 
                    Path.GetFileNameWithoutExtension(fname) + "." + Math.Round(DateTime.Now.TimeOfDay.TotalSeconds).ToString() + ".mp4");

                Tx_src_length.Text = data.FrameCount.ToString();
                Tx_src_time.Text = string.Format("{0:00}:{1:00}:{2:00}", data.FileDuration.TotalHours, data.FileDuration.Minutes, data.FileDuration.Seconds);

                Px_progress.Minimum = 0;
                Px_progress.Value = 0;
                Px_progress.Maximum = (int) data.FrameCount;

                Bt_start.Enabled = true;
            }

            
        }

        private string Get_Config_Parameters()
        {
            string st_args = "-y ";
            string i_args = " -i \"" + Tx_src_fname.Text + "\" ";
            string o_args = " \"" + Tx_dst_fname.Text + "\" ";

            if (Ch_src_hwaccel.Checked)
                i_args = " -hwaccel cuvid " + i_args;

            if (Tx_src_fname.Text.IndexOf(',') >= 0)
            {
                FileInfo finfo = new FileInfo("filelist.txt");
                StreamWriter f = new StreamWriter(finfo.FullName, false);
                foreach (var item in Tx_src_fname.Text.Split(','))
                {
                    f.WriteLine("file '" + item + "'");
                }
                f.Close();
                i_args = " -f concat -safe 0 -i \"" + finfo.FullName + "\" ";
            }

            string flip = "";
            if (Ch_deshake.Checked)
                flip += "deshake,";
            if (Ch_hflip.Checked)
                flip += "hflip,";
            if (Ch_vflip.Checked)
                flip += "vflip,";

            string v_filters = "";
            if (Tx_filters.Text != "")
                v_filters += Tx_filters.Text + ",";

            v_filters += flip + 
                "scale=" + Tx_dst_W.Text + ":" + Tx_dst_H.Text + ":force_original_aspect_ratio=decrease , " + 
                "pad=" + Tx_dst_W.Text + ":" + Tx_dst_H.Text + ":(ow-iw)/2:(oh-ih)/2 ";

            if (Ch_overlay.Checked)
            {
                i_args += " -i \"" + Overlay_fname + "\" ";

                if (Ch_overlay_CC.Checked)
                    v_filters += ", overlay=(main_w-overlay_w)/2:(main_h-overlay_h)/2 ";
                else if (Ch_overlay_LT.Checked)
                    v_filters += ", overlay=0:0 ";
                else if (Ch_overlay_CT.Checked)
                    v_filters += ", overlay=(main_w-overlay_w)/2:0 ";
                else if (Ch_overlay_RT.Checked)
                    v_filters += ", overlay=main_w-overlay_w:0 ";
                else if (Ch_overlay_LC.Checked)
                    v_filters += ", overlay=0:(main_h-overlay_h)/2 ";
                else if (Ch_overlay_RC.Checked)
                    v_filters += ", overlay=main_w-overlay_w:(main_h-overlay_h)/2 ";
                else if (Ch_overlay_LB.Checked)
                    v_filters += ", overlay=0:main_h-overlay_h  ";
                else if (Ch_overlay_CB.Checked)
                    v_filters += ", overlay=(main_w-overlay_w)/2:main_h-overlay_h ";
                else if (Ch_overlay_RB.Checked)
                    v_filters += ", overlay=main_w-overlay_w:main_h-overlay_h ";


            }


            string v_args = " -vcodec " + Tx_vcodec.Text + " -preset " + Tx_dst_preset.Text + " -pix_fmt " + Tx_dst_pixel_format.Text + " -crf " + Tx_crf.Text + " ";
            string fv_args = " -filter_complex \" " + v_filters + " \" ";
            string a_args = " -acodec " + Tx_acodec.Text;

            if (Tx_acodec.Text == "aac")
                a_args += " -strict -2 ";

            if (Tx_dst_v_bitrate.Text != "")
                a_args += " -b:v " + Tx_dst_v_bitrate.Text;

            if (Tx_dst_a_bitrate.Text != "")
                a_args += " -b:a " + Tx_dst_a_bitrate.Text;
            

            if (Tx_dst_fps.Text != "")
                v_args += " -r " + Tx_dst_fps.Text;
            if (Tx_src_start.Text != "")
                i_args = " -ss " + Tx_src_start.Text + " " + i_args;

            if (Tx_dst_length.Text != "")
                i_args = " -t " + Tx_dst_length.Text + " " + i_args;

            StringBuilder arguments = new StringBuilder();
            arguments.Append(st_args);
            arguments.Append(i_args);
            arguments.Append(v_args);
            arguments.Append(fv_args);
            arguments.Append(a_args);
            arguments.Append(o_args);
            return arguments.ToString();
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            string arguments = Get_Config_Parameters();

            Bt_start.Enabled = false;
            Bt_Stop.Enabled = true;

            UpdateStatus(WorkingState.Starting);
            worker.RunWorkerAsync(arguments);
        }

        private void Bt_Stop_Click(object sender, EventArgs e)
        {
            Worker_Stop();
        }

        private void Worker_Stop()
        {
            Bt_Stop.Enabled = false;
            if (worker_process != null)
                worker_process.Cancel();
        }


        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcessStartOptions options = new ProcessStartOptions(FFmpegDisplayMode.Interface);
            //FFmpegProcess process = new FFmpegProcess(start);
                        
            string arguments = e.Argument.ToString();

            worker_process = new FFmpegProcess(options);            

            worker_process.StatusUpdated += Worker_StatusUpdated;
            e.Result = worker_process.RunFFmpeg(arguments);

        }

        private void Worker_StatusUpdated(object sender, StatusUpdatedEventArgs e)
        {
            worker.ReportProgress(1, e.Status);            
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateStatus(WorkingState.Running, e.UserState);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StringReader reader = new StringReader(worker_process.Output);
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                if (line.IndexOf("Error") >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(line);
            UpdateStatus(WorkingState.Finished);

            CompletionStatus result = (CompletionStatus) e.Result;
            switch (result)
            {
                case CompletionStatus.Success:
                    UpdateStatus(WorkingState.Success);
                    break;
                case CompletionStatus.Error:
                    UpdateStatus(WorkingState.Error, line);
                    break;
                case CompletionStatus.Cancelled:
                    UpdateStatus(WorkingState.Cancelled);
                    break;
                case CompletionStatus.Timeout:
                    UpdateStatus(WorkingState.Timeout);
                    break;
                default:
                    break;
            }
        }


        private void UpdateStatusText(Color color, string text)
        {
            Lb_status.ForeColor = color;
            Lb_status.Text = text;
        }

        private void UpdateStatus(WorkingState state)
        {
            UpdateStatus(state, null);
        }
        private void UpdateStatus(WorkingState state, object data)
        {
            switch (state)
            {
                case WorkingState.Idle:
                    UpdateStatusText(Color.Black, "...");

                    WindowsTaskbar.ProgressState = TaskbarItemProgressState.None;
                    break;
                
                case WorkingState.Starting:
                    UpdateStatusText(Color.DarkOrange, "Starting...");
                    start_time = DateTime.Now;
                    WindowsTaskbar.ProgressState = TaskbarItemProgressState.Normal;
                    WindowsTaskbar.ProgressValue = 0;
                    break;

                case WorkingState.Running:
                    if (data is FFmpegStatus)
                    {
                        FFmpegStatus status = (FFmpegStatus)data;

                        try
                        {
                            Px_progress.Value = (int)status.Frame;
                            inteval_time = DateTime.Now - start_time;
                            Lb_status_time.Text = string.Format("{0:00}:{1:00}:{2:00}", inteval_time.Hours, inteval_time.Minutes, inteval_time.Seconds);
                            WindowsTaskbar.ProgressState = TaskbarItemProgressState.Normal;
                            WindowsTaskbar.ProgressValue = (double)Px_progress.Value / (double)Px_progress.Maximum;
                        }
                        catch { }
                    }
                    UpdateStatusText(Color.Black, "Running...");
                    break;

                case WorkingState.Finished:
                    Px_progress.Value = Px_progress.Maximum;
                    Bt_Stop.Enabled = false;
                    Bt_start.Enabled = true;
                    WindowsTaskbar.ProgressState = TaskbarItemProgressState.Normal;
                    WindowsTaskbar.ProgressValue = 1;

                    FlashWindow.Flash(this, 3);
                    break;

                case WorkingState.Success:
                    UpdateStatusText(Color.Green, "Finished");
                    break;

                case WorkingState.Timeout:
                    UpdateStatusText(Color.Red, "Timeout");
                    WindowsTaskbar.ProgressState = TaskbarItemProgressState.Error;
                    break;

                case WorkingState.Error:
                    if (data == null)
                        data = "";
                    UpdateStatusText(Color.Red, "Error: " + data.ToString());
                    WindowsTaskbar.ProgressState = TaskbarItemProgressState.Error;
                    break;

                case WorkingState.Cancelled:
                    UpdateStatusText(Color.DarkOrange, "Cancelled");
                    WindowsTaskbar.ProgressState = TaskbarItemProgressState.Paused;
                    break;

            }
        }



        private void Bt_open_src_Click(object sender, EventArgs e)
        {            
            ShellApi.ShellExecute(this.Handle, "Open", Tx_src_fname.Text, "", "", 1);
        }

        private void Bt_open_dst_Click(object sender, EventArgs e)
        {
            ShellApi.ShellExecute(this.Handle, "Open", Tx_dst_fname.Text, "", "", 1);
        }

        private void Bt_New_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
        }

        private void Pic_overlay_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.CheckFileExists = true;
                dialog.Filter = "Image Files (*.BMP;*.PNG;*.JPG;*.GIF)|*.BMP;*.PNG;*.JPG;*.GIF|All files (*.*)|*.*";
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    Overlay_fname = dialog.FileName;
                    Bitmap image = new Bitmap(Overlay_fname);
                    Pic_overlay.Image = image;
                }
            }

        }

        private void Bt_src_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.CheckFileExists = true;
                dialog.Filter = "All media files (*.*)|*.*";
                dialog.Multiselect = true;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    LoadFiles(dialog.FileNames);
                }
            }
        }

        private void Bt_dst_browse_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {                
                dialog.Filter = "All media files (*.*)|*.*";
                                
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    Tx_dst_fname.Text = dialog.FileName;
                }
            }
        }

        private void FormMainConvertor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker.IsBusy)
            {
                if (MessageBox.Show("Stop Convertor ?", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    Worker_Stop();
                }
                e.Cancel = true;
            }
        }

        private void Tx_src_fname_DoubleClick(object sender, EventArgs e)
        {
            Bt_src_browse_Click(sender, e);
        }

        private void Tx_dst_fname_DoubleClick(object sender, EventArgs e)
        {
            Bt_dst_browse_Click(sender, e);
        }
    }

    public enum WorkingState
    {
        Idle = 0,
        Starting,
        Running,
        Finished,
        Success,
        Timeout,
        Error,
        Cancelled
    }

    internal class FFmpegUserInterfaceManager : UserInterfaceManagerBase, IUserInterface
    {
        private FormMainConvertor FormMainConvertor;

        public FFmpegUserInterfaceManager(FormMainConvertor FormMainConvertor)
        {
            this.FormMainConvertor = FormMainConvertor;
        }

        public override IUserInterface CreateUI(string title, bool autoClose)
        {
            //throw new NotImplementedException();
            return this;
        }

        public override void DisplayError(FFmpegProcess host)
        {
            //throw new NotImplementedException();
        }

        public void DisplayTask(FFmpegProcess host)
        {
            
            //throw new NotImplementedException();
        }

        public void Stop()
        {
            //throw new NotImplementedException();
        }
    }
}
