using System;  
using System.Net;  
using System.Net.Sockets;  
using System.Text;

using System.Threading;

using System.Collections;


public class Server
{
    private static ArrayList threadPool = new ArrayList();
    private void thread_listen(Socket socket)
    {
        int BUFFERSIZE = 1024;
        int numbytes = 0;
        byte[] buffer = new byte[BUFFERSIZE];
        string p;
        while(true)
        {
            try
            {
                numbytes = socket.Receive(buffer, BUFFERSIZE, 0);
                p = Encoding.Default.GetString(buffer);
                Console.WriteLine("[Server] Data received: " + p.Substring(0,numbytes));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                break;
            }
        }
        socket.Close();
    } 
    public void startListening()
    {
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());   // get the host information
        IPAddress IP = ipHostInfo.AddressList[0]; // get the ip address
        IPEndPoint local_end = new IPEndPoint(IP, 55002); // get the tuple for server's ip and port
        Socket socket = new Socket(IP.AddressFamily, SocketType.Stream, ProtocolType.Tcp); // create a socket for ipv4 tcp communication
        
       
        try // functions might throw exceptions
        { 
            // binds the server to maximum of 10 clients 
            socket.Bind(local_end);
            // puts the server at listening state
            socket.Listen(10);
            Console.WriteLine("[Server] Starting to listen. . .");
            while(true)
            {
                Socket client_connection = socket.Accept();
                Console.WriteLine("[Server] Got new connection");
                Thread thread = new Thread( () => thread_listen(client_connection) );
                thread.Start();
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


}





