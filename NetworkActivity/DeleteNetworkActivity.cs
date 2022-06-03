using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Database.Sqlite;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using Microsoft.Data.Sqlite;
using NueralNetrwork.NetworkActivity;
using System;
using Xamarin.Forms;
using Button = Android.Widget.Button;
using ListView = Android.Widget.ListView;
using View = Android.Views.View;

namespace NueralNetrwork.Network.db
{
    [Activity(Label = "@string/app_name_deleting", Theme = "@style/AppTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class DeleteNetworkActivity : AppCompatActivity
    {
        private EditText nameBox;
        private EditText yearBox;
        private Button delButton;
        private Button saveButton;
        private ListView userList;
        private SaveNetwork databaseHelper;
        private SaveNetwork sqlHelper;
        private SQLiteDatabase db;
        private Cursor userCursor;
        private long userId = 0;
        private TextView header;
        private SimpleCursorAdapter userAdapter;
        private SqliteConnection destination;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_delete);

            nameBox = (EditText)FindViewById(Resource.Id.name);
            delButton = (Button)FindViewById(Resource.Id.delete);
            userList = (ListView)FindViewById(Resource.Id.list);
            nameBox = (EditText)FindViewById(Resource.Id.name);
            delButton = (Button)FindViewById(Resource.Id.deleteButton);
            header = (TextView)FindViewById(Resource.Id.header);
            userList = (ListView)FindViewById(Resource.Id.list);
            Button button = (Button)FindViewById(Resource.Id.delete);
            button.Click += (o, e) =>
            {};
        }
        public void onResume()
        {
            using (var source = new SqliteConnection())
            {
                source.Open();
                destination.Open();
                source.BackupDatabase(destination);
            }
        }

        public void delete(View view)
        {
            db.Delete(SaveNetwork.TABLE, "_id = ?", new String[] { });
            Intent intent = new Intent(this, typeof(DeleteNetworkActivity));
            StartActivity(intent);
        }

        private void goHome()
        {
            // закрываем подключение
            db.Close();
            // переход к главной activity
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(Intent.Flags & ActivityFlags.ClearTop | Intent.Flags & ActivityFlags.SingleTop);
            StartActivity(intent);
        }

        public void delete(MenuItem item)
        {
        }

    }
}