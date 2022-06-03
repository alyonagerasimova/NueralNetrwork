using System;
using Android.Content.Res;
using Xamarin.Essentials;

namespace NueralNetrwork
{
    public partial class MainPage : ContentPage
    {
        public string login = "";
        public string password = "";
        public string WebAPIKey = "AIzaSyBc7kRqN2BXIn1GsFHOA_k3645EqYa09Hs";
        public string myLogTest, myPasTest;

        public MainPage()
        {
            InitializeComponent();
            myLog.Text = Resource.LoginText;
            myPas.Text = Resource.PasText;
            myAuth.Text = Resource.Auth;
            myReg.Text = Resource.Reg;

            myLogTest = myLog.Text;
            myPasTest = myPas.Text;
        }
        async void OnButtonClickedLogin(object sender, EventArgs e)
        {

            login = labelLog.Text;
            password = labelPass.Text;


            //await Navigation.PushAsync(new MainActivity(login, password), true);
            if (login != null && password != null)
            {

                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                try
                {
                    var auth = await authProv ider.SignInWithEmailAndPasswordAsync(login, password);
                    var content = await auth.GetFreshAuthAsync();
                    var serializedcontnet = JsonConvert.SerializeObject(content);
                    Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);

                    await Navigation.PushAsync(new MainActivity(login, password), true);
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
                }


            }
        }

        async void OnButtonClickedPassword(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Register(), true);
        }
    }
}