using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NueralNetrwork.NetworkActivity;
using NueralNetrwork.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NueralNetrwork 
{
    [TestClass]
   class TestUI
   {
       private MainPage mainpage;
       private MainActivity mainact;

       [TestMethod]
     public void testLogin()
      {
           mainpage = new MainPage();

       }

        [TestMethod]
       public void testLabel()
        {
           mainpage = new MainPage();
          try
           {
              Assert.AreEqual("Login", mainpage.myLogTest);
                Assert.AreEqual("Password", mainpage.myPasTest);

             }
            catch
             {
                 Assert.AreEqual("Логин", mainpage.myLogTest);
                Assert.AreEqual("Пароль", mainpage.myPasTest);
            }
        }
     }
 }