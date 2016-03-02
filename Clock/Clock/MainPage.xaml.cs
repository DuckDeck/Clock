using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Clock
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        DispatcherTimer timerDate = new DispatcherTimer() { Interval = TimeSpan.FromHours(1) };
        public MainPage()
        {
            this.InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Start();
            timerDate.Tick += TimerDate_Tick;
            timerDate.Start();
            tbxDate.Text = DateTime.Now.ToString("yyyy:MM:dd") + " " + DateTime.Now.DayOfWeek.ToString().Substring(0, 3);
        }

        private void TimerDate_Tick(object sender, object e)
        {
            tbxDate.Text = DateTime.Now.ToString("yyyy:MM:dd") +" " + DateTime.Now.DayOfWeek.ToString().Substring(0,3);
        }

        private void Timer_Tick(object sender, object e)
        {
            TimerDisplayer.Time = DateTime.Now;
        }

        private void MiliSecondHandCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            MiliSecondHandStoryboard.Begin();
            MiliSecondHandStoryboard.Seek(DateTime.Now.TimeOfDay);
        }

        private void TenthsSecondHandCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            TenthsSecondHandStoryboard.Begin();
            TenthsSecondHandStoryboard.Seek(DateTime.Now.TimeOfDay);
        }

     

        private void SecondsHandCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            SecondsHandStoryboard.Begin();
            SecondsHandStoryboard.Seek(DateTime.Now.TimeOfDay);
        }
        private void MinutesHandCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            MinutesHandStoryboard.Begin();
            MinutesHandStoryboard.Seek(DateTime.Now.TimeOfDay);
        }
        private void HoursHandCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            HoursHandStoryboard.Begin();
            HoursHandStoryboard.Seek(DateTime.Now.TimeOfDay);
        }
    }
}
