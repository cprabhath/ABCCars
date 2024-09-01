using ABCCars.CustomerForms;
using System;
using System.Windows.Forms;

namespace ABCCars
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // ================== Initialize the program ==================
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OnBoard());
            // ============================================================
        }
    }
}
