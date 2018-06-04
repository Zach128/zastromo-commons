using NamedPipeWrapper;
using SelfDestructCommons.Model.GraphicsMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfDestructCommons
{

    public class SDPipeClient
    {

        private NamedPipeClient<BackgroundCtrlMsg> client;

        public SDPipeClient()
        {
            InitClient();
        }

        private void InitClient()
        {
        }

        public void StartClient()
        {
            client.Start();
        }

        public void StopClient()
        {
            client.Stop();
        }

    }
}
