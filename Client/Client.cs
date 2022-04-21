using System;  
using System.Net;  
using System.Net.Sockets;  
using System.Text;

using System.Threading;


public class Client
{
    Socket socket;
    int state = 0;
    // connect the client to the server
    public void connectClient()
    {
        if (this.state == 1)
        {
            return; // already connected
        }
        this.state = 1;
        IPHostEntry clientInfo = Dns.GetHostEntry(Dns.GetHostName()); // get client info
        IPAddress clientIP = clientInfo.AddressList[0]; // get client IP
        IPAddress serverIP = clientInfo.AddressList[0]; // server IP
        IPEndPoint serverEndPoint = new IPEndPoint(serverIP, 55002);
        this.socket = new Socket(clientIP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            this.socket.Connect(serverEndPoint);
            
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Caught exception: {ex.Message}");
        }
        
    }

     // send some message to the server
    public void sendMessage(byte[] str)
    {
        // client is not connected
        if (this.state == 0) 
        {
            return;
        }
        try // send the message
        {
            this.socket.Send(str);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"[Client] Cannot write: {ex.Message}");
        }
    }
}
















