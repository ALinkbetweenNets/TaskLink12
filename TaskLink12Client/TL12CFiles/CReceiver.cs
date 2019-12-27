

using System;
using System.Diagnostics;
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
            
            //does not support multiple connections at once
            
            LogI("Starting Receiver");
            try
            {
                Debug.WriteLine("Started Receiver");
                while (ReceiverOn||true)
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
                    Socket socket = tcplistener.AcceptSocket();
                    try
                    {
                        

                        if (ReceiverOn || true)
                        {
                            //grabs first connection
                            LogI("Connection accepted from " + socket.RemoteEndPoint.ToString());

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
                                LogI("Sending...");
                                string msglength = TLL.GetBytes(msg, tll.SessionPassword, tll.initVector, encrypt).Length.ToString();
                                socket.Send(TLL.GetBytes(msglength, tll.SessionPassword, tll.initVector, encrypt));
                                socket.Send(TLL.GetBytes(msg, tll.SessionPassword, tll.initVector, encrypt));
                                LogI($"Sent{msg}. (Length:{msglength})");
                            }
                            async Task<string> Read(bool encrypted = true)
                            {
                                LogI("Receiving...");
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
                                LogI($"Received {ResponseString}. (Length: {ResponseLength})");
                                return ResponseString;
                            }

                            if (await Read(false) == "LINK")
                            {
                                Write("LINK", false);
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
                                        LogI("Received Authentication Token. Checking validity...");
                                        if (testPass == TLL.GetHash(TLL.GetHash("LINK" + TLL.Version).Substring(R1, R2 - R1)))
                                        {
                                            LogI("Authentication Token Correct");
                                            LogI($"Connection from {socket.RemoteEndPoint.ToString()} authenticated");
                                            string type = await Read();
                                            switch (type)
                                            {
                                                case "REQUEST":
                                                    LogI("Request accepted");
                                                    string[] processes = TLC.GetRunningProcesses();
                                                    StringBuilder stringBuilder = new StringBuilder();
                                                    foreach (string s in processes)
                                                    {
                                                        stringBuilder.Append(s);
                                                    }
                                                    Write(stringBuilder.ToString());

                                                    break;
                                                case "KILL":
                                                    LogI("Kill Request accepted");
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
                                                    LogI("Unknown Type: " + type);
                                                    break;
                                            }//switch
                                        }
                                        else LogI("Incorrect Password");
                                    }
                                    else LogI("Incorrect Authentication Array");
                                }
                                else LogI("Incorrect Protocol Version");
                            }
                            else LogI("Incorrect Protocol");
                            //RefreshReceiverStatus();

                            END:
                            socket.Close();
                            //close stream
                            tcplistener.Stop();
                            //End listener
                            LogI("Connection closed");
                            //RefreshStatusS(ref textBoxLog, ref labelStatus, ref buttonStartStop);
                            //FormTLClient.ActiveForm.Invoke((MethodInvoker)delegate { this.RefreshReceiverStatus(); });
                        }
                    }
                    catch(SocketException ex) 
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
                }
                return true;
            }
            catch (SocketException ex)
            {
                TLL.Log(ex);
                LogI("Remote Host closed Connection");
                LogI("Restarting...");
                return false;
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
                return false;
            }
        }
    }
}
