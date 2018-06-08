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
        NO_ACTION,      //Do nothing
        CLEAR_BKG,      //Clear screen
        FILL_COLOR,     //Fill screen with solid colour
        SHW_WRN,        //Show Warning screen
        EMG_SHDN        //Perform emergency shutdown
    }

    /// <summary>
    /// A base class defining a pipe message structure which consists of a self-identifying message type and empty string array of arguments.
    /// </summary>
    [Serializable]
    public class BackgroundCtrlMsg
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
