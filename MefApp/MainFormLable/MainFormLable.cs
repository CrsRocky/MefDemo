using App.Contract;
using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace MainFormLable
{
    [Export(typeof(IMainForm))]
    public class MainFormLable : IMainForm
    {
        private Form mainForm;

        public Form MainForm { get => mainForm ?? (mainForm = new FrmLable()); }
    }
}