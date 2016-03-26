using DiamondKataLib;
using System.Collections.Generic;
using System.Drawing;

namespace DiamondKataTests
{
    public static class ArrayExtensions
    {
        public static IEnumerable<DiamondCharacterPoint> ToDiamondCharacterPoint(this char[,] arr)
        {
            var list = new List<DiamondCharacterPoint>();
            for (int y = 0; y < arr.GetLength(0); y++)
            {
                for (int x = 0; x < arr.GetLength(1); x++)
                {
                    if ((arr[y, x] >= 'A' && arr[y, x] <= 'Z') || (arr[y, x] >= 'a' && arr[y, x] <= 'z'))
                    {
                        var upperCase = arr[y, x].ToString().ToUpper();
                        list.Add(new DiamondCharacterPoint() { Value = upperCase.ToCharArray()[0], Coordinate = new Point(x, y) });
                    }
                }
            }
            return list;
        }
    }
}
