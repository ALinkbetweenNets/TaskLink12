using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TaskLink12Client
{
    public partial class FormTLClient : Form
    {
        public TLL tll = new TLL();
        public string LogF(string msg)
        {
            return TLL.LogF(msg, ref textBoxLog);
        }
        public FormTLClient()
        {
            InitializeComponent();

        }
    }
}
