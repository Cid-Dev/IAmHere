using Android.App;
using Android.Widget;
using Android.OS;
using Android.Telephony;
using Android.Content;

namespace IAmHere
{
    [Activity(Label = "IAmHere", MainLauncher = true)]
    public class MainActivity : Activity
    {
        GPSServiceBinder _binder;
        GPSServiceConnection _gpsServiceConnection;
        Intent _gpsServiceIntent;
        private GPSServiceReciever _receiver;
        public static MainActivity Instance;
        private Settings settings;
        private string coordinates;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Instance = this;
            settings = Settings.Instance;
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            RegisterService();
            var sendSMS = FindViewById<Button>(Resource.Id.sendSMS);
            var phoneNumber = FindViewById<EditText>(Resource.Id.editPhone);
            sendSMS.Click += (sender, e) => {
                if (phoneNumber.Text != "")
                    SmsManager.Default.SendTextMessage(phoneNumber.Text, null, settings.Message + coordinates, null, null);
            };
        }

        private void RegisterService()
        {
            _gpsServiceConnection = new GPSServiceConnection(_binder);
            _gpsServiceIntent = new Intent(Application.Context, typeof(GPSService));
            BindService(_gpsServiceIntent, _gpsServiceConnection, Bind.AutoCreate);
        }
        
        private void RegisterBroadcastReceiver()
        {
            IntentFilter filter = new IntentFilter(GPSServiceReciever.LOCATION_UPDATED);
            filter.AddCategory(Intent.CategoryDefault);
            _receiver = new GPSServiceReciever();
            RegisterReceiver(_receiver, filter);
        }

        private void UnRegisterBroadcastReceiver()
        {
            UnregisterReceiver(_receiver);
        }
        
        public void UpdateCoor(Intent intent)
        {
            coordinates = intent.GetStringExtra("Location");
        }
        
        protected override void OnResume()
        {
            base.OnResume();
            RegisterBroadcastReceiver();
        }

        protected override void OnPause()
        {
            base.OnPause();
            UnRegisterBroadcastReceiver();
        }
        
        [BroadcastReceiver]
        internal class GPSServiceReciever : BroadcastReceiver
        {
            public static readonly string LOCATION_UPDATED = "LOCATION_UPDATED";
            public override void OnReceive(Context context, Intent intent)
            {
                if (intent.Action.Equals(LOCATION_UPDATED))
                {
                    Instance.UpdateCoor(intent);
                }
            }
        }
        
    }
}