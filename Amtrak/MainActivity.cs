using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using System;

namespace Amtrak
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnSubmit;
        EditText inputHours, inputMinutes, inputLength;
        private ISharedPreferences prefs = Application.Context.GetSharedPreferences("APP_DATA", FileCreationMode.Private);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Intent arrivalActivity = new Intent(this, typeof(ArrivalActivity));
            btnSubmit = FindViewById<Button>(Resource.Id.btnSubmit);
            inputHours = FindViewById<EditText>(Resource.Id.inputHours);
            inputMinutes = FindViewById<EditText>(Resource.Id.inputMinutes);
            inputLength = FindViewById<EditText>(Resource.Id.inputLength);                        

            btnSubmit.Click += delegate
            {
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutString("hours", inputHours.Text);
                editor.PutString("minutes", inputMinutes.Text);
                editor.PutString("length", inputLength.Text);

                //write key pairs to SP
                editor.Apply();
                StartActivity(arrivalActivity);
            };

            inputHours.TextChanged += delegate
            {
                try
                {
                    if (int.Parse(inputHours.Text.ToString()) > 23)
                    {
                        Toast.MakeText(this, "Hours must be equal to 23 or smaller", ToastLength.Short).Show();
                    }
                }
                catch(Exception e)
                {

                }
                
            };

            inputMinutes.TextChanged += delegate
            {
                try
                {
                    if (int.Parse(inputMinutes.Text.ToString()) > 59)
                    {
                        Toast.MakeText(this, "Minutes must be equal to 59 or smaller", ToastLength.Short).Show();
                    }
                }
                catch (Exception e)
                {

                }
                
            };

            inputLength.TextChanged += delegate
            {
                try
                {
                    if (int.Parse(inputLength.Text.ToString()) > 1500)
                    {
                        Toast.MakeText(this, "Length must be equal to 1500 or smaller", ToastLength.Short).Show();
                    }
                }
                catch (Exception e)
                {
                    
                }

            };
        }
    }
}