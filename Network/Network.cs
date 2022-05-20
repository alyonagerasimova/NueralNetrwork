﻿using Android.App;
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
    class Network
    {
        private String flagName;
        private String nameNetwork;
        private double[] inputValues;
        private double[] hiddenValues;
        private double[] outputValues;
        private double[][,] weights;
        private double[][] bias;
        private static int numberCycles = 0;
        private static double learningRateFactor;
        private static double error = 0.0;
        private static int numberHiddenNeurons;
        private double[] pixelsValues;
        private String[] percent = new String[27];
        private List<double[]> patterns;
        private int[] answers = new int[Const.NUMBER_OUTPUT_NEURONS];
        private static String answer;

        public Network(int readNumberHidden, double readLearningRateFactor, int readNumberCycles, double readError, double[][,] readWeights,
                  double[][] readBias, double[] readHiddenValues, double[] readOutputValues, List<double[]> readPatterns, String[] readPercent)
        {
            init(numberHiddenNeurons);
            numberHiddenNeurons = readNumberHidden;
            learningRateFactor = readLearningRateFactor;
            numberCycles = readNumberCycles;
            error = readError;
            this.weights = readWeights;
            this.bias = readBias;
            this.hiddenValues = readHiddenValues;
            this.outputValues = readOutputValues;
            this.patterns = readPatterns;
            this.percent = readPercent;
            initAnswers();
        }

        public Network(int numberHiddenNeurons)
        {
            init(numberHiddenNeurons);
            initialization();
            initAnswers();
        }

        public Network()
        {

        }

        private void init(int numberHiddenNeurons)
        {
            inputValues = new double[Const.NUMBER_INPUT_NEURONS];
            outputValues = new double[Const.NUMBER_OUTPUT_NEURONS];
            hiddenValues = new double[numberHiddenNeurons];
            bias = new double[numberHiddenNeurons][];
            weights = new double[2][,];
        }

        private void initAnswers()
        {
            for (int i = 0; i < Const.NUMBER_OUTPUT_NEURONS; i++)
            {
                answers[i] = i;
            }
        }

        public void initialization()
        {
            for (int i = 0; i < bias.Length - 1; i++)
            {
                bias[i] = new double[hiddenValues.Length];
            }
            Random rnd = new Random();
            bias[bias.Length - 1] = new double[outputValues.Length];
            for (int i = 0; i < bias.Length; i++)
            {
                for (int j = 0; j < bias[i].Length; j++)
                {
                    bias[i][j] = rnd.NextDouble() * (0.7 + 0.5) - 0.5;
                }
            }
            weights[0] = new double[inputValues.Length, hiddenValues.Length];
            weights[1] = new double[hiddenValues.Length,outputValues.Length];
            for (int i = 0; i < weights.Length; i++)
            {
                for (int j = 0; j < weights[i].Length; j++)
                {
                    for (int k = 0; k < weights[j].Length; k++)
                    {
                        weights[i] [j, k] = rnd.NextDouble() * 2 - 1;
                    }
                }
            }
        }

        public void setNameNetwork(String nameNetwork)
        {
            this.nameNetwork = nameNetwork;
        }
        public void setFlagName(String flagName)
        {
            this.flagName = flagName;
        }

        public String getFlagName()
        {
            return flagName;
        }

        public String getNameNetwork()
        {
            return nameNetwork;
        }
        public double[] getInputValues()
        {
            return inputValues;
        }

        public void setHiddenValues(double[] hiddenValues)
        {
            this.hiddenValues = hiddenValues;
        }

        public void setOutputValues(double[] outputValues)
        {
            this.outputValues = outputValues;
        }

        public double[][,] getWeights()
        {
            return weights;
        }


        public void setWeights(double[][,] weights)
        {
            this.weights = weights;
        }
        public double[][] getBias()
        {
            return bias;
        }
        public void setBias(double[][] bias)
        {
            this.bias = bias;
        }
        public double[] getOutputValues()
        {
            return outputValues;
        } 
        public double[] getPixelsValues()
        {
            return pixelsValues;
        }
        public static void setNumberCycles(int numberCycles)
        {
            Network.numberCycles = numberCycles;
        }

        public static void setLearningRateFactor(double learningRateFactor)
        {
            Network.learningRateFactor = learningRateFactor;
        }

        public static void setError(double error)
        {
            Network.error = error;
        }

        public double[] getHiddenValues()
        {
            return hiddenValues;
        }

        public static void setNumberHiddenNeurons(int numberHiddenNeurons)
        {
            Network.numberHiddenNeurons = numberHiddenNeurons;
        }
        public void setInputValues(double[] pixels)
        {
            this.inputValues = pixels;
        }

        public void setPatterns(List<double[]> patterns)
        {
            this.patterns = patterns;
        }

        public List<double[]> getPatterns()
        {
            return patterns;
        }

        public int getNumberHiddenNeurons()
        {
            return numberHiddenNeurons;
        }

        public double getLearningRateFactor()
        {
            return learningRateFactor;
        }

        public int getNumberCycles()
        {
            return numberCycles;
        }

        public double getError()
        {
            return error;
        }
        public static String getAnswer()
        {
            return answer;
        }

        public static void setAnswer(String answerFrom)
        {
            answer = answerFrom;
        }

        public void setNumberHiddenNeurons(Int16 numberHidden)
        {
            Network.numberHiddenNeurons = numberHidden;
        }

        public void setNumberCycles(Int16 numberCycle)
        {
            Network.numberCycles = numberCycle;
        }

        public void setLearningRate(Double learningRate)
        {
            Network.learningRateFactor = learningRate;
        }
        public int[] getAnswers()
        {
            return answers;
        }

    }
}