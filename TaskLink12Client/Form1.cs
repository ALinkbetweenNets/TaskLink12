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
            IpRefresh();
            TLC.FileSilent(ref textBoxLog);
            TLC.FileSP(ref textBoxLog, tll);
            if (tll.SPSet)
            {
                EnableButtons();
            }
            else
            {

                TLC.Silent = false;
            }

            SilentMode();
            RefreshStatus(ref textBoxLog, ref labelStatus, ref buttonStartStop);
        }

        public async void SilentMode()
        {
            if (TLC.Silent && tll.SPSet)
            {
                LogF("Silent Mode. Hiding Form...");
                buttonSilent.Text = "Disable Silent Mode";
                try
                {
                    LogF("Starting Receiver in Silent Mode");
                    ReceiverStartStop(true);
                }
                catch (Exception ex)
                {
                    TLL.Log(ex);
                }
                notifyIconSilent.Visible = true;
                Hide();
                this.WindowState = FormWindowState.Minimized;
                await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
                ReceiverStartStop(true);
                Hide();
                await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        public void EnableButtons()
        {
            TLL.Log("Buttons Enable");
            bool SPSet = tll.SessionPassword.Length > 0;
            if (SPSet)
            {
                buttonSPSet.Text = "Set new Session Password";

                buttonSPSave.Enabled = SPSet;
            }
        }

        public void DisableButtons()
        {
            TLL.Log("Buttons Disable");
            bool SPSet = tll.SessionPassword.Length > 0;
            if (SPSet)
            {
                buttonSPSet.Text = "Set new Session Password";
                buttonSPSave.Enabled = SPSet;
            }
        }

        public async void startup()
        {
            if (TLC.Silent)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                //backgroundWorkerReceiver.RunWorkerAsync();
                Hide();
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            RefreshStatus(ref textBoxLog, ref labelStatus, ref buttonStartStop);
            DisableButtons();
        }


        public void ReceiverStartStop(bool start)
        {

            RefreshStatus(ref textBoxLog, ref labelStatus, ref buttonStartStop);
            if (start)
            {
                try
                {
                    ReceiverStartStop(true);
                }
                catch (Exception ex)
                {
                    TLL.Log(ex);
                }
                if(TLC.ReceiverOn)
                buttonStartStop.Text = "Stop";
                
            }
            else
            {
                ReceiverStartStop(false);
                if (!TLC.ReceiverOn)
                    buttonStartStop.Text = "Start";
            }
            RefreshStatus(ref textBoxLog, ref labelStatus, ref buttonStartStop);

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
                Input = string.Empty;
                tll.SessionPassword = hash;
                hash = string.Empty;
                checkBox1.Checked = true;
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
            IpRefresh();
        }
        public void IpRefresh()
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
            RefreshStatus(ref textBoxLog, ref labelStatus, ref buttonStartStop);
        }

        /// <summary>
        /// Checks whether the Receiver thread is busy and On
        /// </summary>
        /// <returns>Whether the Receiver is active</returns>
        public static bool RefreshStatus(ref TextBox textBoxLog, ref Label labelStatus, ref Button buttonStartStop)
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

        private void listBoxIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxIP.SelectedItem.ToString().Length > 0)
                {
                    string ip = TLL.StringCheck(listBoxIP.SelectedItem.ToString());
                    if (TLL.IPFilter(ip))
                    {
                        tll.LocalIP = ip;
                        textBoxIP.Text = ip;
                    }
                }


            }
            catch { }


        }
    }
}
