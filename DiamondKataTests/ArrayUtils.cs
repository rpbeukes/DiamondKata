using System;
using System.Linq;

namespace DiamondKataTests
{
    public static class ArrayUtils
    {
        public static bool ArraysEqual(char[,] diamondAData, char[,] data)
        {
            return diamondAData.Rank == data.Rank &&
                                          Enumerable.Range(0, diamondAData.Rank).All(dimension => diamondAData.GetLength(dimension) == data.GetLength(dimension)) &&
                                          diamondAData.Cast<char>().SequenceEqual(data.Cast<char>());
        }


        public static object ArrayEqual<T>(T diamondAData, T data)
        {
            throw new NotImplementedException();
        }
    }
}
