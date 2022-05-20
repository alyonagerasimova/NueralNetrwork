using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Content;
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
using NueralNetrwork.Network;
using NueralNetrwork.Network.db;
using NueralNetrwork.Network.pictureService;
using NueralNetrwork.NetworkActivity;
using NueralNetrwork.ui;


namespace NueralNetrwork.NetworkActivity
{
    public class NetworkActivity : AppCompatActivity
    {
        private ImageView locationIcon;

        private Validation validation;

        // private ActivityNetworkBinding binding;
        private EditText numberHiddenEditText;
        private EditText numberCycleEditText;
        private EditText learningRateEditText;
        private EditText errorEditText;
        private Button imageButton;
        private static Button recognizeButton;

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
        private sealed int pick_image = 1;

        private SaveNetwork databaseHelper;

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
            databaseHelper = new SaveNetwork(this);
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string MAPKIT_API_KEY = "5ec3a1f0-9379-4338-8cdd-676426193383";
            MapKitFactory.setApiKey(MAPKIT_API_KEY);
            serialization = new Serialization(this);
            // binding = ActivityNetworkBinding.inflate(getLayoutInflater());
            SetContentView(Resource.Layout.activity_network);

            validation = new ViewModelProvider(this, new NetworkViewModelFactory()).Get(Validation);
            try
            {
                init();
            }
            catch (IOException e) {
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

            if (numberHidden != null || learningRate != null || numberCycle != null || error != null)
            {
                numberHiddenEditText.SetText(numberHidden);
                learningRateEditText.SetText(learningRate);
                numberCycleEditText.SetText(numberCycle);
                errorEditText.SetText(error);
            }

            Validation.getLoginFormState().Observe(this, networkFormState =>
            {
                if (networkFormState == null) {
                    return null;
                }
                recognizeButton.SetEnabled(networkFormState.isDataValid());
                if (networkFormState.getNumberHiddenError() != null) {
                    numberHiddenEditText.SetError(GetString(networkFormState.getNumberHiddenError()));
                }
                if (networkFormState.getNumberCycleError() != null) {
                    numberCycleEditText.SetError(GetString(networkFormState.getNumberCycleError()));
                }
                if (networkFormState.getLearningRate() != null) {
                    learningRateEditText.SetError(GetString(networkFormState.getLearningRate()));
                }
                if (networkFormState.getError() != null) {
                    errorEditText.SetError(GetString(networkFormState.getError()));
                }
            });

            TextWatcher afterTextChangedListener = new TextWatcher()
            { 
                public override void beforeTextChanged(CharSequence s, int start, int count, int after) {
                // ignore
            }

                public override void onTextChanged(CharSequence s, int start, int before, int count)
            {
                // ignore
            }

                public override void afterTextChanged(IEditable s)
                {
                    validation.NetworkDataChanged(numberHiddenEditText.ToString().Trim(),
                        numberCycleEditText.ToString().Trim(),
                        learningRateEditText.ToString().Trim(),
                        errorEditText.ToString().Trim();
                }

            };

            numberHiddenEditText.addTextChangedListener(afterTextChangedListener);
            learningRateEditText.addTextChangedListener(afterTextChangedListener);
            numberCycleEditText.addTextChangedListener(afterTextChangedListener);
            errorEditText.addTextChangedListener(afterTextChangedListener);

            Resource.Id.buttonUpload.Click += (view =>
            {
                Intent intent = new Intent(NetworkActivity, typeof(UploadActivity));
                StartActivity(intent);
            });


            Resource.Id.buttonSave.Click += (view =>
            {
                if (NetworkDataSource.getNetwork() == null) {
                openSiteDialog();
            } else {
                NetworkDataSource.getNetwork().setNumberHiddenNeurons(Int32.Parse(numberHidden));
                NetworkDataSource.getNetwork().setLearningRate(double.Parse(learningRate));
                if (numberCycle != null && !numberCycle.equals(""))
                    NetworkDataSource.getNetwork().setNumberCycles(Int32.Parse(numberCycle));
                if (error != null && !error.equals(""))
                {
                    NetworkDataSource.getNetwork().setError(double.parseDouble(error));
                }

                UploadNetworkActivity uploadNetworkActivity = new UploadNetworkActivity();
                databaseHelper.saveNewNetwork(NetworkDataSource.getNetwork());

                Toast.MakeText(NetworkActivity, Resource.String.network_saved).Show();
                Console.WriteLine("Все ок!");
            }
            });
            Resource.Id.buttonDelete.Click += (view =>
            {
                Intent intent = new Intent(NetworkActivity, DeleteNetworkActivity.class);
                StartActivity(intent);
                if (NetworkDataSource.getNetwork() != null) {
                Toast.MakeText(NetworkActivity, Resource.String.network_loaded).Show();
                numberHiddenEditText.setText(string.valueOf(NetworkDataSource.getNetwork().getNumberHiddenNeurons()));
                learningRateEditText.setText(string.valueOf(NetworkDataSource.getNetwork().getLearningRateFactor()));
                if (NetworkDataSource.getNetwork().getNumberCycles() != 0) {
                numberCycleEditText.setText(string.valueOf(NetworkDataSource.getNetwork().getNumberCycles()));
            }
            if (NetworkDataSource.getNetwork().getError() != 0.0)
            {
                errorEditText.setText(string.valueOf(NetworkDataSource.getNetwork().getError()));
            }

            }
            });
            Resource.Id.button_create_network.Click += (view =>
            {
                readInputValuesForNetwork();
                if ((!numberHidden.equals("") && !numberCycle.equals("") && !learningRate.equals("") && !error.equals(""
                )) ||
                (!numberHidden.equals("") && !numberCycle.equals("") && !learningRate.equals("")) ||
                (!numberHidden.equals("") && !numberCycle.equals("") && !error.equals("")) || (
                !numberHidden.equals("") && !numberCycle.equals("")) ||
                (!numberHidden.equals("") || !numberCycle.equals("") || !learningRate.equals(""))) {
                NetworkDataSource networkDataSource = new NetworkDataSource();
                networkDataSource.network(numberHidden, numberCycle, learningRate, error);
                Toast.MakeText(NetworkActivity, Resource.String.network_created).Show();
            } else {
                openSiteDialog();
            }
            });

            numberHiddenEditText.setOnEditorActionListener += ((v, actionId, event) -> {
                if (actionId == EditorInfo.IME_ACTION_DONE) {
                    validation.network(numberHiddenEditText.getText().toString().trim(),
                        numberCycleEditText.getText().toString().trim(),
                        learningRateEditText.getText().toString().trim(),
                        errorEditText.getText().toString().trim());
                } else {
                    return false;
                }
                return true;
            });
            
            recognizeButton.Click += view => {
                if(!isImage(imageForView)) {
                openSiteDialog();
            }else {
                TextView textView = (TextView)FindViewById(Resource.Id.Answer);
                trainNetwork();
                if (Network.getAnswer() != null)
                {
                    StringBuffer sb = new StringBuffer(textView.getText());
                    textView.SetText(sb.Delete(textView.getText().length() - 1, textView.getText().length()));
                    textView.SetText(textView.getText() + " " + Network.getAnswer());
                }
            }
            };

            radioGroup.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener()
            {
                @SuppressLint("NonConstantResourceId")
                @Override
                public void onCheckedChanged(RadioGroup arg0, int id) {
                switch (id) {
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
            });
            imageButton.Click += (view => {
                Intent intent = new Intent(NetworkActivity, typeof(ListImagesActivity));
                StartActivity(intent);
            });

            locationIcon.Click += (view => {
                Intent intent = new Intent(NetworkActivity, typeof(MapActivity));
                StartActivity(intent);
            });
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}