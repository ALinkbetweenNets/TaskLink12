using System;
using System.Net;
using System.Threading;
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
            LogF("Starting...");
            TLC.Form = this;
            DisableButtons();
            IpRefresh();
            TLC.FileSilent(ref textBoxLog);
            tll.FileSP(TLC.PathSP, ref tll, ref textBoxLog, TLC.Silent);
            if (tll.SPSet)
            {
                checkBoxSPSave.Checked = true;
                EnableButtons();
            }
            else
            {

                TLC.Silent = false;
            }
            SilentMode();
            RefreshStatusReceiver();

            EnableButtons();
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
                await Task.Delay(TimeSpan.FromSeconds(1));
                ReceiverStartStop(true);
                Hide();
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        public void EnableButtons()
        {
            //TLL.Log("Buttons Enable");
            bool SPSet = tll.SPSet;
            if (SPSet)
                buttonSPSet.Text = "Set new Session Password";
            checkBoxSPSet.Checked = SPSet;
            checkBoxIPSet.Checked = tll.IPSet;
            buttonSPSave.Enabled = SPSet;
            buttonStartStop.Enabled = tll.IPSet && SPSet;
            //RefreshStatusReceiver();
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
            RefreshStatusReceiver();
            DisableButtons();
        }

        public async void StartReceiver()
        {
            TLC.ReceiverOn = true;
            //TLC.ReceiverOn = TLC.ReceiverRun(tll).Result;
            Thread.CurrentThread.Abort();
        }

        public async void ReceiverStartStop(bool start)
        {

            RefreshStatusReceiver();
            if (start)
            {
                try
                {
                    TLC.ReceiverOn = true;
                    Thread t = new Thread(new ThreadStart(StartReceiver));
                    t.Start();

                    //TLC.ReceiverRun(tll).Start();
                    //if (!receiver)
                    //    TLL.LogBox("Error in Receiver");
                }
                catch (Exception ex)
                {
                    TLL.Log(ex);
                }
            }
            else
            {
                TLC.ReceiverOn = false;
                if (!TLC.ReceiverOn)
                    buttonStartStop.Text = "Start";
            }
            RefreshStatusReceiver();
        }

        public void buttonSPSet_Click(object sender, EventArgs e)
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

        private void buttonIPRefresh_Click(object sender, EventArgs e)
        {
            IpRefresh();
        }
        public void IpRefresh()
        {
            listBoxIPLocal.Items.Clear();
            tll.IpList = TLL.RefreshLocalIP();
            LogF("IPs on this Computer:");
            if (tll.IpList.Count > 0)
            {
                foreach (IPAddress ip in tll.IpList)
                {
                    listBoxIPLocal.Items.Add(ip.ToString());
                    LogF(ip.ToString());
                }
            }
            else
            {
                TLL.LogBox("Could not get local IP Addresses. Are you connected to a network?");
                LogF("Could not get local IP Addresses. Are you connected to a network?");
            }
            if (listBoxIPLocal.Items.Count == 1)
            {
                listBoxIPLocal.SetSelected(0, true);
            }
            IPListUpdate();
        }

        private void buttonStatusRefresh_Click(object sender, EventArgs e)
        {
            RefreshStatusReceiver();
        }

        /// <summary>
        /// Checks whether the Receiver thread is busy and On
        /// </summary>
        /// <returns>Whether the Receiver is active</returns>
        public bool RefreshStatusReceiver()
        {
            checkBoxReceiver.Checked = TLC.ReceiverOn;
            if (TLC.ReceiverOn)
            {
                TLL.LogF("Receiver Status: Running", ref textBoxLog);
                labelStatus.Text = "Status: Running";
                buttonStartStop.Text = "Stop";
                return true;
            }
            else
            {
                TLL.LogF("Receiver Status: Not Running", ref textBoxLog);
                labelStatus.Text = "Receiver Status: Not Running";
                buttonStartStop.Text = "Start";
                return false;
            }
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (tll.SPSet && tll.IPSet)
            {
                //ReceiverStartStop(buttonStartStop.Text == "Start");
                if (buttonStartStop.Text == "Start")
                {
                    buttonStartStop.Text = "Stop";
                    ReceiverStartStop(true);
                }
                else
                {
                    buttonStartStop.Text = "Start";
                    ReceiverStartStop(false);
                }
            }
            else
                TLL.LogBox("Please set a Session Password and select an IP Address first");
        }

        private void listBoxIP_Click(object sender, EventArgs e)
        {
            IPListUpdate();
        }

        public void IPListUpdate()
        {
            try
            {
                if (listBoxIPLocal.SelectedItem.ToString().Length > 0)
                {
                    string ip = TLL.StringCheck(listBoxIPLocal.SelectedItem.ToString());
                    if (TLL.IPFilter(ip))
                    {
                        tll.LocalIP = ip;
                        textBoxIP.Text = ip;
                    }
                }
            }
            catch
            {
                tll.LocalIP = "";
                textBoxIP.Text = "";
            }
            EnableButtons();
        }

        private void buttonSilent_Click(object sender, EventArgs e)
        {

        }

        private void buttonSPRemove_Click(object sender, EventArgs e)
        {
            if (TLL.BoxConfirm("This will remove the Session Password so it cannot be loaded automatically at startup. Do you want to delete it?", "Delete Session Password"))

                tll.FileSPRemove(TLC.PathSP);
        }

        private void buttonSPSave_Click(object sender, EventArgs e)
        {
            if (TLL.BoxConfirm("This will save the Session Password so it will be loaded automatically at startup. Do you want to save it?", "Save Session Password"))
                checkBoxSPSave.Checked = tll.FileSPSave(TLC.PathSP);
        }

        private void notifyIconSilent_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
