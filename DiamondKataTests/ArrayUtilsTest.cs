using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace DiamondKataTests
{
    [TestClass]
    public class ArrayUtilsTest
    {
        [TestMethod]
        public void Test_ArrayUtils()
        {
            var diamondAData = new char[3, 3];

            diamondAData[0, 1] = 'A';
            diamondAData[1, 0] = 'A';
            diamondAData[2, 1] = 'A';
            diamondAData[1, 2] = 'A';

            var data = new char[3, 3];

            data[0, 1] = 'A';
            data[1, 0] = 'A';
            data[2, 1] = 'A';
            data[1, 2] = 'A';

            var equalArrays = ArrayUtils.ArraysEqual(diamondAData, data);
            equalArrays.ShouldBeTrue();
        }
    }
}
