using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TaskLink12Server
{
    public static partial class TLS
    {
        /// <summary>
        /// Connects to Server with provided IP Address via TCP on specified port using TaskLink Protocol
        /// See Protocol Plan
        /// </summary>
        /// <param name="address">The local network TCP-IP Address to connect to</param>
        /// <param name="tll">TLL Object to get Parameters like SessionPassword</param>
        /// <param name="type">What TaskLinkTCPMessage Type (REQUEST, RESPONSE)</param>
        /// <param name="content">For Response only: the data to transmit (ProcessNames separated with ";")</param>
        /// <returns>Request->Process Names separated with ';'
        /// Kill -> Success(S) or Fail(F)</returns>
        public static async Task<string> ConnectAsync(string address, TLL tll, string type = "REQUEST", string content = "")
        {
            if (tll.SessionPassword.Length > 0)
            {
                if (TLL.IPFilter(address))
                {
                    try
                    {
                        IPAddress ipaddress = IPAddress.Parse(address);
                        //using (TcpClient tcpClient = new TcpClient())
                        //{
                        TcpClient tcpClient = new TcpClient();
                            LogI($"Connecting to {address}:{TLL.Port}. Type:{type}, Content:{content}...");
                            await tcpClient.ConnectAsync(ipaddress, TLL.Port);
                            LogI("Connected");
                            NetworkStream stream = tcpClient.GetStream();
                            LogI("Opened Stream");
                            //byte[] ByteResponse = new byte[100];

                            async void Write(string msg, bool encrypt = true)
                            {
                                byte[] bytes = TLL.GetBytes(
                                    msg, tll.SessionPassword, tll.initVector, encrypt);
                                byte[] bytesLength = TLL.GetBytes(
                                    bytes.Length.ToString(), tll.SessionPassword, tll.initVector, false);
                                await stream.WriteAsync(bytesLength, 0, bytesLength.Length);
                                await stream.WriteAsync(bytes, 0, bytes.Length);
                                LogI($"Sent: {msg}");
                            }
                            async Task<string> Read(bool encrypted = true)
                            {
                                byte[] Response = new byte[3];
                                int length = await stream.ReadAsync(Response, 0, 3);

                                int ResponseLength = 200;
                                try
                                {
                                    ResponseLength = Convert.ToInt32(TLL.GetString(
                                        Response, length, tll.SessionPassword, tll.initVector, false));
                                }
                                catch { }
                                byte[] ByteResponse = new byte[ResponseLength];
                                length = await stream.ReadAsync(ByteResponse, 0, ResponseLength);
                                string ResponseString = TLL.GetString(
                                    ByteResponse, length, tll.SessionPassword, tll.initVector, encrypted);
                                LogI($"Received: {ResponseString}");
                                return ResponseString;
                            }
                            LogI("Transmitter Ready");

                            Write("LINK", false);
                            LogI("Started Transmission");
                            if (await Read(false) == "LINK")
                            {
                                LogI("Connection Initiated");
                                LogI("Correct Protocol");

                                Write(TLL.Version,false);
                                if (await Read(false) == TLL.Version)
                                {
                                    int R1 = TLL.Random(10, 55);
                                    Write(R1.ToString());
                                    int R2 = 2;
                                string num = await Read();
                                    try
                                    {
                                    LogI("Converting num");
                                        R2 = Convert.ToInt32(num);
                                    }
                                    catch
                                    {
                                        LogI("Invalid R2");
                                        //goto END;
                                    }
                                    if (R2 > 60 && R2 < 110)
                                    {
                                        Write(TLL.GetHash512(TLL.GetHash512("LINK" + TLL.Version).Substring(R1, R2 - R1)));
                                        string testPass = await Read();
                                        LogI("Received Authentication Token. Checking validity...");
                                        if (testPass == TLL.GetHash512(TLL.GetHash512("LINK" + TLL.Version).Substring(R1, R2 - R1)))
                                        {
                                            LogI("Authentication Token Correct");
                                            Write(type);
                                            if (type == "KILL")
                                            {
                                                /*string s;
                                                if (content.Length >= 10)
                                                    s = GetBytes(content).Length.ToString();
                                                else
                                                    s = 0 + GetBytes(content).Length.ToString();

                                                await stream.WriteAsync(GetBytes(s), 0,
                                                        GetBytes(GetBytes(content).Length.ToString()).Length);
                                                */

                                                Write(content);
                                                if (await Read() == "S")
                                                {
                                                    TLL.LogBox($"Successfully Stopped Process: {content}");
                                                    return "S";
                                                }
                                                else
                                                {
                                                    TLL.LogBox($"Could not Kill Process: {content}");
                                                    return "F";
                                                }
                                            }
                                            else if (type == "REQUEST")
                                            {
                                                /*byte[] ByteResponse3 = new byte[4];
                                                k = await stream.ReadAsync(ByteResponse3, 0, 4);
                                                int ResponseLength = Convert.ToInt32(GetString(ByteResponse3, k));
                                                LogS(GetString(ByteResponse3, k));

                                                byte[] ByteResponse4 = new byte[ResponseLength];
                                                k = await stream.ReadAsync(ByteResponse4, 0, ResponseLength);
                                                string Response = GetString(ByteResponse4, k);
                                                */
                                                return await Read();
                                            }
                                            else LogI("Unknown Type: " + type);
                                            //await stream.WriteAsync(GetBytes("END"), 0, GetBytes("END").Length);
                                        }
                                        else LogI("INCORRECT PASSWORD");
                                    }
                                    else LogI("IMPOSSIBLE R Range");

                                }
                                else LogI("Unequal Version");

                            }
                            else LogI("INCORRECT PROTOCOL");

                            stream.Close();
                            stream.Dispose();
                            //Handlemsg(Response.ToString());
                            tcpClient.Close();
                            tcpClient.Dispose();
                            LogI("Connection Closed");
                            return string.Empty;
                        //}
                    }
                    catch (Exception ex)
                    {
                        TLL.Log(ex);
                        TLL.LogBox("Error In TCP Connection");
                        LogI("Connection Closed");
                        return "";
                    }
                }
            }
            else TLL.LogBox();
            return string.Empty;
        }
    }
}
