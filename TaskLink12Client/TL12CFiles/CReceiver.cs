

using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskLink12Client
{
    public partial class TLC
    {

        /// <summary>
        /// Checks whether the Receiver thread is busy and On
        /// </summary>
        /// <returns>Whether the Receiver is active</returns>
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

        public static async Task<bool> ReceiverRun(TLL tll)//Task<bool>
        {
            void LogInvoke(string msg)
            {
                TLL.Log(msg);
            }
            //does not support multiple connections at once
            try
            {

                while (ReceiverOn)
                {
                    //RefreshStatusS(ref textBoxLog, ref labelStatus, ref buttonStartStop);
                    LogInvoke("Starting Receiver");
                    //Initializes the Listener
                    TcpListener tcplistener = new TcpListener(IPAddress.Parse(tll.LocalIP), TLL.Port);

                    //Log("Local IP: " + LocalIP);
                    //Start Listening at the specified port
                    tcplistener.Start();
                    LogInvoke("The server is running at port " + TLL.Port.ToString());
                    LogInvoke("The local End point is  :" + tcplistener.LocalEndpoint);
                    LogInvoke("Waiting for a connection.....");
                    Socket socket = tcplistener.AcceptSocket();

                    if (ReceiverOn)
                    {
                        //grabs first connection
                        LogInvoke("Connection accepted from " + socket.RemoteEndPoint.ToString());

                        /* Server
                         *      Client
                         * LINK  4
                         * 4    LINK
                         * 
                         * SP[0-4]  5 -> ==
                         * 5    SP[5-9] -> ==
                         * type     10
                         * 5        Resp.Length
                         * Resp.Length  Response
                         */

                        async void Write(string msg, bool encrypt = true)
                        {
                            string msglength = TLL.GetBytes(msg, tll.SessionPassword, tll.initVector, encrypt).Length.ToString();
                            socket.Send(TLL.GetBytes(msglength, tll.SessionPassword, tll.initVector, encrypt));
                            socket.Send(TLL.GetBytes(msg, tll.SessionPassword, tll.initVector, encrypt));
                            LogInvoke($"Sent{msg}. (Length:{msglength})");
                        }
                        async Task<string> Read(bool encrypted = true)
                        {
                            byte[] Response = new byte[20];
                            int length = socket.Receive(Response);

                            int ResponseLength = 200;
                            try
                            {
                                ResponseLength = Convert.ToInt32(TLL.GetString(Response, length, tll.SessionPassword, tll.initVector, encrypted));
                            }
                            catch { }
                            byte[] ByteResponse = new byte[ResponseLength];
                            length = socket.Receive(ByteResponse);
                            string ResponseString = TLL.GetString(ByteResponse, length, tll.SessionPassword, tll.initVector, encrypted);
                            LogInvoke($"Received {ResponseString}. (Length: {ResponseLength})");
                            return ResponseString;
                        }

                        if (await Read() == "LINK")
                        {
                            Write("LINK");
                            if (await Read() == TLL.Version)
                            {
                                Write(TLL.Version);

                                int R1 = 2;
                                try
                                {
                                    R1 = Convert.ToInt32(await Read());
                                }
                                catch
                                {
                                    goto END;
                                }
                                if (R1 > 10 && R1 < 55)
                                {
                                    int R2 = TLL.Random(60, 110);
                                    Write(R2.ToString());
                                    string testPass = await Read();
                                    LogInvoke("Received Authentication Token. Checking validity...");
                                    if (testPass == TLL.GetHash(TLL.GetHash("LINK" + TLL.Version).Substring(R1, R2 - R1)))
                                    {
                                        LogInvoke("Authentication Token Correct");
                                        LogInvoke($"Connection from {socket.RemoteEndPoint.ToString()} authenticated");
                                        string type = await Read();
                                        switch (type)
                                        {
                                            case "REQUEST":
                                                LogInvoke("Request accepted");
                                                string[] processes = TLC.GetRunningProcesses();
                                                StringBuilder stringBuilder = new StringBuilder();
                                                foreach (string s in processes)
                                                {
                                                    stringBuilder.Append(s);
                                                }
                                                Write(stringBuilder.ToString());

                                                break;
                                            case "KILL":
                                                LogInvoke("Kill Request accepted");
                                                Write("K");
                                                string procKill = await Read();

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
                                                LogInvoke("Unknown Type: " + type);
                                                break;
                                        }//switch
                                    }
                                    else LogInvoke("Incorrect Password");
                                }
                                else LogInvoke("Incorrect Authentication Array");
                            }
                            else LogInvoke("Incorrect Protocol Version");
                        }
                        else LogInvoke("Incorrect Protocol");
                        //RefreshReceiverStatus();

                        END:
                        socket.Close();
                        //close stream
                        tcplistener.Stop();
                        //End listener
                        LogInvoke("Connection closed");
                        //RefreshStatusS(ref textBoxLog, ref labelStatus, ref buttonStartStop);
                        //FormTLClient.ActiveForm.Invoke((MethodInvoker)delegate { this.RefreshReceiverStatus(); });
                    }
                }
                return true;
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
                LogInvoke("Connection closed");
                //RefreshStatusS(ref textBoxLog, ref labelStatus, ref buttonStartStop);
                //FormTLClient.ActiveForm.Invoke((MethodInvoker)delegate { this.RefreshReceiverStatus(); });
                return false;
            }
        }
    }
}
