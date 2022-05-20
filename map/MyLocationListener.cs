using Android.OS;

namespace NueralNetrwork.map
{
    public class MyLocationListener 
    {
        // static Location imHere;
        // Context context;
        //
        // public MyLocationListener(Context context){
        //     this.context = context;
        // }
        //
        // public static Location SetUpLocationListener(Context context) {
        //     try{
        //         LocationManager locationManager;
        //         locationManager = MapKitFactory.getInstance().createLocationManager();
        //         LocationListener locationListener = new MyLocationListener(null);
        //         locationManager.subscribeForLocationUpdates(0.0, 1000,5.0, false, FilteringMode.OFF, locationListener);
        //         locationManager.requestSingleUpdate(locationListener);
        //         imHere = LocationManagerUtils.getLastKnownLocation();
        //         return imHere;
        //     }catch (Exception e){
        //         e.printStackTrace();
        //         return null;
        //     }
        // }
        //
        // @Override
        // public void onLocationUpdated(@NonNull Location location) {
        //     imHere = location;
        // }
        //
        // @Override
        // public void onLocationStatusUpdated(@NonNull LocationStatus locationStatus) {
        // }
    }
}