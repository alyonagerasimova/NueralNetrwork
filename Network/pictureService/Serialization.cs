using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;

namespace NueralNetrwork.Network.pictureService
{
    class Serialization
    {
        static List<double[]> listPatterns = new List<double[]>();
        private Context context;

        public static List<double[]> getPatterns()
        {
            return listPatterns;
        }

        public Serialization(Context context)
        {
            this.context = context;
            // this.context = Android.App.Application.Context;;
        }

        public Drawable getMipmapResIdByName(String resName)
        {
            int resID = context.Resources.GetIdentifier(resName, "mipmap", context.PackageName);
            Drawable drawable = context.GetDrawable(resID);
            return drawable;
        }

        public void readPatterns()
        {
            double[] patterns = new double[Const.NUMBER_INPUT_NEURONS];
            AssetManager assets = context.Assets;
            string str;
            for (int k = 0; k < Const.ARRAY_LETTERS.Length; k++)
            {
                str = Const.ARRAY_LETTERS[k];

                using (StreamReader sr = new StreamReader(assets.Open(str + ".txt")))
                {
                    for (int i = 0; i < Const.NUMBER_OUTPUT_NEURONS; i++)
                    {
                        try
                        {
                            for (int j = 0; j < patterns.Length; j++)
                            {
                                patterns[j] = Convert.ToDouble(sr.ReadLine());
                            }

                            listPatterns.Add(patterns);
                        }
                        catch (Exception e)
                        {
                            e.ToString();
                        }
                        finally
                        {
                            if (sr != null)
                            {
                                try
                                {
                                    sr.Close();
                                }
                                catch (IOException ignored)
                                {
                                }
                            }
                        }
                    }
                }
            }
        }

        public Android.Graphics.Drawables.BitmapDrawable readImage(string imageName)
        {
            try
            {
                Android.Graphics.Drawables.BitmapDrawable bmp =
                    new Android.Graphics.Drawables.BitmapDrawable("Assets" + imageName + ".png");
                return bmp;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /*   public double[] ReadValuesForTraining(String letter)
           {
               //return readPatterns(letter);
           }*/
    }
}