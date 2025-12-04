using AkademineIS.Database;
using AkademineIS;
using System;
using System.Windows.Forms;

namespace AcademicInfoSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Database.GetConnection();

            Application.Run(new PrisijungimoForma());
        }
    }
}
