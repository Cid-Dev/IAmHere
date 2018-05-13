using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Locations;

namespace IAmHere
{

    [Service]
    public class GPSService : Service, ILocationListener
    {
        private string _location = string.Empty;
        //public string Location { get { return (_location); } }
        public const string LOCATION_UPDATE_ACTION = "LOCATION_UPDATED";
        private Location _currentLocation;
        IBinder _binder;
        protected LocationManager _locationManager = (LocationManager)Application.Context.GetSystemService(LocationService);
        public override IBinder OnBind(Intent intent)
        {
            _binder = new GPSServiceBinder(this);
            return _binder;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            return StartCommandResult.Sticky;
        }

        public void StartLocationUpdates()
        {
            Criteria criteriaForGPSService = new Criteria
            {
                //A constant indicating an approximate accuracy  
                Accuracy = Accuracy.Coarse,
                PowerRequirement = Power.Medium
            };

            var locationProvider = _locationManager.GetBestProvider(criteriaForGPSService, true);
            _locationManager.RequestLocationUpdates(locationProvider, 0, 0, this);

        }

        public event EventHandler<LocationChangedEventArgs> LocationChanged = delegate { };
        public void OnLocationChanged(Location location)
        {
            _currentLocation = location;

            if (_currentLocation == null)
                _location = "Unable to determine your location.";
            else
            {
                _location = String.Format("{0},{1}", _currentLocation.Latitude.ToString().Replace(',', '.'), _currentLocation.Longitude.ToString().Replace(',', '.'));

                Intent intent = new Intent(this, typeof(MainActivity.GPSServiceReciever));
                intent.SetAction(MainActivity.GPSServiceReciever.LOCATION_UPDATED);
                intent.AddCategory(Intent.CategoryDefault);
                intent.PutExtra("Location", _location);
                SendBroadcast(intent);
            }
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
            //TO DO:  
        }

        public void OnProviderDisabled(string provider)
        {
            //TO DO:  
        }

        public void OnProviderEnabled(string provider)
        {
            //TO DO:  
        }
    }

    public class GPSServiceBinder : Binder
    {
        public GPSService Service { get { return this.LocService; } }
        protected GPSService LocService;
        public bool IsBound { get; set; }
        public GPSServiceBinder(GPSService service) { this.LocService = service; }
    }

    public class GPSServiceConnection : Java.Lang.Object, IServiceConnection
    {

        GPSServiceBinder _binder;

        public event Action Connected;
        public GPSServiceConnection(GPSServiceBinder binder)
        {
            if (binder != null)
                _binder = binder;
        }

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            GPSServiceBinder serviceBinder = (GPSServiceBinder)service;

            if (serviceBinder != null)
            {
                this._binder = serviceBinder;
                this._binder.IsBound = true;
                serviceBinder.Service.StartLocationUpdates();
                if (Connected != null)
                    Connected.Invoke();
            }
        }
        public void OnServiceDisconnected(ComponentName name) { this._binder.IsBound = false; }
    }
}