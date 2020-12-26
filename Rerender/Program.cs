using DmShared.UI;
using System;
using System.Windows.Forms;

namespace Rerender
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DpiAwareness.EnableDefault();           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainConvertor());
        }

        

    }


}
