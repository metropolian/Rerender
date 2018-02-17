using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace Rerender
{
    public class Taskbar
    {
        private IWin32Window window;

        public Taskbar(IWin32Window source)
        {
            window = source;
        }

        public void Reset()
        {
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, window.Handle);
        }


        public void ProgressBegin()
        {
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, window.Handle);
        }

        public void ProgressUpdate(double percentage)
        {
            percentage = (percentage > 1) ? percentage * 100 :
                (percentage < 0) ? 0 : percentage;
            TaskbarManager.Instance.SetProgressValue((int) (percentage * 100), 100, window.Handle);

            
        }

        public void ProgressEnd()
        {
            TaskbarManager.Instance.SetProgressValue(100, 100, window.Handle);
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, window.Handle);
        }

        public void ProgressPause()
        {
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused, window.Handle);
        }

        public void ProgressError()
        {
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error, window.Handle);
        }
    }
}
