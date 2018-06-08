using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfDestructCommons.Model.GraphicsMessages
{
    [Serializable]
    public class BkgFillColor : BackgroundCtrlMsg
    {
        public Color FillColor { get; set; }

        public BkgFillColor(Color color)
            : base(BKG_ACTION.FILL_COLOR)
        {
            FillColor = color;
        }

        private BkgFillColor() : base(BKG_ACTION.CLEAR_BKG)
        {
            FillColor = Color.Transparent;
        }

        public static BkgFillColor ClearBkgMessage()
        {
            return new BkgFillColor();
        }

    }
}
