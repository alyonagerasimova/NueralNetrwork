using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NueralNetrwork.Network.impl;
using NueralNetrwork.Network.pictureService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NueralNetrwork.Network
{
    class NetworkDataSource
    {

        private static Double errorValue;
        private static String IRPROP = "IRProp";
        private static String RPROP = "RProp";
        private static String BACKPROP = "BackProp";

        private static iRPropImpl iRProp;

        public static BackPropImpl getBackProp()
        {
            return backProp;
        }

        public static iRPropImpl getiRProp()
        {
            return iRProp;
        }

        private static BackPropImpl backProp;

        public static int getNumberHiddenNeurons()
        {
            return numberHiddenNeurons;
        }

        public static RPropImpl getRProp()
        {
            return rProp;
        }

        private static RPropImpl rProp;
        private static int numberHiddenNeurons;
        private static Double numberLearningRate;
        private static int numberCycleValue;

        public static void setErrorValue(Double errorValue)
        {
            NetworkDataSource.errorValue = errorValue;
        }

        public static void setNetwork(Network networkk)
        {
            network = networkk;
        }

        private static Network network;

        public static Network getNetwork()
        {
            return network;
        }

        public static void Networkk(String numberHidden, String numberCycle, String learningRate, String error)
        {
            try
            {
                NetworkDataSource.numberHiddenNeurons = Int32.Parse(numberHidden);
                NetworkDataSource.numberCycleValue = Int32.Parse(numberCycle);
                if (!learningRate.Equals(""))
                {
                    NetworkDataSource.numberLearningRate = Double.Parse(learningRate);
                }
                if (!error.Equals(""))
                {
                    NetworkDataSource.errorValue = Double.Parse(error);
                }     
                network = new Network(numberHiddenNeurons);
                if (numberCycleValue != null)
                {
                    Network.setNumberCycles(NetworkDataSource.numberCycleValue);
                }
                else if (errorValue != null)
                {
                    Network.setError(NetworkDataSource.errorValue);
                }
                network.setLearningRate(NetworkDataSource.numberLearningRate);              
            }
            catch (Exception e)
            {
              
            }
        }
        public static void initDataAndChooseAlgorithm() {
            double[] inputAndPixelValue = PictureService.getPixelColor(NetworkActivity.getImageForRecognize());
                if (NetworkActivity.getFlagAlgorithm().equals(IRPROP))
                {
                    iRProp = new iRPropImpl(numberHiddenNeurons, numberLearningRate);
                    if (numberCycleValue == null)
                    {
                        iRProp.setNumberCycles(0);
                    }
                    else
                    {
                        iRProp.setNumberCycles(numberCycleValue);
                    }
                    if (errorValue == null)
                    {
                        iRProp.setError(0.0);
                    }
                    else
                    {
                        iRProp.setError(errorValue);
                    }
                    iRProp.setInputValues(inputAndPixelValue);
                    iRProp.setPatterns(NetworkActivity.getPatterns());
                    iRProp.setPixelsValues(inputAndPixelValue);
                    iRProp.setBias(network.getBias());
                    iRProp.setAnswers(network.getAnswers());
                    iRProp.setWeightsPrev(network.getWeights());
                    network.setHiddenValues(iRProp.getHiddenValues());
                    iRProp.train();
                    iRProp.Answer();
                }
                else if (NetworkActivity.getFlagAlgorithm().equals(RPROP))
                {
                    rProp = new RPropImpl(numberHiddenNeurons, numberLearningRate);
                    if (numberCycleValue == null)
                    {
                        rProp.setNumberCycles(0);
                    }
                    else
                    {
                        rProp.setNumberCycles(numberCycleValue);
                    }
                    if (errorValue == null)
                    {
                        rProp.setError(0.0);
                    }
                    rProp.setInputValues(inputAndPixelValue);
                    rProp.setPatterns(NetworkActivity.getPatterns());
                    rProp.setPixelsValues(inputAndPixelValue);
                    rProp.setBias(network.getBias());
                    rProp.setAnswers(network.getAnswers());
                    rProp.setWeightsPrev(network.getWeights());
                    network.setHiddenValues(rProp.getHiddenValues());
                    rProp.train();
                    rProp.Answer();
                }
                else if (NetworkActivity.getFlagAlgorithm().equals(BACKPROP))
                {
                    backProp = new BackPropImpl(numberHiddenNeurons, numberLearningRate);
                    if (numberCycleValue == null)
                    {
                        backProp.setNumberCycles(0);
                    }
                    else
                    {
                        backProp.setNumberCycles(numberCycleValue);
                    }
                    if (errorValue == null)
                    {
                        backProp.setError(0.0);
                    }
                    else
                    {
                        backProp.setError(errorValue);
                    }
                    backProp.setInputValues(inputAndPixelValue);
                    backProp.setPatterns(NetworkActivity.getPatterns());
                    backProp.setPixelsValues(inputAndPixelValue);
                    backProp.setBias(network.getBias());
                    backProp.setAnswers(network.getAnswers());
                    backProp.setWeights(network.getWeights());
                    backProp.train();
                    backProp.Answer();
                    Network.setNumberCycles(backProp.getNumberCycles());
                    network.setLearningRate(backProp.getLearningRateFactor());
                    network.setWeights(backProp.getWeights());
                    network.setHiddenValues(backProp.getHiddenValues());
                    network.setOutputValues(backProp.getOutputValues());
                    Network.setError(backProp.getError());
                    network.setBias(backProp.getBias());
                }
            }



        }




    }
     