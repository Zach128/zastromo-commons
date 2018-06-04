using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfDestructCommons.Model.GraphicsMessages
{

    [Serializable]
    public enum BKG_ACTION
    {
        NO_ACTION,
        CLEAR_BKG,
        FILL_COLOR
    }

    /// <summary>
    /// A base class defining a pipe message structure which consists of a self-identifying message type and empty string array of arguments.
    /// </summary>
    [Serializable]
    public abstract class BackgroundCtrlMsg
    {

        public readonly BKG_ACTION BkgAction;
        private string[] Args { get; set; }

        public BackgroundCtrlMsg(BKG_ACTION action)
        {
            BkgAction = action;
            Args = new string[] { };
        }

    }
}
