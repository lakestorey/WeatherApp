using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class WeatherScreen : UserControl
    {
        //brushes
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Font arial8 = new Font("Arial", 8);
        Font arial12 = new Font("Arial", 12);
        Font arial28 = new Font("Arial", 28);

        //set up temp strings to hold info
        DateTime currentTime;
        DateTime currentDate;
        string currentTemp = "";
        string currentHigh = "";
        string currentLow = "";
        string currentCondition = "";
        int currentClouds;
        string Location = "";
        Bitmap currentWeather;

        //day 2
        DateTime day2Date;
        string day2High = "";
        string day2Low = "";
        string day2Condition = "";
        int day2Clouds;
        string day2POP = "";
        Bitmap day2Weather;

        //day3
        DateTime day3Date;
        string day3High = "";
        string day3Low = "";
        string day3Condition = "";
        int day3Clouds;
        string day3POP = "";
        Bitmap day3Weather;

        public WeatherScreen()
        {
            InitializeComponent();
        }

        //resize images
        Bitmap cloudyImage = new Bitmap(Properties.Resources.Cloudy, new Size(50, 50));
        Bitmap sunnyImage = new Bitmap(Properties.Resources.Sunny, new Size(50, 50));
        Bitmap rainyImage = new Bitmap(Properties.Resources.Storming, new Size(50, 50));

        private void WeatherScreen_Load(object sender, EventArgs e)
        {
            //extract info from the list of days
            currentTime = DateTime.Now;
            currentDate = DateTime.Today;
            currentTemp = Form1.days[0].currentTemp;
            currentHigh = Form1.days[0].tempHigh;
            currentLow = Form1.days[0].tempLow;
            currentCondition = Form1.days[0].condition;
            currentClouds = Convert.ToInt16(currentCondition);
            Location = Form1.days[0].location;

            //decide what condition to display
            if (currentClouds >= 200 && currentClouds <= 781)
            {
                currentWeather = rainyImage;
            }
            if (currentClouds == 800)
            {
                currentWeather = sunnyImage;
            }
            if (currentClouds >= 801 && currentClouds <= 962)
            {
                currentWeather = cloudyImage;
            }

            //day 2
            day2Date = currentDate.AddDays(1);
            day2High = Form1.days[1].tempHigh;
            day2Low = Form1.days[1].tempLow;
            day2Condition = Form1.days[1].condition;
            day2Clouds = Convert.ToInt16(day2Condition);
            day2POP = Form1.days[1].precipitation;

            if (day2Clouds >= 200 && day2Clouds <= 781)
            {
                day2Weather = rainyImage;
            }
            if (day2Clouds == 800)
            {
                day2Weather = sunnyImage;
            }
            if (day2Clouds >= 801 && day2Clouds <= 962)
            {
                day2Weather = cloudyImage;
            }

            //day 3
            day3Date = currentDate.AddDays(2);
            day3High = Form1.days[2].tempHigh;
            day3Low = Form1.days[2].tempLow;
            day3Condition = Form1.days[2].condition;
            day3Clouds = Convert.ToInt16(day3Condition);
            day3POP = Form1.days[2].precipitation;

            if (day3Clouds >= 200 && day3Clouds <= 781)
            {
                day3Weather = Properties.Resources.Storming;
            }
            if (day3Clouds == 800)
            {
                day3Weather = Properties.Resources.Sunny;
            }
            if (day3Clouds >= 801 && day3Clouds <= 962)
            {
                day3Weather = Properties.Resources.Cloudy;
            }
        }

        private void WeatherScreen_Paint(object sender, PaintEventArgs e)
        {
            //headings
            e.Graphics.DrawString(Location, arial12, whiteBrush, this.Width - 75, 5);
            e.Graphics.DrawString(currentTime.ToString("dddd MMMM d"), arial28, whiteBrush, this.Width / 2 - 150, 5);

            //day 1
            e.Graphics.DrawString(currentDate.ToString("dddd MMMM d"), arial8, whiteBrush, 10, 25);
            e.Graphics.DrawImage(currentWeather, 20, 50);
            e.Graphics.DrawString(currentTemp + "°", arial12, whiteBrush, 20, 90);
            e.Graphics.DrawString("High: " + currentHigh + "°", arial8, whiteBrush, 20, 110);
            e.Graphics.DrawString("Low: " + currentLow + "°", arial8, whiteBrush, 20, 120);

            //day 2
            e.Graphics.DrawString(day2Date.ToString("dddd MMMM d"), arial8, whiteBrush, 150, 50);
            e.Graphics.DrawImage(day2Weather, 175, 75);
            e.Graphics.DrawString("High: " + day2High + "°", arial8, whiteBrush, 165, 125);
            e.Graphics.DrawString("Low: " + day2Low + "°", arial8, whiteBrush, 165, 135);

            //day 2
            e.Graphics.DrawString(day3Date.ToString("dddd MMMM d"), arial8, whiteBrush, 300, 50);
            e.Graphics.DrawImage(day2Weather, 325, 75);
            e.Graphics.DrawString("High: " + day3High + "°", arial8, whiteBrush, 315, 125);
            e.Graphics.DrawString("Low: " + day3Low + "°", arial8, whiteBrush, 315, 135);
        }
    }
}
