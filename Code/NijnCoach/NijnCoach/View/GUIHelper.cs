using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NijnCoach.View
{
    class GUIHelper
    {
        public static void setElement<T>(ref T control, System.Drawing.Point location, String name, System.Drawing.Size size,
                int tabIndex, String text, Boolean enabled = true) 
            where T : System.Windows.Forms.Control
        {
            control.Location = location;
            control.Name = name;
            control.Size = size;
            control.TabIndex = tabIndex;
            control.Text = text;
            control.Enabled = enabled;
        }
    }
}
