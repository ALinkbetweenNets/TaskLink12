using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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

        public void EnableButtons()
        {
            TLL.Log("ButtonEnableCheck");
            bool SPSet = tll.SessionPassword.Length > 0;
            if (SPSet)
                buttonSPSet.Text = "Set new Session Password";

            buttonSPSave.Enabled = SPSet;
        }



        public void ReceiverStartStop()
        {

            RefreshStatus(ref labelStatus, ref buttonStartStop, ref textBoxLog);
            if (buttonStartStop.Text == "Start Receiver")
            {
                try
                {
                    TLC.ReceiverOn = true;
                    //backgroundWorkerReceiver.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    TLL.Log(ex);
                    TLL.Log("Could not start Receiver (Probably already running)");
                }
                buttonStartStop.Text = "Stop";
                TLC.ReceiverOn = true;
            }
            else
            {
                TLC.ReceiverOn = false;
            }
            RefreshStatus(ref labelStatus, ref buttonStartStop, ref textBoxLog);

        }



        public void buttonSPSet_Click(object sender, EventArgs e)
        {
            SPSet();
        }
        public void SPSet()
        {
        SPInput:
            buttonSPSet.Enabled = false;

            string Input = TLL.BoxInput(
                "Enter new Session Password", "Session Password");
            if (Input.Length > 0)
            {
                string hash = TLL.GetHash(Input);
                tll.SessionPassword = hash;
                TLL.LogBox("Set new Session Password. SHA-512 Hash:\n" +
                        hash);
            }
            else
            {
                if (TLL.BoxConfirm("Please enter a Password", "Invalid Input"))
                    goto SPInput;
            }
            buttonSPSet.Enabled = true;
            EnableButtons();
        }

        private void buttonIPRefresh_Click(object sender, EventArgs e)
        {
            tll.IpList = TLL.RefreshLocalIP();
            LogF("IPs on this Computer:");
            if (tll.IpList.Count > 0)
            {
                foreach (IPAddress ip in tll.IpList)
                {
                    listBoxIP.Items.Add(ip.ToString());
                    LogF(ip.ToString());
                }
            }
            else
            {
                TLL.LogBox("Could not get local IP Addresses. Are you connected to a network?");
                LogF("Could not get local IP Addresses. Are you connected to a network?");
            }
        }



        private void buttonStatusRefresh_Click(object sender, EventArgs e)
        {
            RefreshStatus(ref labelStatus, ref buttonStartStop, ref textBoxLog);
        }
        /// <summary>
        /// Checks whether the Receiver thread is busy and On
        /// </summary>
        /// <returns>Whether the Receiver is active</returns>
        public static bool RefreshStatus(ref Label labelStatus, ref Button buttonStartStop, ref TextBox textBoxLog)
        {
            if (TLC.ReceiverOn)
            {
                TLL.LogF("Receiver Status: Running", ref textBoxLog);
                labelStatus.Text = "Status: Running";
                buttonStartStop.Text = "Stop Receiver";
                return true;
            }
            else
            {
                TLL.LogF("Receiver Status: Not Running", ref textBoxLog);
                labelStatus.Text = "Receiver Status: Not Running";
                buttonStartStop.Text = "Start Receiver";
                return false;
            }
        }
    }
}
