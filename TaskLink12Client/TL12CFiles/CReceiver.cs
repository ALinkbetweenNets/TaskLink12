using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskLink12Client
{
    public static partial class TLC
    {

        /// <summary>
        /// Checks whether the Receiver thread is busy and On
        /// </summary>
        /// <param name="textBoxLog">textBoxLog to write to</param>
        /// <param name="labelStatus">Status Label to write result to</param>
        /// <param name="buttonStartStop">Button to change Text of</param>
        /// <returns>Wether the Receiver is running</returns>
        public static bool RefreshStatusS(ref TextBox textBoxLog, ref Label labelStatus, ref Button buttonStartStop)
        {
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

        //does not support multiple connections at once
        /// <summary>
        /// Receiver to be started in separate Thread
        /// </summary>
        /// <param name="tll">tll Object for Password</param>
        /// <returns>Returns Result of Connection</returns>
        public static async Task<TLL.ThreadReturn> ReceiverRun(TLL tll)//Task<bool>
        {
            if (tll.SessionPassword.Length > 0)
                try
                {
                    LogI("Starting Receiver");
                    Debug.WriteLine("Started Receiver");
                    while (ReceiverOn || true)
                    {
                    ReceiverStart:
                        //RefreshStatusS(ref textBoxLog, ref labelStatus, ref buttonStartStop);
                        LogI("Starting Receiver");
                        //Initializes the Listener
                        TcpListener tcplistener = new TcpListener(IPAddress.Parse(tll.LocalIP), TLL.Port);

                        //Log("Local IP: " + LocalIP);
                        //Start Listening at the specified port
                        tcplistener.Start();
                        LogI("The server is running at port " + TLL.Port.ToString());
                        LogI("The local End point is  :" + tcplistener.LocalEndpoint);
                        LogI("Waiting for a connection.....");
                        Socket socket = await tcplistener.AcceptSocketAsync().ConfigureAwait(true);
                        try
                        {
                            if (socket.RemoteEndPoint.AddressFamily == AddressFamily.InterNetwork)
                            {
                                if (ReceiverOn)
                                {
                                    string processString = string.Empty;
                                    void StartProcessCollection()
                                    {
                                        StringBuilder builder = new StringBuilder();
                                        foreach (string s in GetRunningProcesses())
                                        {
                                            builder.Append(s);
                                        }
                                        processString = builder.ToString();
                                        Thread.CurrentThread.Abort();
                                        TLL.GCollector();
                                    }
                                    Thread t = new Thread(new ThreadStart(StartProcessCollection));
                                    t.Start();

                                    //grabs first connection
                                    LogI($"Connection from {socket.RemoteEndPoint.ToString()} authenticated");

                                    void Write(string msg, bool encrypt = true)
                                    {
                                        ushort attempts = 0;
                                    WriteStart:
                                        try
                                        {
                                            byte[] bytes = TLL.GetBytes(
                                            msg, tll.SessionPassword, tll.initVector, encrypt);
                                            byte[] bytesLength = TLL.GetBytes(
                                                bytes.Length.ToString().PadLeft(TLL.ReadLengthLength, '0')
                                                , tll.SessionPassword, tll.initVector, false);
                                            socket.Send(bytesLength);
                                            socket.Send(bytes);
                                            LogI($"Sent: {msg}");
                                        }
                                        catch (Exception ex) { TLL.Log(ex); attempts++; goto WriteStart; }
                                    }
                                    string Read(bool encrypted = true)
                                    {
                                        ushort attempts = 0;
                                    ReadStart:
                                        try
                                        {
                                            byte[] Response = new byte[TLL.ReadLengthLength];
                                            int length = socket.Receive(Response);
                                            int ResponseLength = 200;
                                            try
                                            {
                                                ResponseLength = Convert.ToInt32(TLL.GetString(
                                                    Response, length, tll.SessionPassword,
                                                    tll.initVector, false));
                                            }
                                            catch { }
                                            byte[] ByteResponse = new byte[ResponseLength];
                                            length = socket.Receive(ByteResponse);
                                            string ResponseString = TLL.GetString(
                                               ByteResponse, length, tll.SessionPassword,
                                               tll.initVector, encrypted);
                                            LogI($"Received: {ResponseString}");
                                            return ResponseString;
                                        }
                                        catch (Exception ex) { TLL.Log(ex); attempts++; goto ReadStart; }
                                    }
                                    if (Read(false) == "LINK")
                                    {
                                        LogI("Connection Initiated");
                                        LogI("Correct Protocol");
                                        Write("LINK", false);
                                        if (Read(false) == TLL.Version)
                                        {
                                            Write(TLL.Version, false);

                                            try
                                            {
                                                string num = Read();
                                                int R1 = Convert.ToInt32(num);
                                                if (R1 > TLL.R1Min && R1 < TLL.R1Max)
                                                {
                                                    int R2 = 117;//TLL.Random(TLL.R2Min, TLL.R2Max);
                                                    Write(R2.ToString());

                                                    string temp = "1";// DateTime.Now.Hour.ToString();// + DateTime.Now.Minute.ToString();
                                                    string Pass = TLL.GetHash(tll.SessionPassword + temp, TLL.HashType.h256);

                                                    string testPass = Read();
                                                    LogI("Received Authentication Token. Checking validity...");
                                                    LogI(testPass);
                                                   
                                                    if (testPass == TLL.GetHash(Pass.Substring(
                                                        R1 / 2,
                                                        (R2 / 2)// - (R1 / 2)
                                                        ), TLL.HashType.h256))
                                                    {
                                                        LogI("Authentication Token Correct");
                                                        Write(TLL.GetHash(Pass.Substring(
                                                            R2 / 2 + R1 / 2,
                                                            R2// - (R2 / 2 + R1 / 2)
                                                            ), TLL.HashType.h256));
                                                        string type = Read();
                                                        switch (type)
                                                        {
                                                            case "REQUEST":
                                                                LogI("Request accepted");
                                                                if (!(processString.Length > 0))
                                                                {
                                                                    string[] processes = GetRunningProcesses();
                                                                    StringBuilder stringBuilder = new StringBuilder();
                                                                    foreach (string s in processes)
                                                                    {
                                                                        stringBuilder.Append(s);
                                                                    }
                                                                    processString = stringBuilder.ToString();
                                                                }
                                                                Write(processString);

                                                                break;
                                                            case "KILL":
                                                                LogI("Kill Request accepted");
                                                                string procKill = Read();

                                                                if (KillProc(procKill))
                                                                    Write("S");
                                                                else
                                                                    Write("F");

                                                                //byte[] ByteResponse3 = new byte[GetBytes(4.ToString()).Length];
                                                                //k = socket.Receive()
                                                                //k = stream.ReadAsync(ByteResponse3, 0, 4);
                                                                //int ResponseLength = Convert.ToInt32(GetString(ByteResponse3, k));
                                                                //LogInvoke(GetString(ByteResponse3, k));

                                                                //byte[] ByteResponse4 = new byte[ResponseLength];
                                                                //k = await stream.ReadAsync(ByteResponse4, 0, ResponseLength);
                                                                //string Response = GetString(ByteResponse4, k);

                                                                break;
                                                            default:
                                                                LogI("Unknown Type: " + type);
                                                                break;
                                                        }//switch
                                                    }
                                                    else LogI("Incorrect Password");
                                                }
                                                else LogI("Incorrect Authentication Array");
                                            }
                                            catch { LogI("Invalid Number"); }
                                        }
                                        else LogI("Incorrect Protocol Version");
                                    }
                                    else LogI("Incorrect Protocol");
                                    //RefreshReceiverStatus();

                                    socket.Close();
                                    //close stream
                                    tcplistener.Stop();
                                    //End listener
                                    LogI("Connection closed");
                                    //RefreshStatusS(ref textBoxLog, ref labelStatus, ref buttonStartStop);
                                    //FormTLClient.ActiveForm.Invoke((MethodInvoker)delegate { this.RefreshReceiverStatus(); });
                                }
                            }
                            else LogI("REMOTE ENDPOINT IS NOT FROM THE INTERNAL NETWORK!");
                        }
                        catch (SocketException ex)
                        {
                            TLL.Log(ex);
                            LogI("Remote Host closed Connection");
                            LogI("Restarting...");
                            socket.Close();
                            //close stream
                            tcplistener.Stop();
                            //End listener
                            LogI("Connection closed");
                            goto ReceiverStart;
                        }
                        LogI("End Reached");
                        socket.Close();
                        //close stream
                        tcplistener.Stop();
                        //End listener
                        LogI("Connection closed");
                    }//while
                    LogI("Receiver Off");
                    return TLL.ThreadReturn.Success;
                }
                catch (Exception ex)
                {
                    //Log(ex);
                    //LogMsgBox("Error in Receiver");
                    //socket.Close();
                    //close stream
                    //tcplistener.Stop(); 
                    //End listener
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine(ex.Message);
                    LogI("Connection closed");
                    //RefreshStatusS(ref textBoxLog, ref labelStatus, ref buttonStartStop);
                    //FormTLClient.ActiveForm.Invoke((MethodInvoker)delegate { this.RefreshReceiverStatus(); });
                    return TLL.ThreadReturn.Exception;
                }
            else
                return TLL.ThreadReturn.SP;
        }
    }
}
