﻿using Android.OS;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;
using Google.Android.Material.BottomNavigation;
using AndroidX.AppCompat.App;

namespace NueralNetrwork.NetworkActivity
{
    public class MainPageActivity: AppCompatActivity
    {
    //     private BottomNavigationView.OnNavigationItemSelectedListener mOnNavigationItemSelectedListener
    //         = new BottomNavigationView.OnNavigationItemSelectedListener() {
    //
    //             @Override
    //             public boolean onNavigationItemSelected(@NonNull MenuItem item) {
    //             return false;
    //         }
    // };
    
    private void loadFragment(Fragment fragment) {
        FragmentTransaction ft = getSupportFragmentManager().beginTransaction();
        ft.Replace(Resource.Id.rlContainer, fragment);
        ft.Commit();
    }
    
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.bottom_activity);
            BottomNavigationView bottomNav = FindViewById(Resource.Id.bottom_navigation);
        }
    }
}