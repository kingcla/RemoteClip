using Quobject.SocketIoClientDotNet.Client;
using SimpleTCP;
using System;
using System.Diagnostics;

namespace RemoteClip.TCPClient
{
    public class RemoteClipConnection : IDisposable
    {
        SimpleTcpServer _receiver;
        SimpleTcpClient _sender;
        Socket _socket;

        public RemoteClipConnection()
        {
            _socket = IO.Socket("http://localhost:1337");

            _socket.On(Socket.EVENT_CONNECT, (data) =>
            {
                Debug.WriteLine("Connected to server!");
            });

            _socket.On("hi", (data) =>
            {
                Debug.WriteLine("Received data: " + data);
            });


            // The Receiver will listen to all incoming messages from our Server
            _receiver = new SimpleTcpServer().Start(8910);
            _receiver.ClientConnected += _receiver_ClientConnected;
            _receiver.ClientDisconnected += _receiver_ClientDisconnected;
            _receiver.DataReceived += _receiver_DataReceived;

            // The Sender will take care of sending notification to our Server
            _sender = new SimpleTcpClient();
        }

        public void SendClipboard(string clipboard)
        {
            _socket.Emit("online", () =>
            {
                Debug.WriteLine("Acknloedge: ");
            });


            //_sender.Connect("127.0.0.1", 1337);
            //_sender.WriteLine(clipboard);
        }

        private void _receiver_DataReceived(object sender, Message e)
        {
            Debug.WriteLine($"Message received: {e.MessageString}");
        }

        private void _receiver_ClientDisconnected(object sender, System.Net.Sockets.TcpClient e)
        {
            Debug.WriteLine($"Client disconnected: {e.ToString()}");
        }

        private void _receiver_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
        {
            Debug.WriteLine($"Client connected: {e.Client.RemoteEndPoint}");
        }

        public void Dispose()
        {
            _socket.Disconnect();
            _socket.Close();

            _socket = null;

            if (_sender != null)
            {
                _sender.Disconnect();
                _sender.Dispose();

                _sender = null;
            }

            if (_receiver != null)
            {
                if (_receiver.IsStarted) _receiver.Stop();

                _receiver = null;
            }            
        }
    }
}
