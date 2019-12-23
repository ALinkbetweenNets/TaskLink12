using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<string> ConnectAsync(string address, string type = "REQUEST", string content = "")
        {
            if (SessionPassword.Length > 0)
            {
                if (TLL.IPFilter(StringCheck(address)))
                {

                    try
                    {
                        IPAddress ipaddress = IPAddress.Parse(address);
                        using (TcpClient tcpClient = new TcpClient())
                        {
                            LogS($"Connecting to {address};{port}. Type:{type}, Content:{content}...");
                            await tcpClient.ConnectAsync(ipaddress, port);
                            LogS("Connected");
                            NetworkStream stream = tcpClient.GetStream();
                            LogS("Opened Stream");
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

                            async void Write(string msg, bool encrypt = true)
                            {
                                byte[] bytes = GetBytes(msg, encrypt);
                                await stream.WriteAsync(GetBytes(bytes.Length.ToString()), 0, bytes.Length);
                                await stream.WriteAsync(bytes, 0, bytes.Length);
                                LogS($"Sent{msg}");
                            }
                            async Task<string> Read(bool encrypted = true)
                            {
                                byte[] Response = new byte[3];
                                int length = await stream.ReadAsync(Response, 0, 3);

                                int ResponseLength = 200;
                                try
                                {
                                    ResponseLength = Convert.ToInt32(GetString(Response, length));
                                }
                                catch (Exception)
                                { }
                                byte[] ByteResponse = new byte[ResponseLength];
                                length = await stream.ReadAsync(ByteResponse, 0, ResponseLength);
                                string ResponseString = GetString(ByteResponse, length, encrypted);
                                LogS($"Received {ResponseString}");
                                return ResponseString;
                            }
                            LogS("Transmitter Ready");

                            Write("LINK", false);
                            LogS("Started Transmission");
                            if (await Read(false) == "LINK")
                            {
                                LogS("Correct Protocol");
                                Write(SessionPassword.Substring(0, 4));
                                if (await Read() == SessionPassword.Substring(5, 5))
                                {//Check if Received is first 5 chars of Session Password
                                    LogS("Correct Password");
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
                                            LogBox($"Successfully Stopped Process: {content}");
                                            return "S";
                                        }
                                        else
                                        {
                                            LogBox($"Could not Kill Process: {content}");
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
                                    //await stream.WriteAsync(GetBytes("END"), 0, GetBytes("END").Length);
                                }
                                else LogS("INCORRECT PASSWORD");
                            }
                            else LogS("INCORRECT PROTOCOL");

                            stream.Close();
                            stream.Dispose();
                            //Handlemsg(Response.ToString());
                            tcpClient.Close();
                            tcpClient.Dispose();
                        }
                        LogS("Connection Closed");
                        return "";
                    }
                    catch (Exception ex)
                    {
                        Log(ex);
                        LogBox("Error In TCP Connection");
                        LogS("Connection Closed");
                        return "";
                    }
                }
            }
            else LogBox();
            return string.Empty;

        }
    }
}
