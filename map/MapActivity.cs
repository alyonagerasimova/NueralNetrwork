using System;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using AndroidX.AppCompat.App;
using Android.Gms.Common;
using Android.Gms.Location;
using Android.Util;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Platform.Android;

namespace NueralNetrwork.map
{
    [Activity(Label = "Network", Theme = "@style/MainTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MapActivity : AppCompatActivity, IOnMapReadyCallback
    {
        const int RequestLocationId = 0;
        GoogleMap map;
        FusedLocationProviderClient fusedLocationProviderClient;

        readonly string[] LocationPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_maps);

            var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
            fusedLocationProviderClient = LocationServices.GetFusedLocationProviderClient(this);

            // Position position = new Position(36.9628066, -122.0194722);
            // MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            // Map map = new Map(mapSpan);
        }

        protected override void OnStart()
        {
            base.OnStart();
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
                else
                {
                    Console.WriteLine("Location permissions already granted.");
                }
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            InitializeUiSettingsOnMap();
            GetLastLocationFromDevice();

            LatLng location = new LatLng(50.897778, 3.013333);

            MarkerOptions markerOpt1 = new MarkerOptions();
            markerOpt1.SetPosition(location);
            markerOpt1.SetTitle("Vimy Ridge");
            googleMap.AddMarker(markerOpt1);
        }
        
        void InitializeUiSettingsOnMap()
        {
            map.UiSettings.MyLocationButtonEnabled = true;
            map.UiSettings.CompassEnabled = true;
            map.UiSettings.ZoomControlsEnabled = true;
            map.MyLocationEnabled = true;
        }
        
        async Task GetLastLocationFromDevice()
        {
            Android.Locations.Location location = await fusedLocationProviderClient.GetLastLocationAsync();

            if (location == null)
            {
            }
            else
            {
                MarkerOptions markerOpt1 = new MarkerOptions();
                markerOpt1.SetPosition(new LatLng(location.Latitude, location.Longitude));
                map.AddMarker(markerOpt1);
                CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
                builder.Target(new LatLng(location.Latitude, location.Longitude));
                builder.Zoom(15);
                CameraPosition cameraPosition = builder.Build();
                CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
                map.MoveCamera(cameraUpdate);
                Log.Debug("Sample", "The latitude is " + location.Latitude);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (requestCode == RequestLocationId)
            {
                if ((grantResults.Length == 1) && (grantResults[0] == (int)Permission.Granted))
                {
                    Console.WriteLine("Location permissions granted.");
                }
                else
                {
                    Console.WriteLine("Location permissions denied.");
                }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

        //     private MapView mapView;
        // private final Point TARGET_LOCATION = new Point(53.229473, 50.200400);
        // private Point MY_LOCATION = null;
        // private static final int PERMISSIONS_CODE = 109;
        // private MapObjectCollection mapObjects;
        // private DrivingRouter drivingRouter;
        // private DrivingSession drivingSession;
        //
        // @Override
        // protected void onCreate(Bundle savedInstanceState) {
        //     super.onCreate(savedInstanceState);
        //     MapKitFactory.initialize(this);
        //     checkPermission();
        //     setContentView(R.layout.activity_maps);
        //
        //     Location myLocation = MyLocationListener.SetUpLocationListener(this);
        //     mapView = (MapView) findViewById(R.id.map);
        //     String style = "[" +
        //             "  {" +
        //             "    \"featureType\" : \"all\"," +
        //             "    \"stylers\" : {" +
        //             "      \"hue\" : \"1\"," +
        //             "      \"saturation\" : \"0.3\"," +
        //             "      \"lightness\" : \"-0.7\"" +
        //             "    }" +
        //             "  }" +
        //             "]";
        //     mapView.getMap().setMapStyle(style);
        //     mapView.getMap().isZoomGesturesEnabled();
        //
        //     try {
        //         MY_LOCATION = myLocation.getPosition();
        //
        //         mapView.getMap().getMapObjects().addPlacemark(MY_LOCATION,
        //                 ImageProvider.fromResource(this, R.drawable.search_layer_pin_icon_default));
        //         mapView.getMap().getMapObjects().addPlacemark(TARGET_LOCATION,
        //                 ImageProvider.fromResource(this, R.drawable.search_layer_pin_selected_default));
        //
        //         mapView.getMap().move(new CameraPosition(
        //                 MY_LOCATION, 15, 0, 0));
        //         drivingRouter = DirectionsFactory.getInstance().createDrivingRouter();
        //         mapObjects = mapView.getMap().getMapObjects().addCollection();
        //
        //         submitRequest();
        //
        //     } catch (NullPointerException e) {
        //         Log.e("Current location is null. Using defaults.", e.getMessage());
        //         mapView.getMap().move(
        //                 new CameraPosition(TARGET_LOCATION, 14.0f, 0.0f, 0.0f),
        //                 new Animation(Animation.Type.SMOOTH, 0),
        //                 null);
        //         mapView.getMap().getMapObjects().addPlacemark(TARGET_LOCATION);
        //     }
        // }
        //
        // private void checkPermission() {
        //     int permACL = ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION);
        //     int permAFL = ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION);
        //
        //     if (permACL != PackageManager.PERMISSION_GRANTED ||
        //             permAFL != PackageManager.PERMISSION_GRANTED) {
        //
        //         ActivityCompat.requestPermissions(this,
        //                 new String[]{Manifest.permission.ACCESS_COARSE_LOCATION,
        //                         Manifest.permission.ACCESS_FINE_LOCATION}, PERMISSIONS_CODE);
        //     }
        // }
        //
        // @Override
        // protected void onStop() {
        //     super.onStop();
        //     mapView.onStop();
        //     MapKitFactory.getInstance().onStop();
        // }
        //
        // @Override
        // protected void onStart() {
        //     super.onStart();
        //     mapView.onStart();
        //     MapKitFactory.getInstance().onStart();
        // }
        //
        // @Override
        // public void onDrivingRoutes(List<DrivingRoute> routes) {
        //     for (DrivingRoute route : routes) {
        //         mapObjects.addPolyline(route.getGeometry());
        //     }
        // }
        //
        // @Override
        // public void onDrivingRoutesError(@NonNull Error error) {
        //     String errorMessage = getString(R.string.unknown_error_message);
        //     if (error instanceof RemoteError) {
        //         errorMessage = getString(R.string.remote_error_message);
        //     } else if (error instanceof NetworkError) {
        //         errorMessage = getString(R.string.network_error_message);
        //     }
        //
        //     Toast.makeText(this, errorMessage, Toast.LENGTH_LONG).show();
        // }
        //
        // private void submitRequest() {
        //     DrivingOptions drivingOptions = new DrivingOptions();
        //     VehicleOptions vehicleOptions = new VehicleOptions();
        //     ArrayList<RequestPoint> requestPoints = new ArrayList<>();
        //     requestPoints.add(new RequestPoint(
        //             MY_LOCATION,
        //             RequestPointType.WAYPOINT,
        //             null));
        //     requestPoints.add(new RequestPoint(
        //             TARGET_LOCATION,
        //             RequestPointType.WAYPOINT,
        //             null));
        //     drivingSession = drivingRouter.requestRoutes(requestPoints, drivingOptions, vehicleOptions, this);
        // }
    }
}