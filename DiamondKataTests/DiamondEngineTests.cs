using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using DiamondKataConsole;

namespace DiamondKataTests
{
    [TestClass]
    public class DiamondEngineTests
    {
        //Great tool designed to display arrays (Jagged and up to 4D) while debugging an application.
        //https://visualstudiogallery.msdn.microsoft.com/eedc48e7-5169-40d3-b602-ad451990a420

        [TestMethod]
        public void Test_A_Diamond()
        {
            
            //  A
            //A   A
            //  A 
            
            var expeactedDiamond = new char[3, 3];

            expeactedDiamond[0, 1] = 'A';
            expeactedDiamond[1, 0] = 'A';
            expeactedDiamond[2, 1] = 'A';
            expeactedDiamond[1, 2] = 'A';

            var sut = new DiamondEngine('A');
            var actualDiamond = sut.Create();

            var equalArrays = ArrayUtils.ArraysEqual(expeactedDiamond, actualDiamond);
            equalArrays.ShouldBeTrue();
        }

        /*
        [TestMethod]
        public void Test_B_Diamond()
        {
            
           //  A
           //B   B
           //  A 
           

            var diamondBData = new string[3, 3];

            diamondBData[0, 1] = "A";
            diamondBData[1, 0] = "B";
            diamondBData[2, 1] = "A";
            diamondBData[1, 2] = "B";

        }

        [TestMethod]
        public void Test_C_Diamond()
        {
            
          //    A
          //  B   B
          //C       C
          //  B   B
          //    A
          

            var diamondCData = new string[4, 4];

            diamondCData[0, 1] = "A";
            diamondCData[1, 0] = "B";
            diamondCData[2, 1] = "A";
            diamondCData[1, 2] = "B";
        }
    */
    }
}
