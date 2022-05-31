using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPClientSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UDP Client/Sender!");

            // initializing the UdpClient
            using (UdpClient socket = new UdpClient())
            {

                //readline hvor message kan indtastes - derefter press enter 
                string message = Console.ReadLine();

                //Encoding er en proces ved at tranformere et sæt af Unicode karaktere/characters
                //til en sekvens af bytes. I modsætning til, decoding som er en det omvendte

                //skal sende noget tilbage til client
                IPEndPoint EndPoint = null;

                //de 4 parametre er:
                //message er et byte array
                //længden af det byte array
                //modtagerens IP addresse
                //den port der skal benyttes
                //konverter det til en string

                //det er message der skal sendes til server
                //et byte[]
                byte[] data = Encoding.UTF8.GetBytes(message);

                //kalder send metoden der har de 4 parametre i sig
                //- Clienten vil gerne sende en besked til serveren
                socket.Send(data, data.Length, "127.0.0.1", 5005);

                //recieve - forventer at få noget tilbage igen - dette er ECHO
                //byte[] dataServer = socket.Receive(ref clientEndPoint);
                //string recivedMessage = Encoding.UTF8.GetString(dataServer);

                //recieve/server
                byte[] dataServer = socket.Receive(ref EndPoint);
                //konverter det til en string
                string recivedMessage = Encoding.UTF8.GetString(dataServer);

                Console.WriteLine("Sent message to server: " + message);
            }
        }
    }
}
