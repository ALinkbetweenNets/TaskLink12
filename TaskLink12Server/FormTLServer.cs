using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
#pragma warning disable CA1031 // Do not catch general exception types
#pragma warning disable IDE1006 // Benennungsstile
#pragma warning disable CA1303 // Literale nicht als lokalisierte Parameter übergeben
namespace TaskLink12Server
{
    public partial class FormTLServer : Form
    {
        private TLL tll = new TLL();
        public bool ClientSet
        {
            get
            {
                try
                {
                    return listBoxClientIP.Items.Count > 0 && listBoxClientIP.SelectedItem.ToString().Length > 0
                        && TLL.IPFilter(listBoxClientIP.SelectedItem.ToString());
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
                    return checkedListBoxProc.Items.Count > 0 && checkedListBoxProc.SelectedItem.ToString().Length > 0;
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
            EnableButtons();
            IpRefresh();
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
            buttonClientSave.Enabled = C;
            buttonClientClear.Enabled = C;
            TLL.GCollector();
        }

        private void buttonSPSet_Click(object sender, EventArgs e)
        {
            SetSessionPassword();
        }

        public void SetSessionPassword()
        {
#pragma warning disable IDE0059 // Unnötige Zuweisung eines Werts.
        SPInput:
            buttonSPSet.Enabled = false;

            string Input = TLL.BoxInput(
                "Enter new Session Password", "Session Password");
            if (Input.Length > 0)
            {

                string hash = TLL.GetHash(Input, TLL.HashType.h512);

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
            TLL.GCollector();
#pragma warning restore IDE0059 // Unnötige Zuweisung eines Werts.
        }

        private void buttonSPSave_Click(object sender, EventArgs e)
        {
            if (TLL.BoxConfirm("This will save the Session Password so it will be loaded automatically at startup. Do you want to save it?"
                , "Save Session Password"))
            {
                bool success = tll.FileSPSave(TLS.PathSP);
                buttonSPRemove.Enabled = success;
                checkBoxSPSet.Checked = success;
            }
        }

        private void buttonSPRemove_Click(object sender, EventArgs e)
        {
            if (TLL.BoxConfirm("This will remove the Session Password from the file (It is still in the current Program). Do you want to remove it?"
                , "Remove Session Password File"))
            {
                buttonSPRemove.Enabled = !tll.FileSPRemove(TLS.PathSP);
            }
        }

        private void buttonIPLocalRefresh_Click(object sender, EventArgs e)
        {
            IpRefresh();
        }

        ///<summary>
        ///Gets IP Address of Internal Network and Writes to label
        ///</summary>
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
            TLL.GCollector();
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

        private void buttonClientAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string enteredAddress = TLL.StringCheck(TLL.BoxInput(
                    "Enter new IPv4 Address of a Client Computer (eg. 192.168.1.5)",
                    "New Client IP"));
                if (TLL.IPFilter(enteredAddress))
                {
                    IPAddress ip = IPAddress.Parse(enteredAddress);
                    listBoxClientIP.Items.Add(ip);
                    listBoxClientIP.SetSelected(listBoxClientIP.Items.IndexOf(ip), true);
                    buttonClientSave.Enabled = true;
                    buttonClientRemove.Enabled = true;
                    buttonClientClear.Enabled = true;
                }
                else TLL.LogBox("Invalid IPv4 Formatting. IP Address must be local");
            }
            catch { TLL.LogBox("Invalid IPv4 Formatting"); }
            EnableButtons();
        }

        private void buttonClientRemove_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxClientIP.Items.RemoveAt(listBoxClientIP.SelectedIndex);
            }
            catch { }
        }

        private void buttonClientSave_Click(object sender, EventArgs e)
        {
            if (listBoxClientIP.Items.Count > 0)
            {
                List<string> ipList = new List<string>();
                foreach (IPAddress ip in listBoxClientIP.Items)
                {
                    ipList.Add(ip.ToString());
                }
                TLS.FileClientSave(ipList.ToArray());
            }
        }

        private void buttonClientLoad_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxClientIP.Items.Clear();
                foreach (IPAddress ip in TLS.FileClientLoad())
                {
                    if (TLL.IPFilter(ip))
                        listBoxClientIP.Items.Add(ip);
                }
            }
            catch { }
        }

        private void buttonClientClear_Click(object sender, EventArgs e)
        {
            if (listBoxClientIP.Items.Count > 0)
                if (TLL.BoxConfirm("", "Clear Client List"))
                {
                    listBoxClientIP.Items.Clear();
                }
        }

        private void listBoxIPLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            IPListUpdate();
        }

        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (tll.IPSet && tll.SPSet && listBoxClientIP.SelectedItem.ToString().Length > 0)
                {
                    Console.WriteLine("Connecting");
                    string req = await TLS.ConnectAsync(listBoxClientIP.SelectedItem.ToString(), tll).ConfigureAwait(true);
                    Console.WriteLine("Request Result:" + req);
                    if (req.Length > 0)
                    {
                        checkedListBoxProc.Items.Clear();
                        foreach (string s in req.Split(';'))
                        {
                            try
                            {
                                checkedListBoxProc.Items.Add(s);
                                if (s.StartsWith("!", StringComparison.Ordinal))
                                    checkedListBoxProc.SetItemChecked(checkedListBoxProc.Items.IndexOf(s), true);
                            }
                            catch (Exception ex) { TLL.Log(ex); }
                        }
                        checkedListBoxProc.Items.RemoveAt(checkedListBoxProc.Items.Count - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                TLL.Log(ex);
                TLL.LogBox("Could not start Connector. Make sure you have set the Session Password, your Local IP Address and a Client IP to connect to");
            }
        }

        private async void buttonEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tll.IPSet && tll.SPSet && listBoxClientIP.SelectedItem.ToString().Length > 0
                    && checkedListBoxProc.SelectedItem.ToString().Length > 0)
                    if (await TLS.ConnectAsync(listBoxClientIP.SelectedItem.ToString(), tll, "KILL",
                        checkedListBoxProc.SelectedItem.ToString()).ConfigureAwait(true) == "S")
                        TLL.LogBox($"Successfully Ended {checkedListBoxProc.SelectedItem.ToString()}");
                    else TLL.LogBox($"Could not end {checkedListBoxProc.SelectedItem.ToString()}");
            }
            catch { TLL.LogBox("Select a Process first"); }
        }

        private void listBoxClientIP_Click(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Text = TLL.Random(20, 40).ToString();

            /*
            if (tll.SPSet)
            {
                Console.WriteLine(TLL.DecryptString(TLL.EncryptString("abcdefg", tll.SessionPassword, tll.initVector), tll.SessionPassword, tll.initVector));
                Console.WriteLine(TLL.DecryptString(TLL.EncryptString("az8fdfghieurohg duiofshgnifusodhgniufodghndigffhfffdffffgffffdffffgffff", tll.SessionPassword, tll.initVector), tll.SessionPassword, tll.initVector));
                Console.WriteLine(TLL.DecryptString("hrDAnZzgBWx3NcbqYr074dNWq1kvraImYNAtxeJwe3a1YcY3qJHl1ORaKYLDv8JcfUpMQW42Eiq6Uxq1bAH13L9zwBk47ZrLValpgXO7N93CGdZyLUIjTZW8lI4bUhiI5yHelvTRqYN9nYZ7Ufg692BN9JX62fIGKYIjw7zE04qbCddl815UbwzKRC0LPHO3RUwyyZnrhKiTNFi4chvpS92sYjW8ccpqDNuWXBfF3L1iVBpff+u/gF2HK2cXpdgDdSFTn059SkQeKN3AIAgWUkXsdjNy7RQukFUGGAMoCoIAyFSlpUnjpTEpcmEk547ySB4UFltqJcgKXZJr9+zGisa6PTiJoR/PlKNdV2E6ACc=", tll.SessionPassword, tll.initVector));
            }*/
        }//,tll.SessionPassword,tll.initVector)TLL.GetString(bytes,bytes.Length,tll.SessionPassword,tll.initVector)

        private void checkedListBoxProc_Click(object sender, EventArgs e)
        {
            buttonEnd.Enabled = checkedListBoxProc.Items.Count > 0
                && checkedListBoxProc.SelectedItem.ToString().Length > 0;

        }
    }
}
#pragma warning restore CA1303 // Literale nicht als lokalisierte Parameter übergeben
#pragma warning restore IDE1006 // Benennungsstile
#pragma warning restore CA1031 // Do not catch general exception types