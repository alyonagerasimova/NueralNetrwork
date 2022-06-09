using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Database;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Method;
using Android.Text.Util;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Lifecycle;
using Java.Lang;
using NueralNetrwork.map;
using NueralNetrwork.Network;
using NueralNetrwork.Network.db;
using NueralNetrwork.NetworkActivity;
using NueralNetrwork.Network.pictureService;
using NueralNetrwork.ui;


namespace NueralNetrwork.NetworkActivity
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class NetworkActivity : AppCompatActivity, Android.Text.ITextWatcher
    {
        private ImageView locationIcon;

        private Validation validation;

        private EditText numberHiddenEditText;
        private EditText numberCycleEditText;
        private EditText learningRateEditText;
        private EditText errorEditText;
        private Button imageButton;
        private static Button recognizeButton;
        private static Button buttonSave;
        private static Button buttonDelete;
        private static Button button_create_network;
        private static Button buttonUpload;

        public static void setNumberHidden(string numberHidden)
        {
            NetworkActivity.numberHidden = numberHidden;
        }

        private static string numberHidden;

        public static void setNumberCycle(string numberCycle)
        {
            NetworkActivity.numberCycle = numberCycle;
        }

        private static string numberCycle;

        public static void setLearningRate(string learningRate)
        {
            NetworkActivity.learningRate = learningRate;
        }

        private static string learningRate;

        public static void setError(string error)
        {
            NetworkActivity.error = error;
        }

        private static string error;
        private static string IRPROP = "IRProp";
        private static string RPROP = "RProp";
        private static string BACKPROP = "BackProp";
        private Serialization serialization = null;

        private static string flagAlgorithm;

        private static int flagTrain = 0;

        public static string getFlagAlgorithm()
        {
            return flagAlgorithm;
        }

        public static List<double[]> getPatterns()
        {
            return patterns;
        }

        private static List<double[]> patterns = new List<double[]>();

        public static ImageView getImageForRecognize()
        {
            return imageForRecognize;
        }

        private static ImageView imageForRecognize = null;

        private static ImageView imageForView = null;
        private RadioGroup radioGroup;
        private readonly int pick_image = 1;

        private SaveNetwork databaseHelper;

        private void readInputValuesForNetwork()
        {
            numberHidden = numberHiddenEditText.Text.ToString().Trim();
            numberCycle = numberCycleEditText.Text.ToString().Trim();
            learningRate = learningRateEditText.Text.ToString().Trim();
            error = errorEditText.Text.ToString().Trim();
        }

        private void init()
        {
            numberHiddenEditText = (EditText)FindViewById(Resource.Id.filedNumberHidden);
            numberCycleEditText = (EditText)FindViewById(Resource.Id.filedNumberCycle);
            learningRateEditText = (EditText)FindViewById(Resource.Id.filedCoeffStudy);
            errorEditText = (EditText)FindViewById(Resource.Id.filedError);
            recognizeButton = (Button)FindViewById(Resource.Id.recognizeButton);
            radioGroup = (RadioGroup)FindViewById(Resource.Id.radioGroup);
            imageButton = (Button)FindViewById(Resource.Id.imageButtonUpload);
            imageForView = (ImageView)FindViewById(Resource.Id.imageButton);
            imageForRecognize = (ImageView)FindViewById(Resource.Id.imageButton);
            locationIcon = (ImageView)FindViewById(Resource.Id.locationIcon);
            buttonSave = (Button)FindViewById(Resource.Id.buttonSave);
            buttonDelete = (Button)FindViewById(Resource.Id.buttonDelete);
            button_create_network = (Button)FindViewById(Resource.Id.button_create_network);
            buttonUpload = (Button)FindViewById(Resource.Id.buttonUpload);    
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // string MAPKIT_API_KEY = "5ec3a1f0-9379-4338-8cdd-676426193383";
            // MapKitFactory.setApiKey(MAPKIT_API_KEY);
            serialization = new Serialization(this);
            // binding = ActivityNetworkBinding.inflate(getLayoutInflater());
            SetContentView(Resource.Layout.activity_network);
            try
            {
                init();
            }
            catch (IOException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            if (ListImagesActivity.getDrawable() != null)
            {
                imageForView.SetImageDrawable(ListImagesActivity.getDrawable());
                imageForView.SetScaleType(ImageView.ScaleType.FitXy);
            }

            if (ListImagesActivity.getDrawableForTrain() != null)
            {
                imageForRecognize.SetImageDrawable(ListImagesActivity.getDrawableForTrain());
                imageForRecognize.SetScaleType(ImageView.ScaleType.FitXy);
            }
            
            ITextWatcher watcher = null;
            buttonUpload.Click += (o, e) =>
            {
                Intent intent = new Intent(this, typeof(UploadActivity));
                StartActivity(intent);
            };

            buttonSave.Click += (o, e) =>
            {
                Network.Network.setNumberHiddenNeurons(Int32.Parse(numberHidden));
                if (numberCycle != null && !numberCycle.Equals(""))
                    Network.Network.setNumberCycles(Int32.Parse(numberCycle));
                if (error != null && !error.Equals(""))
                {
                    Network.Network.setError(double.Parse(error));
                }

                UploadNetworkActivity uploadNetworkActivity = new UploadNetworkActivity();
                SaveNetwork.saveNewNetwork(NetworkDataSource.getNetwork());

                Toast.MakeText(this, Resource.String.network_saved, ToastLength.Short).Show();
                Console.WriteLine("Все ок!");
            };
            buttonDelete.Click += (o, e) =>
            {
                Intent intent = new Intent(this, typeof(DeleteNetworkActivity));
                StartActivity(intent);
            };

            button_create_network.Click += (o, e) =>
            {
                readInputValuesForNetwork();
                if ((!numberHidden.Equals("") && !numberCycle.Equals("") && !learningRate.Equals("") && !error.Equals(""
                    )) ||
                    (!numberHidden.Equals("") && !numberCycle.Equals("") && !learningRate.Equals("")) ||
                    (!numberHidden.Equals("") && !numberCycle.Equals("") && !error.Equals("")) || (
                        !numberHidden.Equals("") && !numberCycle.Equals("")) ||
                    (!numberHidden.Equals("") || !numberCycle.Equals("") || !learningRate.Equals("")))
                {
                    NetworkDataSource.Networkk(numberHidden, numberCycle, learningRate, error);
                    Toast.MakeText(this, Resource.String.network_created, ToastLength.Short).Show();
                }

                recognizeButton.Click += (o, e) =>
                {
                    TextView textView = (TextView)FindViewById(Resource.Id.Answer);
                    trainNetwork();
                };

                void trainNetwork()
                {
                    serialization.readPatterns();             
                }
                void onCheckedChanged(RadioGroup arg0, int id)
                {
                    switch (id)
                    {
                        case Resource.Id.radioButtonIpprop:
                            flagAlgorithm = IRPROP;
                            break;
                        case Resource.Id.radioButtonBackProp:
                            flagAlgorithm = BACKPROP;
                            break;
                        case Resource.Id.radioButtonRprop:
                            flagAlgorithm = RPROP;
                            break;
                        default:
                            break;
                    }                  
                }
            };

            imageButton.Click += (o, e) =>
            {
                Intent intent = new Intent(this, typeof(ListImagesActivity));
                StartActivity(intent);
            };

            locationIcon.Click += (sender, args) =>
            {
                Intent intent = new Intent(this, typeof(MapActivity));
                StartActivity(intent);
            };
        }

        public void AfterTextChanged(IEditable s)
        {
            throw new NotImplementedException();
        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
            throw new NotImplementedException();
        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
        }
    }
}