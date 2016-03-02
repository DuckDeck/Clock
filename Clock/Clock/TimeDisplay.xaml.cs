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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Clock
{
    public sealed partial class TimeDisplay : UserControl
    {
        DateTime? time;
        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(500) };
        public TimeDisplay()
        {
            this.InitializeComponent();
            time = null;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            this.tbxSecondColon.Visibility = this.tbxSecondColon.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
        public DateTime? Time
        {
            get { return this.time; }
            set
            {
                this.time = value;
                // if the time is null
                if (this.time == null)
                {
                    // Clear everything
                    this.TimeRun.Text = null;
                    this.SecondsRun.Text = null;
                    //this.AMTextBlock.Opacity = .1;
                    //this.PMTextBlock.Opacity = .1;
                    return;
                }
                string formatString = "HH:mm";
                // The hour needs a leading space if it ends up being only one digit
                // when show 24 hours , the hour < 10 need a space or do not show 24 hours ,when time between 12-22 and  0-10  need a space
                //if ((this.time.Value.Hour < 10) || ((this.time.Value.Hour % 12 < 10 && this.time.Value.Hour % 12 > 0)))
                //    formatString = " " + formatString;
                this.TimeRun.Text = this.time.Value.ToString(formatString);
                 this.SecondsRun.Text = this.time.Value.ToString("ss");
            }

        }
    }
}
