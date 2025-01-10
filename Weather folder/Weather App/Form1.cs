using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using static System.Net.WebRequestMethods;


namespace Weather_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string APIKey = "9cf74586de1f28ab0b141729defa7bf9";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getWeather();
        }
        void getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", NTBCity.Text, APIKey);
                Console.WriteLine(url);
                var json = web.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                picIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon.ToString() + ".png";
                labCondition.Text = Info.weather[0].main;
                labDetails.Text = Info.weather[0].description;
                labPressure.Text = Info.main.pressure.ToString();
                labSunrise.Text = convertDateTime(Info.sys.sunrise).ToShortTimeString();
                labSunset.Text = convertDateTime(Info.sys.sunset).ToShortTimeString();
                labWindSpeed.Text = Info.wind.speed.ToString();
            }
        }
        DateTime convertDateTime(long sec)
        {
            DateTime day = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(sec).ToLocalTime();
            return day;
        }
    }
}
