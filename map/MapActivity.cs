using AndroidX.AppCompat.App;

namespace NueralNetrwork.map
{
    public class MapActivity : AppCompatActivity
    {
        Xamarin.FormsMaps.Init();
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