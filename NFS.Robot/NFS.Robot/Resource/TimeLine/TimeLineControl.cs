using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace NFS.Robot.Resource.TimeLine
{
    /// <summary>刻度尺</summary>
    public class TimeLineControl : FrameworkElement
    {
        private readonly DrawingVisual visual = new DrawingVisual();
        private const double Margin_Top = 18d;
        private int tickCount;
        private int MinTickCount = 100;

        public static readonly DependencyProperty BorderBrushProperty;
        public static readonly DependencyProperty ForegroundProperty;
        public static readonly DependencyProperty FontSizeProperty;
        public static readonly DependencyProperty TickWidthProperty;
        public static readonly DependencyProperty FrameLengthProperty;
        public static readonly DependencyProperty TickFrequencyProperty;
        public static readonly DependencyProperty TextConverterProperty;

        public Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        public Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        /// <summary>总帧数</summary>
        public int FrameLength
        {
            get { return (int)GetValue(FrameLengthProperty); }
            set { SetValue(FrameLengthProperty, value); }
        }

        /// <summary>每刻度宽度容纳多个帧</summary>
        public int TickFrequency
        {
            get { return (int)GetValue(TickFrequencyProperty); }
            set { SetValue(TickFrequencyProperty, value); }
        }

        /// <summary>刻度宽度</summary>
        public int TickWidth
        {
            get { return (int)GetValue(TickWidthProperty); }
            set { SetValue(TickWidthProperty, value); }
        }

        /// <summary>刻度宽度</summary>
        public IValueConverter TextConverter
        {
            get { return (IValueConverter)GetValue(TextConverterProperty); }
            set { SetValue(TextConverterProperty, value); }
        }

        protected override Visual GetVisualChild(int index) => visual;

        protected override int VisualChildrenCount => 1;

        static TimeLineControl()
        {
            BorderBrushProperty = Control.BorderBrushProperty.AddOwner(typeof(TimeLineControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, OnTickChanged));
            ForegroundProperty = TextBlock.ForegroundProperty.AddOwner(typeof(TimeLineControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, OnTickChanged));
            FontSizeProperty = TextBlock.FontSizeProperty.AddOwner(typeof(TimeLineControl), new FrameworkPropertyMetadata(14d, FrameworkPropertyMetadataOptions.AffectsRender, OnTickChanged));
            TickWidthProperty = DependencyProperty.Register(nameof(TickWidth), typeof(int), typeof(TimeLineControl), new FrameworkPropertyMetadata(30, OnTickChanged, OnTickWidthCoerceValue));
            FrameLengthProperty = DependencyProperty.Register(nameof(FrameLength), typeof(int), typeof(TimeLineControl), new FrameworkPropertyMetadata(2000, OnTickChanged));
            TickFrequencyProperty = DependencyProperty.Register(nameof(TickFrequency), typeof(int), typeof(TimeLineControl), new FrameworkPropertyMetadata(100, OnTickChanged, OnTickFrequencyCoerceValue));
            TextConverterProperty = DependencyProperty.Register(nameof(TextConverter), typeof(IValueConverter), typeof(TimeLineControl));
        }

        public TimeLineControl()
        {
            this.Loaded += TimeLineControl_Loaded;
            AddVisualChild(visual);
        }

        private void TimeLineControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTrack();
        }

        private static object OnTickFrequencyCoerceValue(DependencyObject d, object baseValue)
        {
            int value = (int)baseValue;
            return value <= 0 ? 1 : value;
        }

        private static object OnTickWidthCoerceValue(DependencyObject d, object baseValue)
        {
            int value = (int)baseValue;
            return value <= 5 ? 5 : value;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return new Size(tickCount * TickWidth, Margin_Top + 20.5d);
        }

        private static void OnTickChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TimeLineControl)d).OnTickChanged();
        }

        private void OnTickChanged()
        {
            if (!IsLoaded)
                return;

            UpdateTrack();
        }

        private void UpdateTrack()
        {
            tickCount = Math.Max(MinTickCount, (FrameLength + TickFrequency - 1) / TickFrequency);
            InvalidateMeasure();
            InvalidateTrack();
            InvalidateVisual();
        }

        public static string GetTickText(int tick)
        {
            // 帧
            int ff = tick % 25;

            // 总秒数
            int ss = (tick - ff) / 25;

            // 秒
            int s = ss % 60;

            // 总分钟数
            int mm = (ss - s) / 60;

            return mm.ToString("d2") + ":" + s.ToString("d2") + "." + ff.ToString("d2");
        }

        private void InvalidateTrack()
        {
            var tickFrequency = TickFrequency;
            var tickWidth = TickWidth;
            var foreground = Foreground;
            var fontSize = FontSize;

            var borderPen = new Pen(BorderBrush, 2);
            borderPen.Freeze();

            var culture = CultureInfo.GetCultureInfo("en-us");
            var typeface = new Typeface("Verdana");

            using (var dc = visual.RenderOpen())
            {
                for (int i = 0; i <= tickCount; i++)
                {
                    double top;
                    double left = i * tickWidth + 1;
                    if (i % 6 == 0)
                    {
                        top = Margin_Top + 0.5d;

                        var text = (string)TextConverter.Convert(i * tickFrequency, typeof(string), null, null);
                        var formattedText = new FormattedText(text, culture, FlowDirection.LeftToRight, typeface, fontSize, foreground);

                        dc.DrawText(formattedText, new Point(left + 6d, Margin_Top - formattedText.Height + 4d));
                    }
                    else
                    {
                        top = Margin_Top + 10.5d;
                    }
                    dc.DrawLine(borderPen, new Point(left, top), new Point(left, Margin_Top + 20.5d));
                }
                dc.DrawLine(borderPen, new Point(0d, Margin_Top + 20.5d), new Point(tickCount * tickWidth, Margin_Top + 20.5d));
            }
        }
    }

    public class TextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value / 6).ToString() + ":00";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
