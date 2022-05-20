﻿using System;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Widget;
using Android.Runtime;
using AndroidX.AppCompat.App;
using NueralNetrwork;
using NueralNetrwork.NetworkActivity;
using Org.Json;
using Thread = System.Threading.Thread;


namespace NueralNetrwork.NetworkActivity
{
    public class LoginRegistrationActivity : AppCompatActivity
    { 
        Button btnLogin;
    Button btnRegister;
    FirebaseAuth auth;
    FirebaseDatabase db;
    DatabaseReference users;
    EditText email;
    EditText password;
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity__login_register);

        btnLogin = (Button)FindViewById(Resource.Id.btn_for_login);
        btnRegister = (Button)FindViewById(Resource.Id.btn_for_register);

        email = (EditText)FindViewById(Resource.Id.email_hint);
        password = (EditText)FindViewById(Resource.Id.password_hint);

        auth = FirebaseAuth.getInstance();
        db = FirebaseDatabase.getInstance();
        users = db.getReference("Users");

        btnLogin.Click += (view => {
            try {
                login(email, password);
            } catch (FirebaseAuthException e) {
                e.printStackTrace();
            }
        });

        btnRegister.Click += (view => registration(email, password));
    }

    private void login(EditText email, EditText password) throws FirebaseAuthException {

        if (TextUtils.isEmpty(email.getText().toString())) {
            Toast.MakeText(LoginRegistrationActivity.this, Resource.String.enter_email,
                    Toast.LENGTH_LONG).show();
            return;
        }
        if (TextUtils.isEmpty(password.getText().toString())) {
            Toast.makeText(LoginRegistrationActivity.this, R.string.enter_password,
                    Toast.LENGTH_LONG).show();
            return;
        }

        auth.signInWithEmailAndPassword(email.getText().toString(), password.getText().toString())
                .addOnSuccessListener(authResult -> {
                    FirebaseUser mUser = FirebaseAuth.getInstance().getCurrentUser();
                    if (mUser != null) {
                        mUser.getIdToken(false)
                                .addOnCompleteListener(task -> {
                                    if (task.isSuccessful()) {
                                        string idToken = task.getResult().getToken();
                                        new Thread(() -> {
                                            string str = getData(idToken);
                                            try {
                                                JSONObject object = new JSONObject(str);
                                                string welcomeText = object.getString("welcome");
                                                runOnUiThread(() -> {
                                                    Toast.MakeText(
                                                            getApplicationContext(),
                                                            welcomeText,
                                                            Toast.LENGTH_LONG).show();
//                                                    Intent intent = new Intent(LoginRegistrationActivity.this, NetworkActivity.class);
//                                                    startActivity(intent);
                                                });
                                            } catch (JSONException e) {
                                                e.printStackTrace();
                                            }
                                        }).start();
                                        Intent intent = new Intent(LoginRegistrationActivity.this, NetworkActivity.class);
                                        startActivity(intent);
                                    } else {
                                        Objects.requireNonNull(task.getException()).printStackTrace();
                                    }
                                });
                    }
                }).addOnFailureListener(e ->
                Toast.makeText(LoginRegistrationActivity.this, 
            getString(Resource.String.error_signin) + e.getMessage(), Toast.LENGTH_LONG).show());
    }

    private void registration(EditText email, EditText password) {

        if (TextUtils.isEmpty(email.getText().toString())) {
            Toast.MakeText(LoginRegistrationActivity.this, Resource.String.enter_email,
                    Toast.LENGTH_LONG).show();
            return;
        }
        if (TextUtils.isEmpty(password.getText().toString())) {
            Toast.MakeText(LoginRegistrationActivity.this, Resource.String.enter_password,
                    Toast.LENGTH_LONG).show();
            return;
        }

        auth.createUserWithEmailAndPassword(email.getText().toString(),
                password.getText().toString())
                .addOnSuccessListener(authResult -> {
                    User user = new User(email.getText().toString(),
                            password.getText().toString());
                    users.child(Objects.requireNonNull(FirebaseAuth.getInstance().getCurrentUser()).getUid())
                            .setValue(user)
                            .addOnSuccessListener(unused -> Toast.makeText(
                                    LoginRegistrationActivity.this,
                                    Resource.String.add_user,
                                    Toast.LENGTH_LONG).show());
                })
                .addOnFailureListener(e -> Toast.makeText(LoginRegistrationActivity.this,
                        getString(Resource.String.error_register) + e.getMessage(), Toast.LENGTH_LONG).show());
        ;
    }

    private string getData(string token) {
        string targetURL = "http://192.168.1.89:6070/api/user/welcome";

        try {
            URL url = new URL(targetURL);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setRequestMethod("GET");
            connection.setRequestProperty("User-Agent", "Mozilla/5.0");
            connection.setRequestProperty("X-UserId", FirebaseAuth.getInstance().getUid());
            connection.setRequestProperty("X-IdToken", token);

            int responseCode = connection.getResponseCode();
            if (responseCode == 404) {
                throw new IllegalArgumentException();
            }

            BufferedReader reader = new BufferedReader(new InputStreamReader(connection.getInputStream()));
            StringBuilder builder = new StringBuilder();
            string line = "";

            while ((line = reader.readLine()) != null) {
                builder.append(line).append("\n");
            }
            reader.Close();
            return builder.toString();

        } catch (Exception e) {
            e.printStackTrace();
        }

        return "{}";
    }
    }
}