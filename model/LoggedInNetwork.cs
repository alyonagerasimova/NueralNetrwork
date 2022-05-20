using System;

namespace NueralNetrwork.model
{
    public class LoggedInNetwork
    {
        private static Int32 numberHidden;
        private static Int32 numberCycle;
        private static double learningRate;
        private static double error;

        public LoggedInNetwork(Int32 numberHidden, Int32 numberCycle, double learningRate, double error)
        {
            LoggedInNetwork.numberHidden = numberHidden;
            LoggedInNetwork.numberCycle = numberCycle;
            LoggedInNetwork.learningRate = learningRate;
            LoggedInNetwork.error = error;
        }

        public static int getNumberHidden()
        {
            return numberHidden;
        }

        public static int getNumberCycle()
        {
            return numberCycle;
        }
    }
}