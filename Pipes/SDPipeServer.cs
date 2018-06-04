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

    public class SDPipeServer
    {

        private NamedPipeServer<BackgroundCtrlMsg> server;

        private readonly Dictionary<int, CLIENT_TYPE> clients;


        public SDPipeServer()
        {
            clients = new Dictionary<int, CLIENT_TYPE>(2);
            InitServer();
        }

        private void InitServer()
        {
            server.ClientConnected += delegate (NamedPipeConnection<BackgroundCtrlMsg, BackgroundCtrlMsg> conn)
            {
                //Client management code
                clients.Add(conn.Id, CLIENT_TYPE.GRAPHICS_CTRL);
            };

            server.ClientMessage += delegate (NamedPipeConnection<BackgroundCtrlMsg, BackgroundCtrlMsg> conn, BackgroundCtrlMsg message)
            {
                //TODO: Add server handling code
            };

            server.ClientDisconnected += delegate (NamedPipeConnection<BackgroundCtrlMsg, BackgroundCtrlMsg> conn)
            {
                //Client removal code
                clients.Remove(conn.Id);
            };

        }

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
