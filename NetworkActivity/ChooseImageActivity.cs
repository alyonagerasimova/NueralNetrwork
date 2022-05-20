using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using NueralNetrwork;

namespace NueralNetrwork.NetworkActivity
{
    public class ChooseImageActivity: AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_images_upload);
        }
    }
}