using System;
using System.Text;


class run
{
    static void Main(string[] args)
    {
        Client client1 = new Client();
        client1.connectClient();
        while (true)
        {
            Console.WriteLine("[Client] Type a message to send: ");
            string? buffer = Console.ReadLine();
            byte[] arr = Encoding.ASCII.GetBytes(buffer);
            if (buffer != null)
                client1.sendMessage(arr);

        }

    }
}









