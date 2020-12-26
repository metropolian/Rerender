using DmShared;
using DmShared.Graphic;
using DmShared.UI;
using EmergenceGuardian.FFmpeg;
using ShellLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Rerender
{
    public partial class FormMainConvertor : Form
    {
        public static string ConfigFileName = "rerender.cfg.json";

        private WorkingState CurrentState = WorkingState.Idle;
        private BackgroundWorker worker;
        private FFmpegProcess worker_process;
        private string Temp_Dir;
        
        private DateTime start_time;
        private TimeSpan inteval_time;
        private Taskbar WindowsTaskbar;
        private OperationType operation;

        public bool Is_Multiple_Files { get { return Tx_src_fname.Text.IndexOf(',') >= 0; } }
        public string Source_Filenames { get { return Tx_src_fname.Text; } }



        [PropertyData]
        public int Window_Left { get { return base.Left; } set { base.Left = value; } }

        [PropertyData]
        public int Window_Top { get { return base.Top; } set { base.Top = value; } }

        [PropertyData]
        public int Window_Width { get { return base.Width; } set { base.Width = value; } }

        [PropertyData]
        public int Window_Height { get { return base.Height; } set { base.Height = value; } }

        [PropertyData]
        public bool AlwaysOnTop { get { return base.TopMost; } set { base.TopMost = value; } }

        [PropertyData]
        public string V_codec { get { return Tx_vcodec.Text; } set { Tx_vcodec.Text = value; } }

        [PropertyData]
        public string V_bitrate { get { return Tx_dst_v_bitrate.Text; } set { Tx_dst_v_bitrate.Text = value; } }

        [PropertyData]
        public string V_preset { get { return Tx_dst_preset.Text; } set { Tx_dst_preset.Text = value; } }

        [PropertyData]
        public string V_dst_width { get { return Tx_dst_W.Text; } set { Tx_dst_W.Text = value; } }

        [PropertyData]
        public string V_dst_height { get { return Tx_dst_H.Text; } set { Tx_dst_H.Text = value; } }

        [PropertyData]
        public string V_dst_fps { get { return Tx_dst_fps.Text; } set { Tx_dst_fps.Text = value; } }

        [PropertyData]
        public string A_codec { get { return Tx_acodec.Text; } set { Tx_acodec.Text = value; } }

        [PropertyData]
        public string A_bitrate { get { return Tx_dst_a_bitrate.Text; } set { Tx_dst_a_bitrate.Text = value; } }

        [PropertyData]
        public bool Use_Filters { get { return Ch_filters.Checked; } set { Ch_filters.Checked = value; } }

        [PropertyData]
        public bool Use_Overlay { get { return Ch_overlay.Checked; } set { Ch_overlay.Checked = value; } }

        [PropertyData]
        public bool Use_Deshake { get { return Ch_deshake.Checked; } set { Ch_deshake.Checked = value; } }

        [PropertyData]
        public bool Use_H_flip { get { return Ch_hflip.Checked; } set { Ch_hflip.Checked = value; } }

        [PropertyData]
        public bool Use_V_flip { get { return Ch_vflip.Checked; } set { Ch_vflip.Checked = value; } }

        [PropertyData]
        public bool Use_BlurBG { get { return Ch_BlurBG.Checked; } set { Ch_BlurBG.Checked = value; } }

        [PropertyData]
        public bool Use_LockOutSize { get { return Ch_LockOutSize.Checked; } set { Ch_LockOutSize.Checked = value; } }

        [PropertyData]
        public bool Use_Hwaccel { get { return Ch_src_hwaccel.Checked; } set { Ch_src_hwaccel.Checked = value; } }

        [PropertyData]
        public bool Use_CustomFilters { get { return Ch_CustomFilters.Checked; } set { Ch_CustomFilters.Checked = value; } }

        [PropertyData]
        public string Custom_Filters { get { return Tx_filters.Text; } set { Tx_filters.Text = value; } }

        [PropertyData]
        public string Overlay_filename
        {
            get
            {
                return (string)Pic_overlay.Tag;
            }

            set
            {
                try
                {
                    if (Pic_overlay.Image != null)
                    {
                        Bitmap bitmap = (Bitmap)Pic_overlay.Image;
                        bitmap.Dispose();
                    }

                    Bitmap image = new Bitmap(value);
                    Pic_overlay.Image = image;
                    Pic_overlay.Tag = value;
                }
                catch {
                }
            }
        }


        public FormMainConvertor()
        {
            InitializeComponent();
        }

        private void FormMainConvertor_Load(object sender, EventArgs e)
        {
            Temp_Dir = Path.GetTempPath();

            FFmpegConfig.FFmpegPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\ffmpeg.exe";
            FFmpegConfig.UserInterfaceManager = new FFmpegUserInterfaceManager(this);
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            WindowsTaskbar = new Taskbar(this);

            AllowDrop = true;

            var renderer = new GdiRenderer();
            imageDesignPanel1.SetRenderer(renderer);
        }

        private void FormMainConvertor_Shown(object sender, EventArgs e)
        {
            ClassPropertyData.LoadFromFile(this, ConfigFileName);
        }

        private void FormMainConvertor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if ((e.KeyState & 8) == 8)
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.Link;
                }

            }




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
            //var data = MediaInfo.GetFileInfo(fname);

            var thumb_fname = Path.Combine(Temp_Dir, Path.GetFileNameWithoutExtension(Path.GetFileName(fname)) + ".png");
            
            var options = new ProcessStartOptions();
            var data = new FFmpegProcess(options);
            data.RunFFmpeg(string.Format(@"-y -i ""{0}"" -vframes 1 ""{1}"" ", fname, thumb_fname));

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


                FileStream fread = new FileStream(thumb_fname, FileMode.Open);
                imageDesignPanel1.Image = new Bitmap(fread);
                fread.Close();
                File.Delete(thumb_fname);
            }

            
        }

        public enum OperationType
        {
            Normal = 0,
            MergeAV = 1,
            Stream = 2
        }

        private string[] Get_Source_Filenames()
        {
            List<string> filenames = new List<string>();
            foreach (var item in Source_Filenames.Split(','))
            {
                string fname = item.Trim();
                if (fname != "")
                    filenames.Add(fname);
            }
            return filenames.ToArray();
        }

        private string Get_Config_Parameters()
        {
            
            string st_args = "-y ";
            string i_args = " -i \"" + Tx_src_fname.Text + "\" ";
            string o_args = " \"" + Tx_dst_fname.Text + "\" ";

            int op = Tx_operation.SelectedIndex;
            if (op < 0)
                op = 0;
            operation = (OperationType)op;

            if (Uri.IsWellFormedUriString(Tx_dst_fname.Text, UriKind.Absolute))
                operation = OperationType.Stream;

            if (operation == OperationType.MergeAV)
                Use_Filters = false;

            if (operation == OperationType.Stream)
                o_args = " -f flv \"" + Tx_dst_fname.Text + "\" ";


            Use_Hwaccel = Ch_src_hwaccel.Checked;
            if (Use_Hwaccel)
                i_args = " -hwaccel cuvid " + i_args;

            
            // Multiple Files Mode
            if (Is_Multiple_Files && operation == OperationType.Normal)
            {
                FileInfo finfo = new FileInfo("filelist.txt");
                StreamWriter f = new StreamWriter(finfo.FullName, false);
                foreach (var item in Tx_src_fname.Text.Split(','))
                {
                    string fname = item.Trim();
                    if (fname != "")
                        f.WriteLine("file '" + fname + "'");
                }
                f.Close();
                
                i_args = " -f concat -safe 0 -i \"" + finfo.FullName + "\" ";
            }

            if (operation == OperationType.MergeAV)
            {
                List<string> filenames = new List<string>();
                i_args = " ";
                foreach (var item in Tx_src_fname.Text.Split(','))
                {
                    string fname = item.Trim();
                    if (fname != "")
                        i_args += " -i \"" + fname + "\" ";
                }

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
            {
                v_filters += Tx_filters.Text;
                //if (v_filters.LastIndexOf("]") < 0)
                    v_filters += ",";
            }

            v_filters += flip;

            if (Ch_BlurBG.Checked)
            {
                v_filters += @"split[original][copy];[copy]scale=ih*16/9:-1,crop=h=iw*9/16,boxblur=luma_radius=min(w\,h)/5:chroma_radius=min(cw\,ch)/5:luma_power=1[blurred];[blurred][original]overlay=(main_w-overlay_w)/2:(main_h-overlay_h)/2";
                v_filters += ",";
            }

            v_filters += 
                "scale=" + Tx_dst_W.Text + ":" + Tx_dst_H.Text + ":force_original_aspect_ratio=decrease , " +
                "pad=" + Tx_dst_W.Text + ":" + Tx_dst_H.Text + ":(ow-iw)/2:(oh-ih)/2 ";

            if (Use_Overlay)
            {
                i_args += " -i \"" + Overlay_filename + "\" ";

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
            string fv_args = " -filter_complex \"[0:v] " + v_filters + " [v] \" -map [v] -map 0:a ";
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


            if (operation == OperationType.MergeAV)
                a_args += " -map 0:v:0 -map 1:a:0 ";


            StringBuilder arguments = new StringBuilder();
            arguments.Append(st_args);
            arguments.Append(i_args);

            if (Tx_vcodec.Text != "")
                arguments.Append(v_args);
            if (Use_Filters)
                arguments.Append(fv_args);
            if (Tx_acodec.Text != "")
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
            StringBuilder errors = new StringBuilder();
            bool error_found = false;
            string line = "";
            string last_line = "";
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                if (line.IndexOf("Error") >= 0)
                {
                    errors.AppendLine(line);
                    error_found = true;
                }
                last_line = line;
            }
            errors.AppendLine(last_line);

            UpdateStatus(WorkingState.Finished);

            CompletionStatus result = (CompletionStatus) e.Result;
            switch (result)
            {
                case CompletionStatus.Success:
                    UpdateStatus(WorkingState.Success);
                    break;
                case CompletionStatus.Error:
                    Console.WriteLine("Parameters: " + worker_process.CommandWithArgs);
                    UpdateStatus(WorkingState.Error, errors.ToString());
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

                    WindowsTaskbar.Reset();
                    break;
                
                case WorkingState.Starting:
                    UpdateStatusText(Color.DarkOrange, "Starting...");
                    start_time = DateTime.Now;
                    WindowsTaskbar.ProgressBegin();
                    WindowsTaskbar.ProgressUpdate(0);
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
                            WindowsTaskbar.ProgressUpdate((double)Px_progress.Value / (double)Px_progress.Maximum);
                        }
                        catch { }
                    }
                    UpdateStatusText(Color.Black, "Running...");
                    break;

                case WorkingState.Finished:
                    Px_progress.Value = Px_progress.Maximum;
                    Bt_Stop.Enabled = false;
                    Bt_start.Enabled = true;
                    WindowsTaskbar.ProgressEnd();

                    FlashWindow.Flash(this, 3);
                    break;

                case WorkingState.Success:
                    UpdateStatusText(Color.Green, "Finished");
                    break;

                case WorkingState.Timeout:
                    UpdateStatusText(Color.Red, "Timeout");
                    WindowsTaskbar.ProgressError();
                    break;

                case WorkingState.Error:
                    if (data == null)
                        data = "";
                    UpdateStatusText(Color.Red, "Error: " + data.ToString());

                    WindowsTaskbar.ProgressError();
                    break;

                case WorkingState.Cancelled:
                    UpdateStatusText(Color.DarkOrange, "Cancelled");
                    WindowsTaskbar.ProgressPause();
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
                    Overlay_filename = dialog.FileName;
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

            if (!e.Cancel)
            {
                ClassPropertyData.SaveToFile(this, ConfigFileName);
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

        private void Bt_select_crop_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Tx_src_W_TextChanged(object sender, EventArgs e)
        {
            if (Tx_src_W.Text != "" && Tx_dst_W.Text == "")
                Tx_dst_W.Text = Tx_src_W.Text;
        }

        private void Tx_src_H_TextChanged(object sender, EventArgs e)
        {
            if (Tx_src_H.Text != "" && Tx_dst_H.Text == "")
                Tx_dst_H.Text = Tx_dst_H.Text;

        }

        private void Tx_fname_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox Tx = ((TextBox)sender);
            if (Tx.Text != "")
            {
                Tx.SelectAll();
                Tx.Copy();
            }
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
