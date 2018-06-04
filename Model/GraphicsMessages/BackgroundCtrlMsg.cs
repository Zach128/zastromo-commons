using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfDestructCommons.Model.BackgroundMessages
{

    [Serializable]
    public enum BKG_ACTION
    {
        NO_ACTION,
        CLEAR_BKG,
        FILL_COLOR
    }

    [Serializable]
    abstract class BackgroundCtrlMsg
    {

        public readonly BKG_ACTION BkgAction;
        private string[] Args { get; set; }

        public BackgroundCtrlMsg(BKG_ACTION action)
        {
            BkgAction = action;
        }

    }
}
