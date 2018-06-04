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
        MSG_OK,
        ERR_ARGS,
        ERR_CMD,
        CTRL_FAIL,
        NO_RESPONSE
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
