using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TaskLink12Server
{
    public partial class TLS
    {
        /// <summary>
        /// Connects to Server with provided IP Address via TCP on specified port using TaskLink Protocol
        /// </summary>
        /// <param name="address">The local network TCP-IP Address to connect to</param>
        /// <param name="type">What TaskLinkTCPMessage Type (REQUEST, RESPONSE)</param>
        /// <param name="content">For Response only: the data to transmit (ProcessNames separated with ";")</param>
        public async Task<string> ConnectAsync(string address, TLL tll, string type = "REQUEST", string content = "")
        {
            if (tll.SessionPassword.Length > 0)
            {
                if (TLL.IPFilter(address))
                {

                    try
                    {
                        IPAddress ipaddress = IPAddress.Parse(address);
                        using (TcpClient tcpClient = new TcpClient())
                        {
                            TLL.Log($"Connecting to {address};{TLL.Port}. Type:{type}, Content:{content}...");
                            await tcpClient.ConnectAsync(ipaddress, TLL.Port);
                            TLL.Log("Connected");
                            NetworkStream stream = tcpClient.GetStream();
                            TLL.Log("Opened Stream");
                            //byte[] ByteResponse = new byte[100];


                            /* Server
                             *      Client
                             *      
                             * LINK  4
                             * 4    LINK
                             * 
                             * SP[0-4]  5 -> ==
                             * 5    SP[5-9] -> ==
                             * type     10
                             * 5        Resp.Length
                             * Resp.Length  Response
                             */

                            async void Write(string msg, TLL _tll, bool encrypt = true)
                            {
                                byte[] bytes = TLL.GetBytes(msg, tll.SessionPassword, tll.initVector, encrypt);
                                await stream.WriteAsync(TLL.GetBytes(bytes.Length.ToString(), tll.SessionPassword, tll.initVector), 0, bytes.Length);
                                await stream.WriteAsync(bytes, 0, bytes.Length);
                                TLL.Log($"Sent{msg}");
                            }
                            async Task<string> Read(TLL _tll, bool encrypted = true)
                            {
                                byte[] Response = new byte[3];
                                int length = await stream.ReadAsync(Response, 0, 3);

                                int ResponseLength = 200;
                                try
                                {
                                    ResponseLength = Convert.ToInt32(TLL.GetString(Response, length, tll.SessionPassword, tll.initVector));
                                }
                                catch (Exception)
                                { }
                                byte[] ByteResponse = new byte[ResponseLength];
                                length = await stream.ReadAsync(ByteResponse, 0, ResponseLength);
                                string ResponseString = TLL.GetString(ByteResponse, length, tll.SessionPassword, tll.initVector, encrypted);
                                TLL.Log($"Received {ResponseString}");
                                return ResponseString;
                            }
                            TLL.Log("Transmitter Ready");

                            Write("LINK",tll, false);
                            TLL.Log("Started Transmission");
                            if (await Read(tll,false) == "LINK")
                            {
                                TLL.Log("Correct Protocol");
                                Write(tll.SessionPassword.Substring(0, 4),tll);
                                if (await Read(tll) == tll.SessionPassword.Substring(5, 5))
                                {//Check if Received is first 5 chars of Session Password
                                    TLL.Log("Correct Password");
                                    Write(type,tll);
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

                                        Write(content,tll);
                                        if (await Read(tll) == "S")
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
                                        return await Read(tll);
                                    }
                                    //await stream.WriteAsync(GetBytes("END"), 0, GetBytes("END").Length);
                                }
                                else TLL.Log("INCORRECT PASSWORD");
                            }
                            else TLL.Log("INCORRECT PROTOCOL");

                            stream.Close();
                            stream.Dispose();
                            //Handlemsg(Response.ToString());
                            tcpClient.Close();
                            tcpClient.Dispose();
                        }
                        TLL.Log("Connection Closed");
                        return "";
                    }
                    catch (Exception ex)
                    {
                        TLL.Log(ex);
                        TLL.LogBox("Error In TCP Connection");
                        TLL.Log("Connection Closed");
                        return "";
                    }
                }
            }
            else TLL.LogBox();
            return string.Empty;

        }
    }
}
