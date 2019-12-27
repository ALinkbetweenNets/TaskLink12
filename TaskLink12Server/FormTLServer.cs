using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskLink12Server
{
    public partial class FormTLServer : Form
    {
        public TLL tll = new TLL();
        public bool ClientSet
        {
            get
            {
                try
                {
                    return listBoxClientIP.Items.Count > 0 && listBoxClientIP.SelectedItem.ToString().Length > 0 && TLL.IPFilter(listBoxClientIP.SelectedItem.ToString());
                }
                catch { return false; }
            }
        }
        public bool ProcSet
        {
            get
            {
                try
                {
                    return listBoxProc.Items.Count > 0 && listBoxProc.SelectedItem.ToString().Length > 0;
                }
                catch { return false; }
            }
        }
        public string LogF(string msg)
        {
            return TLL.LogF(msg, ref textBoxLog);
        }
        public FormTLServer()
        {
            InitializeComponent();
        }
        public void EnableButtons()
        {
            bool C = ClientSet;
            bool S = tll.SPSet;
            bool I = tll.IPSet;
            if (S)
                buttonSPSet.Text = "Set new Session Password";
            checkBoxSPSet.Checked = S;
            checkBoxIPSet.Checked = I;
            checkBoxClientSet.Checked = C;
            buttonSPSave.Enabled = S;
            buttonConnect.Enabled = S && I && C;
            buttonEnd.Enabled = ProcSet;
            buttonClientRemove.Enabled = C;
            buttonClientLoad.Enabled = C;
            buttonClientSave.Enabled = C;
            buttonClientClear.Enabled = C;



            //RefreshStatusReceiver();
        }

        private void buttonSPSet_Click(object sender, EventArgs e)
        {
            SetSessionPassword();
        }

        public void SetSessionPassword()
        {
        SPInput:
            buttonSPSet.Enabled = false;

            string Input = TLL.BoxInput(
                "Enter new Session Password", "Session Password");
            if (Input.Length > 0)
            {
                string hash = TLL.GetHash(Input);
                Input = string.Empty;
                tll.SessionPassword = hash;
                hash = string.Empty;
                TLL.LogBox("Set new Session Password. SHA-512 Hash:\n" +
                        tll.SessionPassword);
            }
            else
            {
                if (TLL.BoxConfirm("Please enter a Password", "Invalid Input"))
                    goto SPInput;
            }
            buttonSPSet.Enabled = true;
            EnableButtons();
        }

        private void buttonSPSave_Click(object sender, EventArgs e)
        {
            buttonSPRemove.Enabled = true;
        }
    }
}
