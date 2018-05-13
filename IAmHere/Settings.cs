using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace IAmHere
{
    public class Settings
    {
        private static Settings _instance = null;
        private static readonly object locker = new Object();
        public string TelNumber;
        private string _trailingMessage = "Salut, je me trouve ici :\n http://maps.google.com/maps?q=";
        Location coordinates;
        

        /*
        private void getCurrentCoordinates()
        {

            lm.LocationsUpdated += delegate (object sender, CLLocationsUpdatedEventArgs e) {
    foreach (CLLocation l in e.Locations)
    {
        Console.WriteLine(l.Coordinate.Latitude.ToString() + ", " + l.Coordinate.Longitude.ToString());
    }
};

            lm.StartUpdatingLocation();
        }
        */
        public string Message
        {
            get
            {
                return (_trailingMessage);
            }
        }
        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (locker)
                    {
                        if (_instance == null)
                            _instance = new Settings();
                    }
                }
                return (_instance);
            }
        }
    }
}