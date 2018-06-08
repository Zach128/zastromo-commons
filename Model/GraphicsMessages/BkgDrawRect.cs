using SelfDestructCommons.Model.GraphicsMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfDestructCommons.Model.GraphicsMessages
{
    [Serializable]
    public class BkgDrawRect : BackgroundCtrlMsg
    {
        public BkgDrawRect() : base(BKG_ACTION.NO_ACTION) 
        {
        }
    }
}
