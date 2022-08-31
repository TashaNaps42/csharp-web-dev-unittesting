using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarNS;
using System;

namespace CarTests
{

    [TestClass]
    public class CarTests
    {
        
        //   \/\/\/   [[[ 0 ]]] Verifies my syntax isn't already broken    \/\/\/
        [TestMethod]
        public void EmptyTest()
        {
            Assert.AreEqual(10, 10, .001);
        }

        //   \/\/\/   [[[ A ]]] Initializes an instance of **car class** for testing [1-]    \/\/\/

        Car test_car_primary;

        [TestInitialize]
        public void CreateCarObject()
        {
            test_car_primary = new Car("Toyota", "Prius", 10, 50);
        }

        //   \/\/\/   [[[ 1 ]]] Constructor sets gasTankLevel properly    \/\/\/
        [TestMethod] 
        public void TestGasTankOnInit()
        {
            Assert.AreEqual(10, test_car_primary.GasTankLevel, .001);
        }

        //    \/\/\/   [[[ 2 ]]] gasTankLevel is accurate after driving within tank range   \/\/\/

        [TestMethod]
        public void TestGasTankAfterDriving()
        {
            test_car_primary.Drive(50);
            Assert.AreEqual(9, test_car_primary.GasTankLevel, .001);
        }
        //    \/\/\/  [[[3]]] gasTankLevel is accurate after attempting to drive past tank range   \/\/\/
        [TestMethod]
        public void TestGasTankAfterExceedingTankRange()
        {
            test_car_primary.Drive(50 * 111);
            Assert.AreEqual(0, test_car_primary.GasTankLevel, .001);
        }
        //   \/\/\/   [[[4]]] can't have more gas than tank size, expect an exception
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGasOverfillException()
        {
            test_car_primary.AddGas(5);
            Assert.Fail("Shouldn't get here, car cannot have more gas in tank than the size of the tank"); //are you kidding me throw err "err message too fing long there bud, did yer mam write that err message? I threw an err when I threw out my back givin it to yer mam last night Jonesy." "FUCK YOU SHORESEY" "Fuck you Reilly, I had at least three err messages when I used incorrect syntax on yer mam's bang() method.

        }
    }
}
