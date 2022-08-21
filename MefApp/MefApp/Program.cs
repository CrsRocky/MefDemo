using App.Contract;
using System;
using System.Windows.Forms;

namespace MefApp
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ImportManyProvider<IMainForm>().Relove(1).MainForm);
        }
    }
}