﻿using System;
using System.Text;
using System.Windows;
using EmergenceGuardian.FFmpeg;

namespace EmergenceGuardian.FFmpegExampleApplication {
    /// <summary>
    /// Interaction logic for ErrorWindow.xaml
    /// </summary>
    public partial class FFmpegErrorWindow : Window {
        public static void Instance(Window parent, FFmpegProcess host) {
            FFmpegErrorWindow F = new FFmpegErrorWindow();
            F.Owner = parent;
            F.Title = (host.LastCompletionStatus == CompletionStatus.Timeout ? "Timeout: " : "Failed: ") + host.Options.Title;
            F.OutputText.Text = host.CommandWithArgs + Environment.NewLine + Environment.NewLine + host.Output;
            F.Show();
        }

        public FFmpegErrorWindow() {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
