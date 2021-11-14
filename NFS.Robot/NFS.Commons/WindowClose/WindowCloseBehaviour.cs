using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NFS.Commons.WindowClose
{
    public class WindowCloseBehaviour : Behavior<Window>
    {
        public static readonly DependencyProperty CloseProperty =
          DependencyProperty.Register(
          "Close",
          typeof(bool),
          typeof(WindowCloseBehaviour),
          new FrameworkPropertyMetadata(
                    false,
                    OnCloseChanged));

        public bool Close
        {
            get { return (bool)GetValue(CloseProperty); }
            set { SetValue(CloseProperty, value); }
        }

        public static void OnCloseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = ((WindowCloseBehaviour)d).AssociatedObject;
            var newValue = ((bool)e.NewValue);
            if (newValue && window != null)
            {
                window.DialogResult = true;
                window.Close();
            }
        }
    }
}
