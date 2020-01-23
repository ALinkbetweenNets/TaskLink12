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
                if (TLL.IPFilter(address))
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
                            ushort attempts = 0;
                        WriteStart:
                            try
                            {
                                byte[] bytes = TLL.GetBytes(
                                    msg, tll.SessionPassword, tll.initVector, encrypt);
                                byte[] bytesLength = TLL.GetBytes(
                                    bytes.Length.ToString().PadLeft(TLL.ReadLengthLength, '0')
                                    , tll.SessionPassword, tll.initVector, false);
                                await stream.WriteAsync(bytesLength, 0, bytesLength.Length);
                                await stream.WriteAsync(bytes, 0, bytes.Length);
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
                                int length = stream.Read(Response, 0, TLL.ReadLengthLength);
                                int ResponseLength = 200;
                                try
                                {
                                    ResponseLength = Convert.ToInt32(TLL.GetString(
                                        Response, length, tll.SessionPassword,
                                        tll.initVector, false));
                                }
                                catch { }
                                byte[] ByteResponse = new byte[ResponseLength];
                                length = stream.Read(ByteResponse, 0, ResponseLength);
                                string ResponseString = TLL.GetString(
                                    ByteResponse, length, tll.SessionPassword,
                                    tll.initVector, encrypted);
                                LogI($"Received: {ResponseString}");
                                return ResponseString;
                            }
                            catch (Exception ex) { TLL.Log(ex); attempts++; goto ReadStart; }
                        }
                        LogI("Transmitter Ready");

                        Write("LINK", false);
                        LogI("Started Transmission");
                        if (Read(false) == "LINK")
                        {
                            LogI("Connection Initiated");
                            LogI("Correct Protocol");

                            Write(TLL.Version, false);
                            if (Read(false) == TLL.Version)
                            {
                                int R1 = TLL.Random(TLL.R1Min, TLL.R1Max);
                                Write(R1.ToString());
                                int R2 = 2;
                                string num = Read();
                                try
                                {
                                    LogI("Converting num");
                                    R2 = Convert.ToInt32(num);

                                    if (R2 > TLL.R2Min && R2 < TLL.R2Max)
                                    {
                                        string temp = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
                                        string Pass = TLL.GetHash512(tll.SessionPassword + temp);

                                        Write(TLL.GetHash512(Pass.Substring(
                                            R1 / 2,
                                            (R2 / 2) - (R1 / 2)
                                            )));
                                        string testPass = Read();
                                        LogI("Received Authentication Token. Checking validity...");
                                        if (testPass == TLL.GetHash512(Pass.Substring(
                                            R2 / 2 + R1 / 2,
                                            R2 - (R2 / 2 + R1 / 2)
                                            )))
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
                                                if (Read() == "S")
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
                                                return Read();
                                            }
                                            else LogI("Unknown Type: " + type);
                                            //await stream.WriteAsync(GetBytes("END"), 0, GetBytes("END").Length);
                                        }
                                        else LogI("INCORRECT PASSWORD");
                                    }
                                    else LogI("IMPOSSIBLE R Range");
                                }
                                catch
                                {
                                    LogI("Invalid R2");
                                }
                            }
                            else LogI("Unequal Version");
                        }
                        else LogI("INCORRECT PROTOCOL");

                        LogI("Reached End");
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
                else LogI("Invalid IP");
            else TLL.LogBox();
            return string.Empty;
        }
    }
}
