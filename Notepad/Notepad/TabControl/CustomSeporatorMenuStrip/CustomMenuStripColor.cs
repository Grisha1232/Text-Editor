using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class MainForm : Form
    {
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        public class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemPressedGradientBegin
            {
                get { return themeLight ? Color.White : Color.FromArgb(45, 45, 45); }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return themeLight ? Color.White : Color.FromArgb(45, 45, 45); }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.Gray; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.DarkGray; }
            }
        }
    }
}
