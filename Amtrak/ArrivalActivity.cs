using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Amtrak
{
    [Activity(Label = "ArrivalActivity")]
    public class ArrivalActivity : Android.App.Activity
    {
        TextView arrival;
        private ISharedPreferences prefs = Application.Context.GetSharedPreferences("APP_DATA", FileCreationMode.Private);

        int h, m, l;
        string hours, minutes, length;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_arrival);
            // Create your application here
            arrival = FindViewById<TextView>(Resource.Id.txtViewArrival);
            hours = prefs.GetString("hours", "00");
            minutes = prefs.GetString("minutes", "00");
            length = prefs.GetString("length", "0");
            addTime();
        }

        private void addTime()
        {

            try
            {
                h = int.Parse(hours);
                m = int.Parse(minutes);
                l = int.Parse(length);
            }catch(Exception e)
            {

            }
            
            arrival.Text = Convert.ToString(25 % 23);
            int tempH = 0, tempM = 0;
            if (l % 60 == 0)
            {
                tempH = 1 / 60;
                if (h + tempH > 23)
                {
                    h = (tempH + h) - 24;
                    if (h <= 12)
                    {
                        arrival.Text = "0" + Convert.ToString(h);
                    }
                    else
                    {
                        arrival.Text = Convert.ToString(h);
                    }
                    
                    
                }
                else
                {
                    h += tempH;
                    arrival.Text = Convert.ToString(h);
                }
            }
            
        }
        
    }
}