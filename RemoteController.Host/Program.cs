using Fleck;

namespace RemoteController.Host
{
    class Server
    {
        static void Main()
        {
            var controllerHandler = new ControllerHandler();

            FleckLog.Level = LogLevel.Debug;
            var allSockets = new List<IWebSocketConnection>();
            var server = new WebSocketServer("ws://0.0.0.0:8181");
            server.ListenerSocket.NoDelay = true;
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("Open!");
                    allSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("Close!");
                    allSockets.Remove(socket);
                    controllerHandler.DisconnectAll();
                };
                socket.OnMessage = message =>
                {
                    Console.WriteLine(message);
                    //allSockets.ToList().ForEach(s => s.Send("Echo: " + message));

                    if (message.TryParseJson(out MessageDto result))
                    {
                        controllerHandler.HandleMessage(result);
                        socket.Send("Parsed: ");
                    }
                    else if (message.TryParseJson(out StateDto stateDto))
                    {
                        controllerHandler.DisconnectById(stateDto.Id);
                    }
                    else
                    {
                        socket.Send("Received: ");
                    }
                };
            });

            var input = Console.ReadLine();
            while (input != "exit")
            {
                foreach (var socket in allSockets.ToList())
                {
                    socket.Send(input);
                }
                input = Console.ReadLine();
            }
        }
    }
}
