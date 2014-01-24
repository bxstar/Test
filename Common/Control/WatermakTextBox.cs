using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Common.Control
{
    public class WatermakTextBox : TextBox
    {
        const int WM_PAINT = 0xF;
        public string EmptyTextTip { get; set; }
        public Color EmptyTextTipColor { get; set; }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                WmPaint(ref m);
            }
        }



        private void WmPaint(ref Message m)
        {
            Rectangle rectangle = new Rectangle(0, 0, Width, Height);
            using (Graphics graphics = Graphics.FromHwnd(base.Handle))
            {
                if (Text.Length == 0 && !string.IsNullOrEmpty(EmptyTextTip) && !Focused)
                {
                    TextFormatFlags format = TextFormatFlags.EndEllipsis |TextFormatFlags.VerticalCenter;
                    if (RightToLeft == RightToLeft.Yes)
                    {
                        format |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
                    }

                    TextRenderer.DrawText(
                        graphics,
                        EmptyTextTip,
                        Font,
                        base.ClientRectangle,
                        EmptyTextTipColor,
                        format);
                }

            }

        }
    }
}
