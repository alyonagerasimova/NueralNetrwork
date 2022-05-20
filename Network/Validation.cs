using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NueralNetrwork.Network
{
    class Validation
    { 

        public static bool isNumberHiddenValid(String numberHidden)
        {
            if (Int32.Parse(numberHidden) > 500 || Int32.Parse(numberHidden) < 0)
            {
                return false;
            }
            return Int32.Parse(numberHidden) >= 26;
        }

        public static bool isLearningRate(String learningRate)
        {
            if (Double.Parse(learningRate) > 1.0 || Double.Parse(learningRate) < 0)
            {
                return false;
            }
            return Double.Parse(learningRate) > 0;
        }

        public static bool isNumberCycleValid(String numberCycle)
        {
            if (Int32.Parse(numberCycle) > 100 || Int32.Parse(numberCycle) < 0)
            {
                return false;
            }
            return Int32.Parse(numberCycle) > 0;
        }

        public static bool isError(String error)
        {
            if ( Int32.Parse(error) > 10.0 || Int32.Parse(error) < 0)
            {
                return false;
            }
            return Double.Parse(error) > 0;
        }




    }
}