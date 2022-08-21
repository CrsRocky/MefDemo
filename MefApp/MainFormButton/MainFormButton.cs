using App.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainFormButton
{
    [Export(typeof(IMainForm))]
    public class MainFormButton : IMainForm
    {
        private Form mainForm;

        public Form MainForm { get => mainForm ?? (mainForm = new FrmButton()); }
    }
}
