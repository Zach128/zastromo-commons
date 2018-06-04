using NamedPipeWrapper;
using SelfDestructCommons.Model.GraphicsMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfDestructCommons
{

    public enum CLIENT_TYPE
    {
        UNKNOWN,
        GRAPHICS_CTRL
    }

    public abstract class SDPipeServer
    {

        private NamedPipeServer<BackgroundCtrlMsg> server;

        private readonly Dictionary<int, CLIENT_TYPE> clients;


        public SDPipeServer(string serverName)
        {
            clients = new Dictionary<int, CLIENT_TYPE>(2);
            server = new NamedPipeServer<BackgroundCtrlMsg>(serverName);

            server.ClientConnected += delegate (NamedPipeConnection<BackgroundCtrlMsg, BackgroundCtrlMsg> conn)
            {
                //Client management code
                clients.Add(conn.Id, CLIENT_TYPE.GRAPHICS_CTRL);
                ClientConnected(conn.Id);
            };

            server.ClientMessage += delegate (NamedPipeConnection<BackgroundCtrlMsg, BackgroundCtrlMsg> conn, BackgroundCtrlMsg message)
            {
                //TODO: Add server handling code
                ProcessMessage(conn.Id, message);
            };

            server.ClientDisconnected += delegate (NamedPipeConnection<BackgroundCtrlMsg, BackgroundCtrlMsg> conn)
            {
                ClientDisconnected(conn.Id);
                //Client removal code
                clients.Remove(conn.Id);
            };
        }

        /// <summary>
        /// Event callback called when a client connects to the server.
        /// This callback is called after the client has been added to the server.
        /// </summary>
        /// <param name="clientId">The id of the client.</param>
        public abstract void ClientConnected(int clientId);

        /// <summary>
        /// Event callback for handling client messages received by the server.
        /// </summary>
        /// <param name="clientId">The id of the client.</param>
        /// <param name="message">The message payload received.</param>
        /// <returns></returns>
        public abstract BkgResponse ProcessMessage(int clientId, BackgroundCtrlMsg message);

        /// <summary>
        /// Event callback called when a client disconnects from the server.
        /// This callback is called before the clients entry is removed.
        /// </summary>
        /// <param name="clientId">The id of the client.</param>
        public abstract void ClientDisconnected(int clientId);

        public void StartServer()
        {
            server.Start();
        }

        public void StopServer()
        {
            server.Stop();
        }

    }
}
