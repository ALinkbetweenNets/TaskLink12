

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskLink12Client
{
    public partial class TLC
    {




        public static async Task<string[]> ReceiverRun(TLL tll, TextBox textBoxLog)
        {
            void LogInvoke(string msg)
            {
                TLL.LogF(msg, ref textBoxLog);
            }
            //does not support multiple connections at once
            try
            {
                while (ReceiverOn)
                {
                    FormTLClient.ActiveForm.Invoke((MethodInvoker)delegate
                    {
                        //FormTLClient.RefreshStatus(ref textBoxLog, ref labelStatus, ref buttonStartStop);
                    });
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
                            LogInvoke($"Sent{msg}. (Length:{msglength}");
                        }
                        async Task<string> Read(bool encrypted = true)
                        {
                            byte[] Response = new byte[3];
                            int length = socket.Receive(byteReceived);

                            int ResponseLength = 200;
                            try
                            {
                                ResponseLength = Convert.ToInt32(TLL.GetString(Response, length, tll.SessionPassword, tll.initVector, encrypted));
                            }
                            catch (Exception)
                            { }
                            byte[] ByteResponse = new byte[ResponseLength];
                            length = socket.Receive(ByteResponse);
                            string ResponseString = TLL.GetString(ByteResponse, length, tll.SessionPassword, tll.initVector, encrypted);
                            LogInvoke($"Received {ResponseString}");
                            return ResponseString;

                        }








                        if (Read(false) == "LINK")
                        {
                            LogInvoke("Correct Protocol");
                            socket.Send(GetBytes("LINK", true));
                            LogInvoke("Sending LINK");
                            byteReceived = new byte[GetBytes(
                                SessionPassword.Substring(0, 4)).Length];
                            byteLength = socket.Receive(byteReceived);

                            if (GetString(byteReceived, byteLength) ==
                                SessionPassword.Substring(0, 4))
                            {
                                LogInvoke("Correct Password");
                                LogInvoke("Sending " + SessionPassword.Substring(5, 9));
                                socket.Send(GetBytes(SessionPassword.Substring(5, 9)));
                                LogInvoke("Authenticated");
                                byteReceived = new byte[GetBytes("Request").Length];
                                byteLength = socket.Receive(byteReceived);

                                switch (GetString(byteReceived, byteLength))
                                {
                                    case "REQUEST":
                                        LogInvoke("Request accepted");
                                        string[] processes = GetRunningProcesses();
                                        StringBuilder stringBuilder = new StringBuilder();
                                        foreach (string s in processes)
                                        {
                                            stringBuilder.Append(s);
                                        }
                                        string processString = stringBuilder.ToString();
                                        byte[] ProcessByte = GetBytes(processString);
                                        socket.Send(GetBytes(ProcessByte.Length.ToString()));
                                        socket.Send(ProcessByte);

                                        break;
                                    case "KILL":
                                        LogInvoke("Kill Request accepted");
                                        byteReceived = new byte[4];
                                        byteLength = socket.Receive(byteReceived);
                                        socket.Send(GetBytes("l"));
                                        byte[] byteReceived1 = new byte[
                                            Convert.ToInt32(GetString(byteReceived, byteLength))];
                                        byteLength = socket.Receive(byteReceived1);

                                        if (KillProc(GetString(byteReceived1, byteLength)))
                                            socket.Send(GetBytes("S"));
                                        else
                                            socket.Send(GetBytes("F"));

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
                                        LogInvoke("Unknown Type: " +
                                            GetString(byteReceived, byteLength));
                                        break;
                                }
                                //RefreshReceiverStatus();
                            }
                            else LogInvoke("Incorrect Password");
                        }
                        else LogInvoke("Incorrect Protocol");

                        socket.Close();
                        //close stream
                        tcplistener.Stop();
                        //End listener
                        LogInvoke("Connection closed");
                        FormTLClient.ActiveForm.Invoke((MethodInvoker)delegate { this.RefreshReceiverStatus(); });
                    }
                }
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
                FormTLClient.ActiveForm.Invoke((MethodInvoker)delegate { this.RefreshReceiverStatus(); });
            }
        }
    }
}
