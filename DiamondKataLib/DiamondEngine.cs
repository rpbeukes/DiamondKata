using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DiamondKataLib
{
    public class DiamondEngine
    {
        private readonly int _centre;
        private DiamondKataLib.CycleCharacter _cycleCharacter;
        private readonly char _patternChar;
        private readonly Point _startCoordinate;

        public DiamondEngine(char diamondChar)
        {
            _patternChar = diamondChar;
            _centre = _patternChar - 'A';
            _startCoordinate = new Point(0, _patternChar - 'A');
        }

        private int MatrixCount
        {
            get
            {
                int count = _patternChar - 'A';
                return count <= 1 ? 3 /* 'A' and 'B' only */
                                     : count * 2;
            }
        }

        public IEnumerable<DiamondCharacterPoint> Create()
        {
            _cycleCharacter = new DiamondKataLib.CycleCharacter(_patternChar);
            var list = new List<DiamondCharacterPoint>();
            switch (_patternChar)
            {
                case 'A':
                    list.Add(new DiamondCharacterPoint() { Value = _patternChar, Coordinate = new Point(1, 0) });
                    list.Add(new DiamondCharacterPoint() { Value = _patternChar, Coordinate = new Point(0, 1) });
                    list.Add(new DiamondCharacterPoint() { Value = _patternChar, Coordinate = new Point(1, 2) });
                    list.Add(new DiamondCharacterPoint() { Value = _patternChar, Coordinate = new Point(2, 1) });
                    break;
                case 'B':
                    list.Add(new DiamondCharacterPoint() { Value = 'A', Coordinate = new Point(1, 0) });
                    list.Add(new DiamondCharacterPoint() { Value = _patternChar, Coordinate = new Point(0, 1) });
                    list.Add(new DiamondCharacterPoint() { Value = 'A', Coordinate = new Point(1, 2) });
                    list.Add(new DiamondCharacterPoint() { Value = _patternChar, Coordinate = new Point(2, 1) });
                    break;
                default:
                    for (int x = 0; x < MatrixCount + 1; x++)
                    {
                        var createSingelCharPoint = x % MatrixCount == 0;
                        if (createSingelCharPoint)
                        {
                            //add one char
                            var point = new Point(x, _centre);
                            list.Add(new DiamondCharacterPoint() { Value = _cycleCharacter.CurrentChar, Coordinate = point });
                        }
                        else
                        {
                            //add two chars
                            var yVal = x % _centre;
                            if (yVal != 0)
                            {
                                if (x < _centre)
                                {
                                    var point = new Point(x, _centre - yVal);
                                    list.Add(new DiamondCharacterPoint() { Value = _cycleCharacter.CurrentChar, Coordinate = point });

                                    point = new Point(x, _centre + yVal);
                                    list.Add(new DiamondCharacterPoint() { Value = _cycleCharacter.CurrentChar, Coordinate = point });
                                }
                                else
                                {
                                    var point = new Point(x, (_centre - x) * -1);
                                    list.Add(new DiamondCharacterPoint() { Value = _cycleCharacter.CurrentChar, Coordinate = point });

                                    point = new Point(x, MatrixCount + (_centre - x));
                                    list.Add(new DiamondCharacterPoint() { Value = _cycleCharacter.CurrentChar, Coordinate = point });
                                }
                            }
                            else
                            {
                                var point = new Point(x, 0);
                                list.Add(new DiamondCharacterPoint() { Value = _cycleCharacter.CurrentChar, Coordinate = point });

                                point = new Point(x, MatrixCount);
                                list.Add(new DiamondCharacterPoint() { Value = _cycleCharacter.CurrentChar, Coordinate = point });
                            }
                        }
                        
                        _cycleCharacter.Next();
                    }
                    break;
            }

            return list;
        }

        public char[,] CreateArray()
        {
            var array = new char[MatrixCount + 1, MatrixCount + 1];

            var list = Create();
            foreach (var item in list)
            {
                array[item.Coordinate.Y, item.Coordinate.X] = item.Value;
            }
            return array;
        }
    }
}
