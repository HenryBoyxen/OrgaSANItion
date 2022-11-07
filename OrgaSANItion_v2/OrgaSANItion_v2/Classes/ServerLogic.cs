using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace OrgaSANItion_v2.Classes
{
    public static class ServerLogic
    {
        static string Hostname = "192.168.178.42";
        static int Port = 32332;

        public static string ReadStreamString(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            stream.Read(buffer, 0, buffer.Length);
            int recv = 0;
            foreach (byte b in buffer)
            {
                if (b != 0)
                {
                    recv++;
                }
            }
            return Encoding.UTF8.GetString(buffer, 0, recv);
        }
        private static string ReadStreamWithApproval(NetworkStream stream, StreamWriter sw)
        {
            sw.Write("Continue");
            string answer = ReadStreamString(stream);
            return answer;
        }

        public static string Login_anmelden_sqlPassword(string username)
        {
            string sqlPassword;
            try
            {
                using (TcpClient tcpClient = new TcpClient(Hostname, Port))
                {
                    NetworkStream stream = tcpClient.GetStream();
                    StreamWriter sw = new StreamWriter(stream);
                    sw.AutoFlush = true;
                    //Send Request
                    sw.Write("Anmelden_anmelden");

                    //Wait for the Server to be ready
                    ReadStreamString(stream);

                    //Send username
                    sw.Write(username);

                    //Set sqlPassword to password from given benutzername
                    sqlPassword = ReadStreamString(stream);
                }
            }
            catch (SocketException ex)
            {
                return "SocketException";
            }
            catch
            {
                return "unknown_error";
            }

            return sqlPassword;
        }

        public static string[] GetSanisAndSpringerFromDate(DateTime dateTime)
        {
            string[] array = new string[4];
            string date = dateTime.ToShortDateString();
            try
            {
                using (TcpClient tcpClient = new TcpClient(Hostname, Port))
                {
                    NetworkStream stream = tcpClient.GetStream();
                    StreamReader sr = new StreamReader(stream);
                    StreamWriter sw = new StreamWriter(stream);
                    sw.AutoFlush = true;

                    //Send request
                    sw.Write("GetSanisAndSpringerFromDate");

                    //Wait for the server to be ready
                    ReadStreamString(stream);

                    //Send date
                    sw.Write(date);

                    //Get answer
                    IFormatter formatter = new BinaryFormatter();
                    array = (string[])formatter.Deserialize(stream);
                }
            }
            catch
            {
                return null;
            }

            return array;
        }

        public static string[] Homepage_initializeNextDuty()
        {
            string[] dateAndFunction = new string[2];
            
            try
            {
                using (TcpClient tcpClient = new TcpClient(Hostname, Port))
                {
                    NetworkStream stream = tcpClient.GetStream();
                    StreamReader sr = new StreamReader(stream);
                    StreamWriter sw = new StreamWriter(stream);
                    sw.AutoFlush = true;

                    //Send request
                    sw.Write("HomePage_initializeNextDuty");

                    //Wait for server to be ready
                    ReadStreamString(stream);

                    //Send username
                    sw.Write(Variables.GetUsername());

                    //Get date
                    dateAndFunction[0] = ReadStreamString(stream);

                    //Get function
                    dateAndFunction[1] = ReadStreamWithApproval(stream, sw);
                }
            }
            catch
            {
                return null;
            }
            return dateAndFunction;
        }

        public static Queue<string> AllDuties_initializeAllDuties()
        {
            Queue<string> queue = new Queue<string>();
            try
            {
                using (TcpClient tcpClient = new TcpClient(Hostname, Port))
                {
                    NetworkStream stream = tcpClient.GetStream();
                    StreamReader sr = new StreamReader(stream);
                    StreamWriter sw = new StreamWriter(stream);
                    sw.AutoFlush = true;

                    //Send request
                    sw.Write("Calender_initializeAllDuties");

                    //Wait for server to be ready
                    ReadStreamString(stream);

                    //Send username
                    sw.Write(Variables.GetUsername());

                    //Get answer
                    IFormatter formatter = new BinaryFormatter();
                    queue = (Queue<string>)formatter.Deserialize(stream);
                }
            }
            catch
            {
                return null;
            }
            return queue;
        }

        public static string[] Eintragung_initializeCheckboxes()
        {
            string[] array = new string[10];
            try
            {
                using (TcpClient tcpClient = new TcpClient(Hostname, Port))
                {
                    NetworkStream stream = tcpClient.GetStream();
                    StreamReader sr = new StreamReader(stream);
                    StreamWriter sw = new StreamWriter(stream);
                    sw.AutoFlush = true;

                    //Send request
                    sw.Write("Eintragung_initializeCheckboxes");

                    //Wait for server to be ready
                    ReadStreamString(stream);

                    //Send Username
                    sw.Write(Variables.GetUsername());

                    //Get array
                    IFormatter formatter = new BinaryFormatter();
                    array = (string[])formatter.Deserialize(stream);
                }
            }
            catch
            {
                return null;
            }
            return array;
        }

        public static bool Eintragung_eintragung(string[] array)
        {
            try
            {
                using (TcpClient tcpClient = new TcpClient(Hostname, Port))
                {
                    NetworkStream stream = tcpClient.GetStream();
                    StreamReader sr = new StreamReader(stream);
                    StreamWriter sw = new StreamWriter(stream);
                    sw.AutoFlush = true;

                    //Send request
                    sw.Write("Eintragung_eintragung");

                    //Wait for server to be ready
                    ReadStreamString(stream);

                    //Send Username
                    sw.Write(Variables.GetUsername());

                    //Wait for server to be ready
                    ReadStreamString(stream);

                    //Send array
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, array);

                    //Confirmation of receipt
                    string confirmation = ReadStreamString(stream);
                    if (confirmation != "true")
                        throw new Exception("No confirmation");
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
