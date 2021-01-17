using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rerender
{
    public class TextBoxExtendable : TextBox
    {
        /*
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (base.Lines.Length > 0)
            {
                base.Multiline = true;
                TextFormatFlags flags = TextFormatFlags.WordBreak;
                Size sz = new Size(base.ClientSize.Width, int.MaxValue);
                int padding = 3;
                int borders = base.Height - base.ClientSize.Height;
                sz = TextRenderer.MeasureText(base.Text, base.Font, sz, flags);
                int h = sz.Height + borders + padding;
                if (base.Top + h > this.ClientSize.Height - 10)
                {
                    h = this.ClientSize.Height - 10 - base.Top;
                }
                base.Height = h;
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (base.Lines.Length <= 1)
            {
                base.Multiline = false;
            }
        }
        */
    }
}
