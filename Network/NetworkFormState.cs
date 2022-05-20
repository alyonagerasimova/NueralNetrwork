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
    class NetworkFormState
    {

        public static void setNumberHiddenError(Int32 numberHiddenError)
        {
            NetworkFormState.numberHiddenError = numberHiddenError;
        }

        private static Int32 numberHiddenError;

        public static void setNumberCycleError(Int32 numberCycleError)
        {
            NetworkFormState.numberCycleError = numberCycleError;
        }

        private static Int32 numberCycleError;

        public static void setLearningRateError(Int32 learningRateError)
        {
            NetworkFormState.learningRateError = learningRateError;
        }

        private static Int32 learningRateError;

        public static void setError(Int32 error)
        {
            NetworkFormState.error = error;
        }

        private static Int32 error;
        private bool isDataValid;

        public static Int32 getIsImage()
        {
            return isImage;
        }

        private static Int32 isImage;

        public NetworkFormState(Int32 numberHiddenError, Int32 learningRateError,
                                Int32 numberCycleError, Int32 error)
        {
            NetworkFormState.numberHiddenError = numberHiddenError;
            NetworkFormState.learningRateError = learningRateError;
            NetworkFormState.numberCycleError = numberCycleError;
            NetworkFormState.error = error;
            this.isDataValid = false;
        }

        NetworkFormState(bool isDataValid)
        {
            this.isDataValid = isDataValid;
        }

        NetworkFormState(Int32 isImage)
        {
            NetworkFormState.isImage = isImage;
        }
    public static Int32 getNumberHiddenError()
        {
            return numberHiddenError;
        }

        public static Int32 getNumberCycleError()
        {
            return numberCycleError;
        }

        public static Int32 getError()
        {
            return error;
        }

    
    public static Int32 getLearningRate()
        {
            return learningRateError;
        }

        public bool IsDataValid()
        {
            return isDataValid;
        }
    }
}