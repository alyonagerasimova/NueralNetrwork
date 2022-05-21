// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using NueralNetrwork.Network;
// using System;
// using System.Diagnostics;
//
// namespace NueralNetrwork
// {
//
//     [TestClass]
//     class TestBackend
//     {
//         private String numberHidden = "200";
//         private String learningRate = "0.2";
//         private String numberCycle = "10";
//         private String error = "0.0";
//
//         [TestMethod]
//         public void createNetworkTest()
//         {
//             NetworkDataSource.Networkk(numberHidden, numberCycle, learningRate, error);
//             Assert.IsNotNull(NetworkDataSource.getNetwork());
//             // Assert.IsTrue(NetworkDataSource.getNetwork() is Network);
//         }
//
//         [TestMethod]
//         public void getWeights()
//         {
//             NetworkDataSource.Networkk(numberHidden, numberCycle, learningRate, error);
//             Assert.IsNotNull(NetworkDataSource.getNetwork());
//             Assert.IsTrue(NetworkDataSource.getNetwork() is Network);
//             Assert.IsNotNull(NetworkDataSource.getNetwork().getWeights());
//         }
//         [TestMethod]
//         public void isNumberHiddenNotValid()
//         {
//             Assert.IsFalse(Validation.isNumberHiddenValid("600"));
//         }
//
//         [TestMethod]
//         public void isLearningRateValid()
//         {
//             Assert.IsFalse(Validation.isLearningRate("1"));
//         }
//
//         [TestMethod]
//         public void isNumberCycleNotValid()
//         {
//             Assert.IsFalse(Validation.isNumberCycleValid("101"));
//         }
//
//         [TestMethod]
//         public void isErrorNotValid()
//         {
//             Assert.IsFalse(Validation.isError("10.1"));
//         }
//
//     }
// }