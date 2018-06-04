using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfDestructCommons.Model.BackgroundMessages
{
    [Serializable]
    class BkgFillColor : BackgroundCtrlMsg
    {
        public Color FillColor { get; set; }

        public BkgFillColor()
            : base(BKG_ACTION.FILL_COLOR)
        {
            FillColor = Color.Transparent;
        }

        public BkgFillColor(Color color)
            : base(BKG_ACTION.FILL_COLOR)
        {
            FillColor = color;
        }

    }
}
