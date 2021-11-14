using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace NFS.Robot.Views
{
    public class RadarTickBar : TickBar
    {
        protected override void OnRender(DrawingContext dc)
        {
            Double tickFrequencySize;
            Brush foreBrush = this.Fill;
            Pen line_Pen = new Pen(foreBrush, 1);
            this.Placement = TickBarPlacement.Bottom;

            FormattedText font = null;
            Size size = new Size(base.ActualWidth, base.ActualHeight);
            int tickCount = (int)((this.Maximum - this.Minimum) / this.TickFrequency) + 1;
            if ((this.Maximum - this.Minimum) % this.TickFrequency == 0)
                tickCount -= 1;
            tickFrequencySize = (size.Width * this.TickFrequency / (this.Maximum - this.Minimum));
            string text = "";
            double num = this.Maximum - this.Minimum;
            int i = 0;
            for (i = 0; i <= tickCount; i++)
            {
                if (i % 4 == 0)
                {
                    text = Convert.ToString(Convert.ToInt32(this.Minimum + this.TickFrequency * i), 10);
                    font = new FormattedText(text + ":00", CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Verdana"), 14, foreBrush);
                    dc.DrawText(font, new Point((tickFrequencySize * i), 50));
                    dc.DrawLine(line_Pen, new Point((tickFrequencySize * i), 23), new Point((tickFrequencySize * i), 50));
                }
                else
                {
                    dc.DrawLine(line_Pen, new Point((tickFrequencySize * i), 23), new Point((tickFrequencySize * i), 39));
                }
            }
        }
    }
}
