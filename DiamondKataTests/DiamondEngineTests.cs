using DiamondKataLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
            var expectedList = new List<DiamondCharacterPoint>() {
                new DiamondCharacterPoint { Value = 'A', Coordinate = new Point(1, 0) },
                new DiamondCharacterPoint { Value = 'A', Coordinate = new Point(0, 1) },
                new DiamondCharacterPoint { Value = 'A', Coordinate = new Point(1, 2) },
                new DiamondCharacterPoint { Value = 'A', Coordinate = new Point(2, 1) }
            };

            var sut = new DiamondEngine('A');
            var actualList = sut.Create();

            AssertLists(expectedList, actualList);
        }


        [TestMethod]
        public void Test_B_Diamond()
        {
            //  A
            //B   B
            //  A 
            var expectedList = new List<DiamondCharacterPoint>() {
                new DiamondCharacterPoint { Value = 'A', Coordinate = new Point(1, 0) },
                new DiamondCharacterPoint { Value = 'B', Coordinate = new Point(0, 1) },
                new DiamondCharacterPoint { Value = 'A', Coordinate = new Point(1, 2) },
                new DiamondCharacterPoint { Value = 'B', Coordinate = new Point(2, 1) }
            };

            var sut = new DiamondEngine('B');
            var actualList = sut.Create();

            AssertLists(expectedList, actualList);
        }


        [TestMethod]
        public void Test_C_Diamond()
        {
            //    A
            //  B   B
            //C       C
            //  B   B
            //    A
            char[,] arr = new char[5, 5]
                              {
                               { '\0','\0',  'A', '\0','\0' },
                               { '\0', 'B', '\0', 'B' ,'\0' },
                               {  'C','\0', '\0', '\0','C'  },
                               { '\0', 'B', '\0',  'B','\0' },
                               { '\0', '\0', 'A', '\0','\0' }
                              };

            var expectedList = new List<DiamondCharacterPoint>() {
                new DiamondCharacterPoint { Value = 'C', Coordinate = new Point(0, 2) },
                new DiamondCharacterPoint { Value = 'B', Coordinate = new Point(1, 1) },
                new DiamondCharacterPoint { Value = 'B', Coordinate = new Point(1, 3) },
                new DiamondCharacterPoint { Value = 'A', Coordinate = new Point(2, 0) },
                new DiamondCharacterPoint { Value = 'A', Coordinate = new Point(2, 4) },
                new DiamondCharacterPoint { Value = 'B', Coordinate = new Point(3, 1) },
                new DiamondCharacterPoint { Value = 'B', Coordinate = new Point(3, 3) },
                new DiamondCharacterPoint { Value = 'C', Coordinate = new Point(4, 2) },
            };

            var sut = new DiamondEngine('C');
            var actualList = sut.Create();

            AssertLists(expectedList, actualList);

            var visualArray = sut.CreateArray();
        }

        [TestMethod]
        public void Test_D_Diamond()
        {

            //      A
            //    B   B
            //  C       C
            //D           D
            //  C       C
            //    B   B
            //      A
            var expectedList = new List<DiamondCharacterPoint>() {
                new DiamondCharacterPoint { Value = 'D', Coordinate = new Point(0, 3) },
                new DiamondCharacterPoint { Value = 'C', Coordinate = new Point(1, 2) },
                new DiamondCharacterPoint { Value = 'C', Coordinate = new Point(1, 4) },
                new DiamondCharacterPoint { Value = 'B', Coordinate = new Point(2, 1) },
                new DiamondCharacterPoint { Value = 'B', Coordinate = new Point(2, 5) },
                new DiamondCharacterPoint { Value = 'A', Coordinate = new Point(3, 0) },
                new DiamondCharacterPoint { Value = 'A', Coordinate = new Point(3, 6) },
                new DiamondCharacterPoint { Value = 'B', Coordinate = new Point(4, 1) },
                new DiamondCharacterPoint { Value = 'B', Coordinate = new Point(4, 5) },
                new DiamondCharacterPoint { Value = 'C', Coordinate = new Point(5, 2) },
                new DiamondCharacterPoint { Value = 'C', Coordinate = new Point(5, 4) },
                new DiamondCharacterPoint { Value = 'D', Coordinate = new Point(6, 3) }
            };

            var sut = new DiamondEngine('D');
            var actualList = sut.Create();
            var visualArray = sut.CreateArray();

            AssertLists(expectedList, actualList);
        }

        private static void AssertLists(List<DiamondCharacterPoint> expectedList, IEnumerable<DiamondCharacterPoint> actualList)
        {
            foreach (var expected in expectedList)
            {
                var find = actualList.Where(actual => actual.Value == expected.Value && actual.Coordinate.Equals(expected.Coordinate));
                find.Count().ShouldBe(1, $"Missing value - Expected '{expected.Value}' at ({expected.Coordinate.X},{expected.Coordinate.Y}) but was not found");
                find.First().Value.ShouldBe(expected.Value, $"Chracter mismatch at ({expected.Coordinate.X},{expected.Coordinate.Y})");
                find.First().Coordinate.X.ShouldBe(expected.Coordinate.X, $"Coordinate ({expected.Coordinate.X},{expected.Coordinate.Y})");
                find.First().Coordinate.Y.ShouldBe(expected.Coordinate.Y, $"Coordinate ({expected.Coordinate.X},{expected.Coordinate.Y})");
            }
        }
    }
}
