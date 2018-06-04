using NamedPipeWrapper;
using SelfDestructCommons.Model.GraphicsMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfDestructCommons
{

    public abstract class SDPipeClient
    {

        private readonly NamedPipeClient<BackgroundCtrlMsg> client;

        public SDPipeClient(string clientName)
        {
            client = new NamedPipeClient<BackgroundCtrlMsg>(clientName);

            client.Disconnected += delegate(NamedPipeConnection<BackgroundCtrlMsg, BackgroundCtrlMsg> connection)
            {
                ClientDisconnected();
            };
            client.ServerMessage += delegate (NamedPipeConnection<BackgroundCtrlMsg, BackgroundCtrlMsg> connection, BackgroundCtrlMsg message)
            {
                BKG_RESPONSE result = ProcessMessage(message);

                ///If result code is 0 and BkgAction is not NO_ACTION,
                ///inform the server that the message was processed just fine.
                ///Else, send the provided result.
                if (result == BKG_RESPONSE.MSG_OK && message.BkgAction != BKG_ACTION.NO_ACTION)
                {
                    PushMessage(new BkgResponse(BKG_RESPONSE.MSG_OK));
                }
                else
                {
                    PushMessage(new BkgResponse(result));
                }
            };
        }

        /// <summary>
        /// Event callback for when the client receives a message.
        /// This event is used for processing the message received.
        /// </summary>
        /// <param name="message">The message received from the server</param>
        /// <returns>
        /// </returns>
        public abstract BKG_RESPONSE ProcessMessage(BackgroundCtrlMsg message);

        /// <summary>
        /// Event callback for when the client is disconnected from a server.
        /// </summary>
        /// <returns></returns>
        public abstract void ClientDisconnected();

        public void StartClient()
        {
            client.Start();
        }

        public void StopClient()
        {
            client.Stop();
        }

        public void PushMessage(BackgroundCtrlMsg message)
        {
            client.PushMessage(message);
        }

    }
}
