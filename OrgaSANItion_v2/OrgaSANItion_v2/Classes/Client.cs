using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace OrgaSANItion_v2.Classes
{
    internal class Client: IDisposable
    {
        static readonly string _hostname = "192.168.178.42";
        static readonly int _port = 32332;

        private readonly TcpClient _client;
        private readonly Stream _stream;

        public Client()
        {
                _client = new TcpClient(_hostname, _port);
                _stream = _client.GetStream();
        }

        public string ReadString()
        {
                byte[] buffer = new byte[1024];
                int bytesRead = _stream.Read(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }

        public object ReadObject()
        {
                IFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(_stream);
        }

        public void WriteString(string message)
        {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                _stream.Write(buffer, 0, buffer.Length);
                _stream.Flush();
        }

        public void WriteObject(object message)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(_stream, message);
        }

        public void Dispose()
        {
            _stream?.Dispose();
            _client?.Dispose();
        }
    }
}
