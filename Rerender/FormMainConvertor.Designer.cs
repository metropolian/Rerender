namespace Rerender
{
    partial class FormMainConvertor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainConvertor));
            this.label1 = new System.Windows.Forms.Label();
            this.Tx_src_fname = new System.Windows.Forms.TextBox();
            this.Tx_src_W = new System.Windows.Forms.TextBox();
            this.Tx_src_H = new System.Windows.Forms.TextBox();
            this.Tx_dst_W = new System.Windows.Forms.TextBox();
            this.Tx_dst_H = new System.Windows.Forms.TextBox();
            this.Bt_start = new System.Windows.Forms.Button();
            this.Tx_dst_fname = new System.Windows.Forms.TextBox();
            this.Tx_dst_preset = new System.Windows.Forms.ComboBox();
            this.Tx_dst_pixel_format = new System.Windows.Forms.ComboBox();
            this.Px_progress = new System.Windows.Forms.ProgressBar();
            this.Tx_crf = new System.Windows.Forms.ComboBox();
            this.Tx_vcodec = new System.Windows.Forms.ComboBox();
            this.Tx_src_pixel_format = new System.Windows.Forms.TextBox();
            this.Tx_src_length = new System.Windows.Forms.TextBox();
            this.Tx_src_time = new System.Windows.Forms.TextBox();
            this.Ch_vflip = new System.Windows.Forms.CheckBox();
            this.Ch_hflip = new System.Windows.Forms.CheckBox();
            this.Bt_open_dst = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Bt_open_src = new System.Windows.Forms.Button();
            this.Bt_Stop = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Tx_dst_length = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Bt_New = new System.Windows.Forms.Button();
            this.Tx_filters = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Tx_src_start = new System.Windows.Forms.TextBox();
            this.Pic_overlay = new System.Windows.Forms.PictureBox();
            this.Ch_overlay = new System.Windows.Forms.CheckBox();
            this.Lb_status = new System.Windows.Forms.Label();
            this.Ch_overlay_LT = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Ch_overlay_CB = new System.Windows.Forms.RadioButton();
            this.Ch_overlay_LC = new System.Windows.Forms.RadioButton();
            this.Ch_overlay_RC = new System.Windows.Forms.RadioButton();
            this.Ch_overlay_CT = new System.Windows.Forms.RadioButton();
            this.Ch_overlay_CC = new System.Windows.Forms.RadioButton();
            this.Ch_overlay_LB = new System.Windows.Forms.RadioButton();
            this.Ch_overlay_RB = new System.Windows.Forms.RadioButton();
            this.Ch_overlay_RT = new System.Windows.Forms.RadioButton();
            this.Lb_status_time = new System.Windows.Forms.Label();
            this.Tx_dst_fps = new System.Windows.Forms.ComboBox();
            this.Ch_deshake = new System.Windows.Forms.CheckBox();
            this.Bt_dst_browse = new System.Windows.Forms.Button();
            this.Bt_src_browse = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.Tx_acodec = new System.Windows.Forms.ComboBox();
            this.Tx_dst_a_bitrate = new System.Windows.Forms.ComboBox();
            this.Tx_dst_v_bitrate = new System.Windows.Forms.ComboBox();
            this.Ch_src_hwaccel = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_overlay)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source:";
            // 
            // Tx_src_fname
            // 
            this.Tx_src_fname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_src_fname.Location = new System.Drawing.Point(159, 41);
            this.Tx_src_fname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_src_fname.Name = "Tx_src_fname";
            this.Tx_src_fname.Size = new System.Drawing.Size(907, 45);
            this.Tx_src_fname.TabIndex = 1;
            this.Tx_src_fname.DoubleClick += new System.EventHandler(this.Tx_src_fname_DoubleClick);
            // 
            // Tx_src_W
            // 
            this.Tx_src_W.Enabled = false;
            this.Tx_src_W.Location = new System.Drawing.Point(232, 115);
            this.Tx_src_W.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_src_W.Name = "Tx_src_W";
            this.Tx_src_W.Size = new System.Drawing.Size(135, 45);
            this.Tx_src_W.TabIndex = 2;
            // 
            // Tx_src_H
            // 
            this.Tx_src_H.Enabled = false;
            this.Tx_src_H.Location = new System.Drawing.Point(377, 115);
            this.Tx_src_H.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_src_H.Name = "Tx_src_H";
            this.Tx_src_H.Size = new System.Drawing.Size(135, 45);
            this.Tx_src_H.TabIndex = 2;
            // 
            // Tx_dst_W
            // 
            this.Tx_dst_W.Location = new System.Drawing.Point(230, 346);
            this.Tx_dst_W.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_dst_W.Name = "Tx_dst_W";
            this.Tx_dst_W.Size = new System.Drawing.Size(135, 45);
            this.Tx_dst_W.TabIndex = 2;
            this.Tx_dst_W.Text = "1920";
            // 
            // Tx_dst_H
            // 
            this.Tx_dst_H.Location = new System.Drawing.Point(381, 343);
            this.Tx_dst_H.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_dst_H.Name = "Tx_dst_H";
            this.Tx_dst_H.Size = new System.Drawing.Size(135, 45);
            this.Tx_dst_H.TabIndex = 2;
            this.Tx_dst_H.Text = "1080";
            // 
            // Bt_start
            // 
            this.Bt_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_start.Enabled = false;
            this.Bt_start.Location = new System.Drawing.Point(865, 1074);
            this.Bt_start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Bt_start.Name = "Bt_start";
            this.Bt_start.Size = new System.Drawing.Size(220, 71);
            this.Bt_start.TabIndex = 3;
            this.Bt_start.Text = "Start";
            this.Bt_start.UseVisualStyleBackColor = true;
            this.Bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // Tx_dst_fname
            // 
            this.Tx_dst_fname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_dst_fname.Location = new System.Drawing.Point(168, 276);
            this.Tx_dst_fname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_dst_fname.Name = "Tx_dst_fname";
            this.Tx_dst_fname.Size = new System.Drawing.Size(902, 45);
            this.Tx_dst_fname.TabIndex = 1;
            this.Tx_dst_fname.DoubleClick += new System.EventHandler(this.Tx_dst_fname_DoubleClick);
            // 
            // Tx_dst_preset
            // 
            this.Tx_dst_preset.FormattingEnabled = true;
            this.Tx_dst_preset.Items.AddRange(new object[] {
            "ultrafast",
            "superfast",
            "veryfast",
            "faster",
            "fast",
            "medium",
            "slow",
            "slower",
            "veryslow",
            "placebo"});
            this.Tx_dst_preset.Location = new System.Drawing.Point(538, 417);
            this.Tx_dst_preset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_dst_preset.Name = "Tx_dst_preset";
            this.Tx_dst_preset.Size = new System.Drawing.Size(135, 46);
            this.Tx_dst_preset.TabIndex = 4;
            this.Tx_dst_preset.Text = "fast";
            // 
            // Tx_dst_pixel_format
            // 
            this.Tx_dst_pixel_format.FormattingEnabled = true;
            this.Tx_dst_pixel_format.Items.AddRange(new object[] {
            "yuv420p",
            "yuvj420p",
            "yuv422p",
            "yuvj422p",
            "yuv444p",
            "yuvj444p",
            "nv12",
            "nv16",
            "nv21"});
            this.Tx_dst_pixel_format.Location = new System.Drawing.Point(533, 343);
            this.Tx_dst_pixel_format.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_dst_pixel_format.Name = "Tx_dst_pixel_format";
            this.Tx_dst_pixel_format.Size = new System.Drawing.Size(164, 46);
            this.Tx_dst_pixel_format.TabIndex = 5;
            this.Tx_dst_pixel_format.Text = "yuv420p";
            // 
            // Px_progress
            // 
            this.Px_progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Px_progress.Location = new System.Drawing.Point(41, 979);
            this.Px_progress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Px_progress.Name = "Px_progress";
            this.Px_progress.Size = new System.Drawing.Size(1231, 70);
            this.Px_progress.TabIndex = 6;
            // 
            // Tx_crf
            // 
            this.Tx_crf.FormattingEnabled = true;
            this.Tx_crf.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "50"});
            this.Tx_crf.Location = new System.Drawing.Point(690, 417);
            this.Tx_crf.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_crf.Name = "Tx_crf";
            this.Tx_crf.Size = new System.Drawing.Size(164, 46);
            this.Tx_crf.TabIndex = 7;
            this.Tx_crf.Text = "20";
            // 
            // Tx_vcodec
            // 
            this.Tx_vcodec.FormattingEnabled = true;
            this.Tx_vcodec.Items.AddRange(new object[] {
            "libx264",
            "h264_nvenc",
            "libx265",
            "hevc_nvenc"});
            this.Tx_vcodec.Location = new System.Drawing.Point(169, 417);
            this.Tx_vcodec.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_vcodec.Name = "Tx_vcodec";
            this.Tx_vcodec.Size = new System.Drawing.Size(202, 46);
            this.Tx_vcodec.TabIndex = 8;
            this.Tx_vcodec.Text = "libx264";
            // 
            // Tx_src_pixel_format
            // 
            this.Tx_src_pixel_format.Enabled = false;
            this.Tx_src_pixel_format.Location = new System.Drawing.Point(529, 115);
            this.Tx_src_pixel_format.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_src_pixel_format.Name = "Tx_src_pixel_format";
            this.Tx_src_pixel_format.Size = new System.Drawing.Size(135, 45);
            this.Tx_src_pixel_format.TabIndex = 2;
            // 
            // Tx_src_length
            // 
            this.Tx_src_length.Enabled = false;
            this.Tx_src_length.Location = new System.Drawing.Point(787, 115);
            this.Tx_src_length.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_src_length.Name = "Tx_src_length";
            this.Tx_src_length.Size = new System.Drawing.Size(168, 45);
            this.Tx_src_length.TabIndex = 2;
            // 
            // Tx_src_time
            // 
            this.Tx_src_time.Location = new System.Drawing.Point(1074, 115);
            this.Tx_src_time.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_src_time.Name = "Tx_src_time";
            this.Tx_src_time.Size = new System.Drawing.Size(200, 45);
            this.Tx_src_time.TabIndex = 2;
            // 
            // Ch_vflip
            // 
            this.Ch_vflip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ch_vflip.AutoSize = true;
            this.Ch_vflip.Location = new System.Drawing.Point(571, 637);
            this.Ch_vflip.Name = "Ch_vflip";
            this.Ch_vflip.Size = new System.Drawing.Size(142, 42);
            this.Ch_vflip.TabIndex = 9;
            this.Ch_vflip.Text = "Vert-flip";
            this.Ch_vflip.UseVisualStyleBackColor = true;
            // 
            // Ch_hflip
            // 
            this.Ch_hflip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ch_hflip.AutoSize = true;
            this.Ch_hflip.Location = new System.Drawing.Point(571, 584);
            this.Ch_hflip.Name = "Ch_hflip";
            this.Ch_hflip.Size = new System.Drawing.Size(152, 42);
            this.Ch_hflip.TabIndex = 10;
            this.Ch_hflip.Text = "Horz-flip";
            this.Ch_hflip.UseVisualStyleBackColor = true;
            // 
            // Bt_open_dst
            // 
            this.Bt_open_dst.Location = new System.Drawing.Point(1184, 276);
            this.Bt_open_dst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Bt_open_dst.Name = "Bt_open_dst";
            this.Bt_open_dst.Size = new System.Drawing.Size(94, 45);
            this.Bt_open_dst.TabIndex = 3;
            this.Bt_open_dst.Text = "Open";
            this.Bt_open_dst.UseVisualStyleBackColor = true;
            this.Bt_open_dst.Click += new System.EventHandler(this.Bt_open_dst_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "Source Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(963, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 38);
            this.label3.TabIndex = 0;
            this.label3.Text = "Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(679, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 38);
            this.label4.TabIndex = 0;
            this.label4.Text = "Frame:";
            // 
            // Bt_open_src
            // 
            this.Bt_open_src.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_open_src.Location = new System.Drawing.Point(1180, 41);
            this.Bt_open_src.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Bt_open_src.Name = "Bt_open_src";
            this.Bt_open_src.Size = new System.Drawing.Size(94, 45);
            this.Bt_open_src.TabIndex = 3;
            this.Bt_open_src.Text = "Open";
            this.Bt_open_src.UseVisualStyleBackColor = true;
            this.Bt_open_src.Click += new System.EventHandler(this.Bt_open_src_Click);
            // 
            // Bt_Stop
            // 
            this.Bt_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_Stop.Enabled = false;
            this.Bt_Stop.Location = new System.Drawing.Point(1102, 1074);
            this.Bt_Stop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Bt_Stop.Name = "Bt_Stop";
            this.Bt_Stop.Size = new System.Drawing.Size(170, 71);
            this.Bt_Stop.TabIndex = 3;
            this.Bt_Stop.Text = "Stop";
            this.Bt_Stop.UseVisualStyleBackColor = true;
            this.Bt_Stop.Click += new System.EventHandler(this.Bt_Stop_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 349);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 38);
            this.label5.TabIndex = 0;
            this.label5.Text = "Output Size:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(962, 417);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 38);
            this.label6.TabIndex = 0;
            this.label6.Text = "Length:";
            // 
            // Tx_dst_length
            // 
            this.Tx_dst_length.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_dst_length.Location = new System.Drawing.Point(1078, 417);
            this.Tx_dst_length.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_dst_length.Name = "Tx_dst_length";
            this.Tx_dst_length.Size = new System.Drawing.Size(200, 45);
            this.Tx_dst_length.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 420);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 38);
            this.label7.TabIndex = 0;
            this.label7.Text = "Video:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 279);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 38);
            this.label8.TabIndex = 0;
            this.label8.Text = "Output:";
            // 
            // Bt_New
            // 
            this.Bt_New.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Bt_New.Location = new System.Drawing.Point(41, 1074);
            this.Bt_New.Name = "Bt_New";
            this.Bt_New.Size = new System.Drawing.Size(178, 71);
            this.Bt_New.TabIndex = 11;
            this.Bt_New.Text = "New Inst.";
            this.Bt_New.UseVisualStyleBackColor = true;
            this.Bt_New.Click += new System.EventHandler(this.Bt_New_Click);
            // 
            // Tx_filters
            // 
            this.Tx_filters.Location = new System.Drawing.Point(39, 827);
            this.Tx_filters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_filters.Name = "Tx_filters";
            this.Tx_filters.Size = new System.Drawing.Size(1235, 45);
            this.Tx_filters.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(962, 349);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 38);
            this.label9.TabIndex = 0;
            this.label9.Text = "Start:";
            // 
            // Tx_src_start
            // 
            this.Tx_src_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_src_start.Location = new System.Drawing.Point(1078, 346);
            this.Tx_src_start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_src_start.Name = "Tx_src_start";
            this.Tx_src_start.Size = new System.Drawing.Size(200, 45);
            this.Tx_src_start.TabIndex = 2;
            // 
            // Pic_overlay
            // 
            this.Pic_overlay.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Pic_overlay.Location = new System.Drawing.Point(233, 584);
            this.Pic_overlay.Name = "Pic_overlay";
            this.Pic_overlay.Size = new System.Drawing.Size(151, 151);
            this.Pic_overlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pic_overlay.TabIndex = 12;
            this.Pic_overlay.TabStop = false;
            this.Pic_overlay.Click += new System.EventHandler(this.Pic_overlay_Click);
            // 
            // Ch_overlay
            // 
            this.Ch_overlay.AutoSize = true;
            this.Ch_overlay.Location = new System.Drawing.Point(48, 634);
            this.Ch_overlay.Name = "Ch_overlay";
            this.Ch_overlay.Size = new System.Drawing.Size(137, 42);
            this.Ch_overlay.TabIndex = 13;
            this.Ch_overlay.Text = "Overlay";
            this.Ch_overlay.UseVisualStyleBackColor = true;
            // 
            // Lb_status
            // 
            this.Lb_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lb_status.AutoSize = true;
            this.Lb_status.ForeColor = System.Drawing.Color.SeaGreen;
            this.Lb_status.Location = new System.Drawing.Point(34, 913);
            this.Lb_status.Name = "Lb_status";
            this.Lb_status.Size = new System.Drawing.Size(92, 38);
            this.Lb_status.TabIndex = 15;
            this.Lb_status.Text = "Ready";
            // 
            // Ch_overlay_LT
            // 
            this.Ch_overlay_LT.AutoSize = true;
            this.Ch_overlay_LT.Checked = true;
            this.Ch_overlay_LT.Location = new System.Drawing.Point(12, 13);
            this.Ch_overlay_LT.Name = "Ch_overlay_LT";
            this.Ch_overlay_LT.Size = new System.Drawing.Size(21, 20);
            this.Ch_overlay_LT.TabIndex = 16;
            this.Ch_overlay_LT.TabStop = true;
            this.Ch_overlay_LT.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Ch_overlay_CB);
            this.panel1.Controls.Add(this.Ch_overlay_LC);
            this.panel1.Controls.Add(this.Ch_overlay_RC);
            this.panel1.Controls.Add(this.Ch_overlay_CT);
            this.panel1.Controls.Add(this.Ch_overlay_CC);
            this.panel1.Controls.Add(this.Ch_overlay_LB);
            this.panel1.Controls.Add(this.Ch_overlay_RB);
            this.panel1.Controls.Add(this.Ch_overlay_RT);
            this.panel1.Controls.Add(this.Ch_overlay_LT);
            this.panel1.Location = new System.Drawing.Point(405, 584);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 151);
            this.panel1.TabIndex = 17;
            // 
            // Ch_overlay_CB
            // 
            this.Ch_overlay_CB.AutoSize = true;
            this.Ch_overlay_CB.Location = new System.Drawing.Point(60, 118);
            this.Ch_overlay_CB.Name = "Ch_overlay_CB";
            this.Ch_overlay_CB.Size = new System.Drawing.Size(21, 20);
            this.Ch_overlay_CB.TabIndex = 16;
            this.Ch_overlay_CB.UseVisualStyleBackColor = true;
            // 
            // Ch_overlay_LC
            // 
            this.Ch_overlay_LC.AutoSize = true;
            this.Ch_overlay_LC.Location = new System.Drawing.Point(12, 63);
            this.Ch_overlay_LC.Name = "Ch_overlay_LC";
            this.Ch_overlay_LC.Size = new System.Drawing.Size(21, 20);
            this.Ch_overlay_LC.TabIndex = 16;
            this.Ch_overlay_LC.UseVisualStyleBackColor = true;
            // 
            // Ch_overlay_RC
            // 
            this.Ch_overlay_RC.AutoSize = true;
            this.Ch_overlay_RC.Location = new System.Drawing.Point(111, 63);
            this.Ch_overlay_RC.Name = "Ch_overlay_RC";
            this.Ch_overlay_RC.Size = new System.Drawing.Size(21, 20);
            this.Ch_overlay_RC.TabIndex = 16;
            this.Ch_overlay_RC.UseVisualStyleBackColor = true;
            // 
            // Ch_overlay_CT
            // 
            this.Ch_overlay_CT.AutoSize = true;
            this.Ch_overlay_CT.Location = new System.Drawing.Point(60, 13);
            this.Ch_overlay_CT.Name = "Ch_overlay_CT";
            this.Ch_overlay_CT.Size = new System.Drawing.Size(21, 20);
            this.Ch_overlay_CT.TabIndex = 16;
            this.Ch_overlay_CT.UseVisualStyleBackColor = true;
            // 
            // Ch_overlay_CC
            // 
            this.Ch_overlay_CC.AutoSize = true;
            this.Ch_overlay_CC.Location = new System.Drawing.Point(60, 63);
            this.Ch_overlay_CC.Name = "Ch_overlay_CC";
            this.Ch_overlay_CC.Size = new System.Drawing.Size(21, 20);
            this.Ch_overlay_CC.TabIndex = 16;
            this.Ch_overlay_CC.UseVisualStyleBackColor = true;
            // 
            // Ch_overlay_LB
            // 
            this.Ch_overlay_LB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Ch_overlay_LB.AutoSize = true;
            this.Ch_overlay_LB.Location = new System.Drawing.Point(12, 118);
            this.Ch_overlay_LB.Name = "Ch_overlay_LB";
            this.Ch_overlay_LB.Size = new System.Drawing.Size(21, 20);
            this.Ch_overlay_LB.TabIndex = 16;
            this.Ch_overlay_LB.UseVisualStyleBackColor = true;
            // 
            // Ch_overlay_RB
            // 
            this.Ch_overlay_RB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ch_overlay_RB.AutoSize = true;
            this.Ch_overlay_RB.Location = new System.Drawing.Point(111, 118);
            this.Ch_overlay_RB.Name = "Ch_overlay_RB";
            this.Ch_overlay_RB.Size = new System.Drawing.Size(21, 20);
            this.Ch_overlay_RB.TabIndex = 16;
            this.Ch_overlay_RB.UseVisualStyleBackColor = true;
            // 
            // Ch_overlay_RT
            // 
            this.Ch_overlay_RT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ch_overlay_RT.AutoSize = true;
            this.Ch_overlay_RT.Location = new System.Drawing.Point(111, 13);
            this.Ch_overlay_RT.Name = "Ch_overlay_RT";
            this.Ch_overlay_RT.Size = new System.Drawing.Size(21, 20);
            this.Ch_overlay_RT.TabIndex = 16;
            this.Ch_overlay_RT.UseVisualStyleBackColor = true;
            // 
            // Lb_status_time
            // 
            this.Lb_status_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lb_status_time.AutoSize = true;
            this.Lb_status_time.ForeColor = System.Drawing.Color.SeaGreen;
            this.Lb_status_time.Location = new System.Drawing.Point(240, 1090);
            this.Lb_status_time.Name = "Lb_status_time";
            this.Lb_status_time.Size = new System.Drawing.Size(35, 38);
            this.Lb_status_time.TabIndex = 15;
            this.Lb_status_time.Text = "...";
            this.Lb_status_time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Tx_dst_fps
            // 
            this.Tx_dst_fps.FormattingEnabled = true;
            this.Tx_dst_fps.Items.AddRange(new object[] {
            "29",
            "30",
            "60",
            "120"});
            this.Tx_dst_fps.Location = new System.Drawing.Point(741, 346);
            this.Tx_dst_fps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_dst_fps.Name = "Tx_dst_fps";
            this.Tx_dst_fps.Size = new System.Drawing.Size(164, 46);
            this.Tx_dst_fps.TabIndex = 7;
            // 
            // Ch_deshake
            // 
            this.Ch_deshake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ch_deshake.AutoSize = true;
            this.Ch_deshake.Location = new System.Drawing.Point(571, 693);
            this.Ch_deshake.Name = "Ch_deshake";
            this.Ch_deshake.Size = new System.Drawing.Size(149, 42);
            this.Ch_deshake.TabIndex = 9;
            this.Ch_deshake.Text = "Deshake";
            this.Ch_deshake.UseVisualStyleBackColor = true;
            // 
            // Bt_dst_browse
            // 
            this.Bt_dst_browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_dst_browse.Location = new System.Drawing.Point(1082, 276);
            this.Bt_dst_browse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Bt_dst_browse.Name = "Bt_dst_browse";
            this.Bt_dst_browse.Size = new System.Drawing.Size(94, 45);
            this.Bt_dst_browse.TabIndex = 3;
            this.Bt_dst_browse.Text = "Browse";
            this.Bt_dst_browse.UseVisualStyleBackColor = true;
            this.Bt_dst_browse.Click += new System.EventHandler(this.Bt_dst_browse_Click);
            // 
            // Bt_src_browse
            // 
            this.Bt_src_browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_src_browse.Location = new System.Drawing.Point(1078, 38);
            this.Bt_src_browse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Bt_src_browse.Name = "Bt_src_browse";
            this.Bt_src_browse.Size = new System.Drawing.Size(94, 45);
            this.Bt_src_browse.TabIndex = 3;
            this.Bt_src_browse.Text = "Browse";
            this.Bt_src_browse.UseVisualStyleBackColor = true;
            this.Bt_src_browse.Click += new System.EventHandler(this.Bt_src_browse_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 485);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 38);
            this.label10.TabIndex = 0;
            this.label10.Text = "Audio:";
            // 
            // Tx_acodec
            // 
            this.Tx_acodec.FormattingEnabled = true;
            this.Tx_acodec.Items.AddRange(new object[] {
            "aac",
            "mp3"});
            this.Tx_acodec.Location = new System.Drawing.Point(169, 482);
            this.Tx_acodec.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_acodec.Name = "Tx_acodec";
            this.Tx_acodec.Size = new System.Drawing.Size(202, 46);
            this.Tx_acodec.TabIndex = 8;
            this.Tx_acodec.Text = "aac";
            // 
            // Tx_dst_a_bitrate
            // 
            this.Tx_dst_a_bitrate.FormattingEnabled = true;
            this.Tx_dst_a_bitrate.Items.AddRange(new object[] {
            "32k",
            "64k",
            "96k",
            "128k",
            "160k",
            "192k",
            "256k",
            "384k",
            "512k"});
            this.Tx_dst_a_bitrate.Location = new System.Drawing.Point(381, 482);
            this.Tx_dst_a_bitrate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_dst_a_bitrate.Name = "Tx_dst_a_bitrate";
            this.Tx_dst_a_bitrate.Size = new System.Drawing.Size(135, 46);
            this.Tx_dst_a_bitrate.TabIndex = 7;
            this.Tx_dst_a_bitrate.Text = "128k";
            // 
            // Tx_dst_v_bitrate
            // 
            this.Tx_dst_v_bitrate.FormattingEnabled = true;
            this.Tx_dst_v_bitrate.Items.AddRange(new object[] {
            "128k",
            "256k",
            "512k",
            "864k",
            "1M",
            "2M",
            "4M",
            "8M",
            "12M",
            "20M",
            "30M",
            "50M"});
            this.Tx_dst_v_bitrate.Location = new System.Drawing.Point(381, 417);
            this.Tx_dst_v_bitrate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tx_dst_v_bitrate.Name = "Tx_dst_v_bitrate";
            this.Tx_dst_v_bitrate.Size = new System.Drawing.Size(135, 46);
            this.Tx_dst_v_bitrate.TabIndex = 7;
            // 
            // Ch_src_hwaccel
            // 
            this.Ch_src_hwaccel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ch_src_hwaccel.AutoSize = true;
            this.Ch_src_hwaccel.Location = new System.Drawing.Point(1089, 584);
            this.Ch_src_hwaccel.Name = "Ch_src_hwaccel";
            this.Ch_src_hwaccel.Size = new System.Drawing.Size(145, 42);
            this.Ch_src_hwaccel.TabIndex = 10;
            this.Ch_src_hwaccel.Text = "Hwaccel";
            this.Ch_src_hwaccel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ch_src_hwaccel.UseVisualStyleBackColor = true;
            // 
            // FormMainConvertor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1305, 1179);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Lb_status_time);
            this.Controls.Add(this.Lb_status);
            this.Controls.Add(this.Ch_overlay);
            this.Controls.Add(this.Pic_overlay);
            this.Controls.Add(this.Bt_New);
            this.Controls.Add(this.Ch_src_hwaccel);
            this.Controls.Add(this.Ch_hflip);
            this.Controls.Add(this.Ch_deshake);
            this.Controls.Add(this.Ch_vflip);
            this.Controls.Add(this.Tx_acodec);
            this.Controls.Add(this.Tx_vcodec);
            this.Controls.Add(this.Tx_dst_fps);
            this.Controls.Add(this.Tx_dst_v_bitrate);
            this.Controls.Add(this.Tx_dst_a_bitrate);
            this.Controls.Add(this.Tx_crf);
            this.Controls.Add(this.Px_progress);
            this.Controls.Add(this.Tx_dst_pixel_format);
            this.Controls.Add(this.Tx_dst_preset);
            this.Controls.Add(this.Bt_open_src);
            this.Controls.Add(this.Bt_src_browse);
            this.Controls.Add(this.Bt_dst_browse);
            this.Controls.Add(this.Bt_open_dst);
            this.Controls.Add(this.Bt_Stop);
            this.Controls.Add(this.Bt_start);
            this.Controls.Add(this.Tx_dst_H);
            this.Controls.Add(this.Tx_dst_W);
            this.Controls.Add(this.Tx_src_start);
            this.Controls.Add(this.Tx_dst_length);
            this.Controls.Add(this.Tx_src_time);
            this.Controls.Add(this.Tx_src_length);
            this.Controls.Add(this.Tx_src_pixel_format);
            this.Controls.Add(this.Tx_src_H);
            this.Controls.Add(this.Tx_src_W);
            this.Controls.Add(this.Tx_filters);
            this.Controls.Add(this.Tx_dst_fname);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Tx_src_fname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1000, 1000);
            this.Name = "FormMainConvertor";
            this.Text = "Rerender EZ Convertor by Frozenology ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainConvertor_FormClosing);
            this.Load += new System.EventHandler(this.FormMainConvertor_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMainConvertor_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMainConvertor_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_overlay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tx_src_fname;
        private System.Windows.Forms.TextBox Tx_src_W;
        private System.Windows.Forms.TextBox Tx_src_H;
        private System.Windows.Forms.TextBox Tx_dst_W;
        private System.Windows.Forms.TextBox Tx_dst_H;
        private System.Windows.Forms.Button Bt_start;
        private System.Windows.Forms.TextBox Tx_dst_fname;
        private System.Windows.Forms.ComboBox Tx_dst_preset;
        private System.Windows.Forms.ComboBox Tx_dst_pixel_format;
        private System.Windows.Forms.ProgressBar Px_progress;
        private System.Windows.Forms.ComboBox Tx_crf;
        private System.Windows.Forms.ComboBox Tx_vcodec;
        private System.Windows.Forms.TextBox Tx_src_pixel_format;
        private System.Windows.Forms.TextBox Tx_src_length;
        private System.Windows.Forms.TextBox Tx_src_time;
        private System.Windows.Forms.CheckBox Ch_vflip;
        private System.Windows.Forms.CheckBox Ch_hflip;
        private System.Windows.Forms.Button Bt_open_dst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Bt_open_src;
        private System.Windows.Forms.Button Bt_Stop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Tx_dst_length;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Bt_New;
        private System.Windows.Forms.TextBox Tx_filters;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Tx_src_start;
        private System.Windows.Forms.PictureBox Pic_overlay;
        private System.Windows.Forms.CheckBox Ch_overlay;
        private System.Windows.Forms.Label Lb_status;
        private System.Windows.Forms.RadioButton Ch_overlay_LT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton Ch_overlay_CC;
        private System.Windows.Forms.RadioButton Ch_overlay_LB;
        private System.Windows.Forms.RadioButton Ch_overlay_RB;
        private System.Windows.Forms.RadioButton Ch_overlay_RT;
        private System.Windows.Forms.RadioButton Ch_overlay_CB;
        private System.Windows.Forms.RadioButton Ch_overlay_LC;
        private System.Windows.Forms.RadioButton Ch_overlay_RC;
        private System.Windows.Forms.RadioButton Ch_overlay_CT;
        private System.Windows.Forms.Label Lb_status_time;
        private System.Windows.Forms.ComboBox Tx_dst_fps;
        private System.Windows.Forms.CheckBox Ch_deshake;
        private System.Windows.Forms.Button Bt_dst_browse;
        private System.Windows.Forms.Button Bt_src_browse;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox Tx_acodec;
        private System.Windows.Forms.ComboBox Tx_dst_a_bitrate;
        private System.Windows.Forms.ComboBox Tx_dst_v_bitrate;
        private System.Windows.Forms.CheckBox Ch_src_hwaccel;
    }
}

