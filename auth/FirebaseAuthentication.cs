// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using Android.App;
// using Android.Content;
// using Android.Gms.Extensions;
// using Android.OS;
// using Android.Runtime;
// using Android.Views;
// using Android.Widget;
// using Firebase.Auth;
//
// namespace NueralNetrwork.auth
// {
//     public class FirebaseAuthentication : IFirebaseAuthentication
//     {
//         public bool IsSignIn()
//         {
//             var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
//             return user != null;
//         }
//
//         public async Task<string> LoginWithEmailAndPassword(string email, string password)
//         {
//             try
//             {
//                 var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
//                 var token = await user.User.GetIdToken(false);
//
//                 return token.ToString();
//             }
//             catch (FirebaseAuthInvalidUserException e)
//             {
//                 e.PrintStackTrace();
//                 return string.Empty;
//             }
//             catch (FirebaseAuthInvalidCredentialsException e)
//             {
//                 e.PrintStackTrace();
//                 return string.Empty;
//             }
//         }
//
//         public bool SignOut()
//         {
//             try
//             {
//                 Firebase.Auth.FirebaseAuth.Instance.SignOut();
//                 return true;
//             }
//             catch (Exception)
//             {
//                 return false;
//             }
//         }
//     }
// }