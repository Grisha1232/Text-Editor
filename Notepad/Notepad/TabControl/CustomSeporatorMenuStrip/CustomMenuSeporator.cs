using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad.TabControl.CustomSeporatorMenuStrip
{
    class CustomMenuSeporator : ToolStripSeparator
    {
        public CustomMenuSeporator()
        {
            this.Paint += ExtendedToolStripSeparator_Paint;
        }

        private void ExtendedToolStripSeparator_Paint(object sender, PaintEventArgs e)
        {
            ToolStripSeparator toolStripSeparator = (ToolStripSeparator)sender;
            int width = toolStripSeparator.Width;
            int height = toolStripSeparator.Height;

            Color foreColor = Color.Gray;
            
            Color backColor = MainForm.themeLight ? Color.White : Color.FromArgb(45, 45, 45);

            e.Graphics.FillRectangle(new SolidBrush(backColor), 0, 0, width, height);

            e.Graphics.DrawLine(new Pen(foreColor), 4, height / 2, width - 4, height / 2);
        }
    }
}
