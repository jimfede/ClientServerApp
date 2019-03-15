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

            obtenerDatosConexion().ElementAt(0);

            //Keep a loopcounter 
            int loopCounter = 1;
            while (true)
            {
                //Write some information to the console window
                string messageToSend = "This is message #" + loopCounter;
                Console.WriteLine("Sending message to server saying '" + messageToSend + "'");

                //Send the message in a single line
                NetworkComms.SendObject("Message", obtenerDatosConexion().ElementAt(0), int.Parse(obtenerDatosConexion().ElementAt(1)), int.Parse(obtenerDatosConexion().ElementAt(2)));
                NetworkComms.SendObject()

                //Check if user wants to go around the loop
                Console.WriteLine("\nPress q to quit or any other key to send another message.");
                if (Console.ReadKey(true).Key == ConsoleKey.Q) break;
                else loopCounter++;
            }

            //We have used comms so we make sure to call shutdown
            NetworkComms.Shutdown();
        }

        public static List<object> obtenerDatosConexion()
        {
            //Solicita IP y puerto del servidor
            Console.WriteLine("Por favor ingrese la direccion IP del servidor y puerto en el formato 192.168.0.1:10000 y presione enter:");
            string serverInfo = Console.ReadLine();
            
            //Lista con datos de conexión
            List<object> datosConLst = new List<object>();
           
            //Parsea la información necesaria del string solicitado
            datosConLst.Add(serverInfo.Split(':').First());
            datosConLst.Add(int.Parse(serverInfo.Split(':').Last()));
            return datosConLst;

        }
    }
}
