using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfDestructCommons.Model.GraphicsMessages
{
    [Serializable]
    public class BkgShowWarning : BackgroundCtrlMsg
    {
        public BkgShowWarning() : base(BKG_ACTION.SHW_WRN)
        {
        }
    }
}
