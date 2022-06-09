using System.IO;
using System.Net;
using Android.App;
using Android.Content;
using Android.Content.PM;
// using Android.Gms.Tasks;
using Android.OS;
using Android.Text;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Java.Lang;
using Java.Util;
using NueralNetrwork.model;
using Org.Json;
using Button = Android.Widget.Button;
using Console = System.Console;
using Exception = System.Exception;
using StringBuilder = System.Text.StringBuilder;
using Thread = System.Threading.Thread;


namespace NueralNetrwork.auth
{
    [Activity(Label = "@string/app_name", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class LoginRegistrationActivity : AppCompatActivity
    {
        Button btnLogin;

        Button btnRegister;

        // FirebaseAuthentication auth;
        FirebaseDatabase db;
        DatabaseReference users;
        EditText email;
        EditText password;
        Firebase.Auth.FirebaseAuth auth;

        private FirebaseApp app;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity__login_register);
            btnLogin = (Button)FindViewById(Resource.Id.btn_for_login);
            btnRegister = (Button)FindViewById(Resource.Id.btn_for_register);
            email = (EditText)FindViewById(Resource.Id.email_hint);
            password = (EditText)FindViewById(Resource.Id.password_hint);

            // auth = DependencyService.Get<FirebaseAuthentication>();
            app = FirebaseApp.InitializeApp(this);

            auth = Firebase.Auth.FirebaseAuth.GetInstance(app);
            db = FirebaseDatabase.GetInstance(app);
            users = db.GetReference("Users");

            btnLogin.Click += (view, e) =>
            {
                try
                {
                    login(email, password);
                }
                catch (FirebaseAuthException ex)
                {
                    Console.Write(ex.Message);
                }
            };

            btnRegister.Click += (sender, args) => { registration(email, password); };
        }

        private void login(EditText emailEditText, EditText passwordEditText)
        {
            var emailText = emailEditText.Text;
            var passwordText = passwordEditText.Text;

            if (TextUtils.IsEmpty(emailText))
            {
                Toast.MakeText(
                    this,
                    Resource.String.enter_email,
                    ToastLength.Long
                )?.Show();
                return;
            }

            if (TextUtils.IsEmpty(passwordText))
            {
                Toast.MakeText(
                    this,
                    Resource.String.enter_password,
                    ToastLength.Long
                )?.Show();
                return;
            }

            var task = auth
                .SignInWithEmailAndPassword(emailText, passwordText);
            if (task.IsCanceled)
            {
                Console.Error.WriteLine("SignInWithEmailAndPassword was canceled.");
                Toast.MakeText(this, GetString(Resource.String.error_signin), ToastLength.Long)?.Show();
                return;
            }

            if (task.IsComplete && task.IsSuccessful)
            {
                Console.WriteLine("IsComplete & IsSuccessful");
                onSuccessLogin(task.Result);
            }

            Toast.MakeText(this, GetString(Resource.String.error_signin), ToastLength.Long)?.Show();

            // .AddOnSuccessListener((authResult: Object) => {
            //   this.onSuccessLogin(authResult);
            //  // authResult return authResult;
            // }).AddOnFailureListener(IOnFailureListener);

            // e =>
            // {
            //     Toast.MakeText(this, GetString(Resource.String.error_signin), ToastLength.Long)?.Show();
            // }
        }

        private void onSuccessLogin(Object authResult)
        {
            Console.WriteLine(authResult);
            FirebaseUser mUser = auth.CurrentUser;

            if (mUser == null)
            {
                Console.Error.WriteLine("FirebaseUser is null");
                return;
            }

            var task = mUser.GetIdToken(false);
            
            task.Wait();
            if (task.IsComplete && task.IsSuccessful)
            {
                string idToken = task.Result.ToString();
                string str = getData(idToken);
                try
                {
                    JSONObject obj = new JSONObject(str);
                    string welcomeText = obj.GetString("welcome");
                    RunOnUiThread(() =>
                    {
                        Toast.MakeText(this, welcomeText, ToastLength.Long)?.Show();
                    });
                    Intent intent = new Intent(this, typeof(NetworkActivity.NetworkActivity));
                    StartActivity(intent);
                }
                catch (JSONException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
//                 .AddOnCompleteListener(task =>
//                 {
//                     if (task.isSuccessful())
//                     {
//                         string idToken = task.getResult().getToken();
//                         new Thread(() =>
//                         {
//                             string str = getData(idToken);
//                             try
//                             {
//                                 JSONObject obj = new JSONObject(str);
//                                 string welcomeText = obj.GetString("welcome");
//                                 RunOnUiThread(() =>
//                                 {
//                                     Toast.MakeText(this, welcomeText, ToastLength.Long)?.Show();
// //                                                    Intent intent = new Intent(LoginRegistrationActivity.this, NetworkActivity.class);
// //                                                    startActivity(intent);
//                                 });
//                             }
//                             catch (JSONException e)
//                             {
//                                 Console.WriteLine(e.Message);
                            // }
//                         }).Start();
//                         Intent intent = new Intent(this, typeof(NetworkActivity.NetworkActivity));
//                         StartActivity(intent);
//                     }
//                     else
//                     {
//                         // Console.Error.WriteLine(Objects.RequireNonNull(task.getException()));
//                         // Toast.MakeText(this, Objects.RequireNonNull(task.getException()).ToString());
//                     }
//                 });
        }

        private void registration(EditText email, EditText password)
        {
            if (TextUtils.IsEmpty(email.Text))
            {
                Toast.MakeText(this, Resource.String.enter_email,
                    ToastLength.Long)?.Show();
                return;
            }

            if (TextUtils.IsEmpty(password.Text))
            {
                Toast.MakeText(this, Resource.String.enter_password,
                    ToastLength.Long)?.Show();
                return;
            }

            auth.CreateUserWithEmailAndPasswordAsync(email.Text, password.Text).ContinueWith(authResult =>
            // auth.CreateUserWithEmailAndPassword(email.Text, password.Text)
                // .AddOnSuccessListener(authResult =>
                {
                    if (authResult.IsCanceled) {
                     
                        return;
                    }
                    if (authResult.IsFaulted) {
                       
                        return;
                    }
                    // Firebase.Auth.FirebaseUser newUser = authResult.Result;
                    var user = new User(email.Text, password.Text);
                    
                    //FirebaseAuth.GetInstance(app)
                    // users.Child(Objects.RequireNonNull(auth.Uid).setValue(user)
                    //     .addOnSuccessListener(unused =>
                    //     {
                    //         Toast.MakeText(this, Resource.String.add_user, ToastLength.Long)?.Show();
                    //     })
                    //     .AddOnFailureListener(e =>
                    //     {
                    //         Toast.MakeText(this,
                    //             Resource.String.error_register + e.getMessage(), ToastLength.Long)?.Show();
                    //     })
                    // );
                });
        }

        private string getData(string token)
        {
            string targetURL = "http://192.168.1.89:6070/api/user/welcome";

            try
            {
                string sURL;
                sURL = "http://api/user/welcome";
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(sURL);
                WebProxy myProxy = new WebProxy("myproxy", 6070);
                myProxy.BypassProxyOnLocal = true;
                wrGETURL.Proxy = WebProxy.GetDefaultProxy();
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);
                StringBuilder builder = new StringBuilder();
                string sLine = "";
                int i = 0;
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        builder.Append(sLine).Append("\n");
                    // Console.WriteLine("{0}:{1}", i, sLine);
                }

                return builder.ToString();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return "{}";
        }
    }
}