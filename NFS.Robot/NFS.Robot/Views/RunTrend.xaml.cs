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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NFS.Robot.Views
{
    /// <summary>
    /// RunTrend.xaml 的交互逻辑
    /// </summary>
    public partial class RunTrend : UserControl
    {
        public RunTrend()
        {
            InitializeComponent();
        }

        #region 属性
        /// <summary>
        /// 尺寸大小
        /// 高宽大小一样
        /// </summary>
        public double Size
        {
            get { return (double)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(double),
        typeof(RunTrend), new PropertyMetadata(400.0));

        /// <summary>
        /// 标题
        /// </summary>
        public List<ArgumentModel> Arguments
        {
            get { return (List<ArgumentModel>)GetValue(ArgumentsProperty); }
            set { SetValue(ArgumentsProperty, value); }
        }

        public static readonly DependencyProperty ArgumentsProperty = DependencyProperty.Register("Arguments", typeof(List<ArgumentModel>),
        typeof(RunTrend), new PropertyMetadata(new List<ArgumentModel>()));
        /// <summary>
        /// 数据
        /// </summary>
        public List<ChartItem> Datas
        {
            get { return (List<ChartItem>)GetValue(DatasProperty); }
            set { SetValue(DatasProperty, value); }
        }

        public static readonly DependencyProperty DatasProperty = DependencyProperty.Register("Datas", typeof(List<ChartItem>),
        typeof(RunTrend), new PropertyMetadata(new List<ChartItem>()));
        /// <summary>
        /// 获取或设置线条颜色
        /// </summary>
        public Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush),
        typeof(RunTrend), new PropertyMetadata(Brushes.RoyalBlue));
        /// <summary>
        /// 连接点大小
        /// </summary>
        public int EllipseSize = 7;
        /// <summary>
        /// 控件大小
        /// </summary>
        public double TotalSize
        {
            get
            {
                double size = Size + 10;
                return size;
            }
        }
        /// <summary>
        /// 面板
        /// </summary>
        public Canvas ChartCanvas = new Canvas();

        //声明和注册路由事件
        public static readonly RoutedEvent TitleClickRoutedEvent =
        EventManager.RegisterRoutedEvent("TitleClick", RoutingStrategy.Bubble, typeof(EventHandler<RoutedEventArgs>), typeof(RunTrend));
        //CLR事件包装
        public event RoutedEventHandler TitleClick
        {
            add { this.AddHandler(TitleClickRoutedEvent, value); }
            remove { this.RemoveHandler(TitleClickRoutedEvent, value); }
        }
        //激发路由事件,借用Click事件的激发方法
        protected void OnClick(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(TitleClickRoutedEvent, e);
            this.RaiseEvent(args);
        }
        #endregion

        private void RunTrend_Loaded(object sender, RoutedEventArgs e)
        {
            // if (!CheckData())
            //{
            //    throw new Exception("RadarChart的数据之间不匹配!请重新配置!");
            //}
            ////获取最大数值
            //int maxData = Datas.Max(i => i.DataList.Max(o => o.Data));
            ////设置面板和背景
            //SetCanvasAndBackground(maxData);
            ////获取半圈大小
            //double length = Size / 2 / maxData;
            ////连接点半径
            //int ellipseR = EllipseSize / 2;
            //foreach (var chartItem in Datas)
            //{
            //    var color = chartItem.Color;

            //    //俩个多边形,一个设置背景,一个设置边框
            //    Polygon polygonArea = new Polygon() { Fill = color, Opacity = 0.2, StrokeThickness = 0 };
            //    Polygon polygonBorder = new Polygon() { Fill = Brushes.Transparent, Stroke = color, StrokeThickness = 0.8 };

            //    int index = 0;
            //    foreach (var data in chartItem.DataList)
            //    {
            //        double currentAngle = Angle * index + 90;
            //        double angle = (currentAngle / 360) * 2 * Math.PI;
            //        var r = data.Data * length;
            //        double x = Size / 2 + r * Math.Cos(angle);
            //        double y = Size / 2 - r * Math.Sin(angle);
            //        //多边形添加节点
            //        var point = new Point()
            //        {
            //            X = x,
            //            Y = y
            //        };
            //        polygonArea.Points.Add(point);
            //        polygonBorder.Points.Add(point);
            //        //设置节点Style
            //        var ellipse = new Ellipse() { Width = EllipseSize, Height = EllipseSize, Fill = color };
            //        Canvas.SetLeft(ellipse, x - ellipseR);
            //        Canvas.SetTop(ellipse, y - ellipseR);
            //        ChartCanvas.Children.Add(ellipse);

            //        index++;
            //    }
            //    ChartCanvas.Children.Add(polygonArea);
            //    ChartCanvas.Children.Add(polygonBorder);
            //}
        }

        /// <summary>
        /// 检查数据
        /// </summary>
        /// <returns></returns>
        private bool CheckData()
        {
            if (Datas == null)
            {
                return false;
            }

            foreach (var data in Datas)
            {
                bool result = !Datas.Any(i => i.DataList.Count != data.DataList.Count);
                if (!result)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 设置面板和背景
        /// </summary>
        /// <param name="maxIndex"></param>
        private void SetCanvasAndBackground(int maxIndex)
        {
            CanvasPanel.Height = TotalSize;
            CanvasPanel.Width = TotalSize;

            //面板
            ChartCanvas.Height = Size;
            ChartCanvas.Width = Size;
            double canvasX = (TotalSize - Size) / 2;
            Canvas.SetLeft(ChartCanvas, canvasX);
            Canvas.SetTop(ChartCanvas, canvasX);
            CanvasPanel.Children.Add(ChartCanvas);
            //画圈和直线
            var color = BorderBrush;
            double length = Size / 2 / maxIndex;
            for (int i = 0; i < maxIndex; i++)
            {
                double height = length * 2 * (i + 1);
                double left = Size / 2 - length * (i + 1);
                var ellipse = new Ellipse() { Stroke = color, StrokeThickness = 0.5, Height = height, Width = height };
                Canvas.SetLeft(ellipse, left);
                Canvas.SetTop(ellipse, left);

                ChartCanvas.Children.Add(ellipse);
            }
            //暂时设定:4个标题时,画线
            if (Arguments.Count == 3)
            {
                //竖向直线
                Path verticalPath = new Path()
                {
                    Stroke = color,
                    StrokeThickness = 0.2,
                };
                //添加数据
                StreamGeometry geometry = new StreamGeometry();
                geometry.FillRule = FillRule.Nonzero; //声前F0还是F1,现在是F1
                using (StreamGeometryContext ctx = geometry.Open())
                {

                    ctx.BeginFigure(new Point(Size / 2, 0), true, true);

                    ctx.LineTo(new Point(Size / 2, Size), true, false);

                }
                geometry.Freeze();
                verticalPath.Data = geometry;
                ChartCanvas.Children.Add(verticalPath);
                //横向直线
                Path horizontalPath = new Path()
                {
                    Stroke = color,
                    StrokeThickness = 0.2,
                };
                //添加数据
                geometry = new StreamGeometry();
                geometry.FillRule = FillRule.Nonzero; //声前F0还是F1,现在是F1
                using (StreamGeometryContext ctx = geometry.Open())
                {

                    ctx.BeginFigure(new Point(0, Size / 2), true, true);

                    ctx.LineTo(new Point(Size, Size / 2), true, false);

                }
                geometry.Freeze();
                horizontalPath.Data = geometry;
                ChartCanvas.Children.Add(horizontalPath);
            }
        }
        /// <summary>
        /// 分隔角度
        /// </summary>
        private double Angle
        {
            get
            {
                int count = Arguments.Count;
                double angle = 100/count;
                return angle;
            }
        }
    }

    /// <summary>
    /// 类标题
    /// </summary>
    public class ArgumentModel
    {
        public ImageSource IconSource { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// 单组数据
    /// </summary>
    public class ChartItem
    {
        public Brush Color { get; set; }
        List<ChartData> dataList = new List<ChartData>();
        public List<ChartData> DataList
        {
            get { return dataList; }
            set { dataList = value; }
        }
        public object Name { get; set; }
    }

    /// <summary>
    /// 数据
    /// </summary>
    public class ChartData
    {
        public string Name { get; set; }
        public int Data { get; set; }
    }
}

