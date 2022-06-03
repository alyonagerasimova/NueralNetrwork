using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using System.Drawing;
using Android.OS;
using AndroidX.AppCompat.App;
using NueralNetrwork.Network.pictureService;
using Xamarin.Forms;
using Android.Graphics;
using Android.Graphics.Drawables;
using Image = NueralNetrwork.Network.Image;
using ListView = Android.Widget.ListView;

namespace NueralNetrwork.NetworkActivity
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class ListImagesActivity : AppCompatActivity
    {
        public static Drawable getDrawable()
        {
            return drawable;
        }

        private static Drawable drawable = null;

        private List<Image> list = new List<Image>();
        private ListView listView;

        public static BitmapDrawable getDrawableForTrain()
        {
            return drawableForTrain;
        }

        private static BitmapDrawable drawableForTrain = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_images_upload);
            List<Image> image_details = getListData();
            listView = (ListView)FindViewById(Resource.Id.listView);
            listView.SetAdapter(new CustomAdapterImages(this, image_details));
            listView.ItemClick += (sender, e) =>
            {
                Object o = listView.GetItemIdAtPosition(e.Position);
                Image image = (Image) o;
                Serialization serialization = new Serialization(this);
                drawable = serialization.getMipmapResIdByName(image.getFlagName());
                drawableForTrain =  serialization.readImage(image.getFlagName());
                Intent intent = new Intent(this, typeof(NetworkActivity));
                StartActivity(intent);
            };
        }

        private async void LstProducts_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var selectedProduct = (Image)e.Item;
            }
            catch (Exception ex)
            {
            }
        }

        private List<Image> getListData()
        {
            Image arabA = new Image("Арабская A", "arabic_a");
            Image arabB = new Image("Арабская B", "NueralNetrwork.Images.arabic_b.png");
            Image arabC = new Image("Арабская C", "arabic_c");
            Image arabD = new Image("Арабская D", "arabic_d");
            Image arabE = new Image("Арабская E", "arabic_e");
            Image arabF = new Image("Арабская F", "arabic_f");
            Image arabG = new Image("Арабская G", "arabic_g");
            Image arabH = new Image("Арабская H", "arabic_h");
            Image arabI = new Image("Арабская I", "arabic_i");
            Image arabJ = new Image("Арабская J", "arabic_j");
            Image arabK = new Image("Арабская K", "arabic_k");
            Image arabL = new Image("Арабская L", "arabic_l");
            Image arabM = new Image("Арабская M", "arabic_m");
            Image arabN = new Image("Арабская N", "arabic_n");
            Image arabO = new Image("Арабская O", "arabic_o");
            Image arabP = new Image("Арабская P", "arabic_p");
            Image arabQ = new Image("Арабская Q", "arabic_q");
            Image arabR = new Image("Арабская R", "arabic_r");
            Image arabS = new Image("Арабская S", "arabic_s");
            Image arabT = new Image("Арабская T", "arabic_t");
            Image arabU = new Image("Арабская U", "arabic_u");
            Image arabV = new Image("Арабская V", "arabic_v");
            Image arabW = new Image("Арабская W", "arabic_w");
            Image arabX = new Image("Арабская X", "arabic_x");
            Image arabY = new Image("Арабская Y", "arabic_y");
            Image arabZ = new Image("Арабская Z", "arabic_z");
            list.Add(arabA);
            list.Add(arabB);
            list.Add(arabC);
            list.Add(arabD);
            list.Add(arabE);
            list.Add(arabF);
            list.Add(arabG);
            list.Add(arabH);
            list.Add(arabI);
            list.Add(arabJ);
            list.Add(arabK);
            list.Add(arabL);
            list.Add(arabM);
            list.Add(arabN);
            list.Add(arabO);
            list.Add(arabP);
            list.Add(arabQ);
            list.Add(arabR);
            list.Add(arabS);
            list.Add(arabT);
            list.Add(arabU);
            list.Add(arabV);
            list.Add(arabW);
            list.Add(arabX);
            list.Add(arabY);
            list.Add(arabZ);
            Image printedA = new Image("Печатная A", "printed_a");
            Image printedB = new Image("Печатная B", "printed_b");
            Image printedC = new Image("Печатная C", "printed_c");
            Image printedD = new Image("Печатная D", "printed_d");
            Image printedE = new Image("Печатная E", "printed_e");
            Image printedF = new Image("Печатная F", "printed_f");
            Image printedG = new Image("Печатная G", "printed_g");
            Image printedH = new Image("Печатная H", "printed_h");
            Image printedI = new Image("Печатная I", "printed_i");
            Image printedJ = new Image("Печатная J", "printed_j");
            Image printedK = new Image("Печатная K", "printed_k");
            Image printedL = new Image("Печатная L", "printed_l");
            Image printedM = new Image("Печатная M", "printed_m");
            Image printedN = new Image("Печатная N", "printed_n");
            Image printedO = new Image("Печатная O", "printed_o");
            Image printedP = new Image("Печатная P", "printed_p");
            Image printedQ = new Image("Печатная Q", "printed_q");
            Image printedR = new Image("Печатная R", "printed_r");
            Image printedS = new Image("Печатная S", "printed_s");
            Image printedT = new Image("Печатная T", "printed_t");
            Image printedU = new Image("Печатная U", "printed_u");
            Image printedV = new Image("Печатная V", "printed_v");
            Image printedW = new Image("Печатная W", "printed_w");
            Image printedX = new Image("Печатная X", "printed_x");
            Image printedY = new Image("Печатная Y", "printed_y");
            Image printedZ = new Image("Печатная Z", "printed_z");
            list.Add(printedA);
            list.Add(printedB);
            list.Add(printedC);
            list.Add(printedD);
            list.Add(printedE);
            list.Add(printedF);
            list.Add(printedG);
            list.Add(printedH);
            list.Add(printedI);
            list.Add(printedJ);
            list.Add(printedK);
            list.Add(printedL);
            list.Add(printedM);
            list.Add(printedN);
            list.Add(printedO);
            list.Add(printedP);
            list.Add(printedQ);
            list.Add(printedR);
            list.Add(printedS);
            list.Add(printedT);
            list.Add(printedU);
            list.Add(printedV);
            list.Add(printedW);
            list.Add(printedX);
            list.Add(printedY);
            list.Add(printedZ);
            return list;
        }
    }
};