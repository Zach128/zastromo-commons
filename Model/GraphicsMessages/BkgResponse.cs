using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfDestructCommons.Model.GraphicsMessages
{

    [Serializable]
    public enum BKG_RESPONSE
    {
        MSG_OK,         //Message OK response
        ERR_FMT,        //Error in message format (object type, action type, etc)
        ERR_ARGS,       //Error in message arguments
        ERR_CMD,        //Error in command/instruction
        CTRL_FAIL,      //Failure to process message
        NO_RESPONSE,    //No response from client (Null synonym)
    }

    public class BkgResponse : BackgroundCtrlMsg
    {

        public BKG_RESPONSE Code {get; set;}

        public BkgResponse(BKG_RESPONSE respCode) : base(BKG_ACTION.NO_ACTION)
        {
            Code = respCode;
        }
    }
}
