using NFS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace NFS.Robot.Views
{
    /// <summary>
    /// SpeedStyle.xaml 的交互逻辑
    /// </summary>
    public partial class SpeedStyle : UserControl
    {
        public double DegreeAngle
        {
            get { return (double)base.GetValue(DegreeAngleProperty); }
            set { base.SetValue(DegreeAngleProperty, value); }
        }
        public static readonly DependencyProperty DegreeAngleProperty =
            DependencyProperty.Register("DegreeAngle", typeof(double), typeof(SpeedStyle),
                new FrameworkPropertyMetadata(0d));
        public SpeedStyle()
        {
            InitializeComponent();
            this.CreateNormalBorderMark();
            this.DataContext = this;

            this.Loaded += ClockStyle_Loaded;
            this.Unloaded += ClockStyle_Unloaded;
            //速度赋值
            //TbkValue.Text = UserToken.speed.ToString();
        }

        private void ClockStyle_Loaded(object sender, RoutedEventArgs e)
        {
            this.FreeSampleTimer();
        }
        private void ClockStyle_Unloaded(object sender, RoutedEventArgs e)
        {
            this.CreateSampleTimer();
        }
        private void CreateNormalBorderMark()
        {
            this.GdEllipse.Children.Clear();

            double dAngel = 270d / 100d;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 25 != 0)
                {
                    Rectangle rect = new Rectangle();
                    rect.VerticalAlignment = VerticalAlignment.Top;
                    rect.HorizontalAlignment = HorizontalAlignment.Center;
                    rect.Fill = new SolidColorBrush(Colors.White);
                    rect.Width = 1;
                    rect.Margin = new Thickness(0, 5, 0, 0);
                    rect.Height = 2.5;
                    rect.RenderTransformOrigin = new Point(0.5, 18.05);

                    TransformGroup transGroup = new TransformGroup();
                    RotateTransform rotate = new RotateTransform();
                    rotate.Angle = -135 + i * dAngel;
                    transGroup.Children.Add(rotate);
                    TranslateTransform translate = new TranslateTransform();
                    translate.X = -0.5;
                    transGroup.Children.Add(translate);
                    rect.RenderTransform = transGroup;

                    this.GdEllipse.Children.Add(rect);
                }
            }
        }


        private DispatcherTimer TimerSample;

        private void CreateSampleTimer()
        {
            if (this.TimerSample == null)
            {
                this.TimerSample = new DispatcherTimer();
                this.TimerSample.Tick += TimerSample_Tick;
                this.TimerSample.Interval = TimeSpan.FromSeconds(1);
            }
            this.TimerSample.Start();
        }
        private void FreeSampleTimer()
        {
            if (this.TimerSample != null)
            {
                this.TimerSample.Stop();
                this.TimerSample.Tick -= TimerSample_Tick;
            }
            this.TimerSample = null;
        }

        private void TimerSample_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int nData = random.Next(0, 100);

            this.TbkValue.Text = nData + "";

            double dAngle = -135d + 270d * nData / 100d;

            DoubleAnimation anim = new DoubleAnimation(dAngle, TimeSpan.FromSeconds(0.3));
            anim.EasingFunction = new ExponentialEase();
            this.BeginAnimation(DegreeAngleProperty, anim);
        }
    }
}
