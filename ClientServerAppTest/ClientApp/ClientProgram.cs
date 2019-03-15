using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkCommsDotNet;

namespace ClientApp
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            //Solicita IP y puerto del servidor
            Console.WriteLine("Por favor ingrese la direccion IP del servidor y puerto en el formato 192.168.0.1:10000 y presione enter:");
            string serverInfo = Console.ReadLine();

            //Parsea la información necesaria del string solicitado
            string serverIP = serverInfo.Split(':').First();
            int serverPort = int.Parse(serverInfo.Split(':').Last());

            //Keep a loopcounter 
            int loopCounter = 1;
            while (true)
            {
                //Write some information to the console window
                string messageToSend = "This is message #" + loopCounter;
                Console.WriteLine("Sending message to server saying '" + messageToSend + "'");

                //Send the message in a single line
                NetworkComms.SendObject("Message", serverIP, serverPort, messageToSend);
      
                //Check if user wants to go around the loop
                Console.WriteLine("\nPress q to quit or any other key to send another message.");
                if (Console.ReadKey(true).Key == ConsoleKey.Q) break;
                else loopCounter++;
            }

            //We have used comms so we make sure to call shutdown
            NetworkComms.Shutdown();
        }
    }
}
