using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;

namespace BTAClient
{
    public class Client
    {
        public static BTAServer.Location location = new BTAServer.Location();

        public static void ConnectToServer(IPAddress address, int port)
        {
            IPEndPoint endpoint = new IPEndPoint(address, port);
            Socket socket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Byte[] buffer = new Byte[1024];

            try
            {
                socket.Connect(endpoint);
                Console.WriteLine("Connected to {0}", endpoint);

                while (true)
                {
                    socket.Receive(buffer);
                    location.FromBytes(buffer);
                    Console.WriteLine("Received location: {0:N6}:{1:N6}", location.Latitude, location.Longitude);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void getBusLocation()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "busLocationMQ",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    //Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "busLocationMQ",
                                     autoAck: true,
                                     consumer: consumer);

                //Console.WriteLine(" Press [enter] to exit.");
                //Console.ReadLine();
            }
        }

        public static void Main(String[] args)
        {
            IPAddress host = Dns.GetHostAddresses("localhost")[0];
            int port = 7777;


            getBusLocation();

            ConnectToServer(host, port);

        }
    }
}