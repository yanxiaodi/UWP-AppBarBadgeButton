using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace AppBarBadgeButtonSample.Controls
{
    public sealed class AppBarBadgeButton : AppBarButton
    {
        public AppBarBadgeButton()
        {
            this.DefaultStyleKey = typeof(AppBarBadgeButton);
        }

        public string Count
        {
            get { return (string)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Count.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register("Count", typeof(string), typeof(AppBarBadgeButton), new PropertyMetadata("0", OnCountChanged));

        private static void OnCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int count = 0;
            int.TryParse(e.NewValue.ToString(), out count);
            if (count != 0)
            {
                ((AppBarBadgeButton)d).SetValue(BadgeVisibilityProperty, Visibility.Visible);
            }
            else
            {
                ((AppBarBadgeButton)d).SetValue(BadgeVisibilityProperty, Visibility.Collapsed);
            }
        }


        public Visibility BadgeVisibility
        {
            get { return (Visibility)GetValue(BadgeVisibilityProperty); }
            set { SetValue(BadgeVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BadgeVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BadgeVisibilityProperty =
            DependencyProperty.Register("BadgeVisibility", typeof(Visibility), typeof(AppBarBadgeButton), new PropertyMetadata(Visibility.Collapsed, null));


    }
}
