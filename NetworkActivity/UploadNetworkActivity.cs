using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Database.Sqlite;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using NueralNetrwork.Network.db;

namespace NueralNetrwork.NetworkActivity
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class UploadNetworkActivity : AppCompatActivity
    {
        private EditText nameBox;
        private SaveNetwork databaseHelper;
        private SQLiteDatabase db;
        private Cursor userCursor;
        private long userId = 0;
        private TextView header;
        private SimpleCursorAdapter userAdapter;
        private ListView listView;
        private string m_Text = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_upload_delete_network);
            List<Network.Network> image_details = SaveNetwork.getListData();
            header = (TextView)FindViewById(Resource.Id.header);
            listView = (ListView)FindViewById(Resource.Id.listView);
            Button button = (Button)FindViewById(Resource.Id.upload);
            button.Click += (o, e) =>
            {
                Intent intent = new Intent(this, typeof(NetworkActivity));
                StartActivity(intent);
            };
            /*databaseHelper = new SaveNetwork(this);
            Bundle extras = getIntent().getExtras();
            if (extras != null)
            {
                userId = extras.GetLong("id");
            }

            listView.Click += ((a, v, position, id) =>
            {
                Object o = listView.getItemAtPosition(position);
                Networkk.Network network = (Networkk.Network)o;
                userId = id;
                if (extras != null)
                {
                    userId = extras.getLong("id");
                }

                // если 0, то добавление
                if (userId > 0)
                {
                    // получаем элемент по id из бд
                    userCursor = db.rawQuery("select * from " + SaveNetwork.TABLE + " where " +
                                             SaveNetwork.COLUMN_NAME + "=?", new string[] { string.valueOf(userId) });
                    userCursor.moveToFirst();
                    nameBox.SetText(userCursor.getString(1));
                    userCursor.close();
                }
            });
        }

        protected override void OnResume()
        {
            base.OnResume();
            db = databaseHelper.getReadableDatabase();

            //получаем данные из бд в виде курсора
            userCursor = db.rawQuery("select * from " + SaveNetwork.TABLE, null);
            // определяем, какие столбцы из курсора будут выводиться в ListView
            string[] headers = new string[]{SaveNetwork.COLUMN_NAME, SaveNetwork.COLUMN_NUMBER_HIDDEN,
                SaveNetwork.COLUMN_NUMBER_LEARNING, SaveNetwork.COLUMN_NUMBER_CYCLE, SaveNetwork.COLUMN_NUMBER_ERROR};
            // создаем адаптер, передаем в него курсор
            userAdapter = new SimpleCursorAdapter(this, Xamarin.Android.R.layout.two_line_list_item,
                userCursor, headers, new int[]{Android.Resource.Id.Text1, Android.Resource.Id.Text2}, 0);
            header.SetText("Найдено элементов: " + userCursor.getCount());
            listView.setAdapter(new CustomAdapterNetwork(this, userAdapter));
        }*/
        }
    }


}