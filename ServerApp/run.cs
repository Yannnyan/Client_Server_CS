using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class run
{
    static void Main(String[] args)
    {
        Server server = new Server();
        server.startListening();
    }
}

