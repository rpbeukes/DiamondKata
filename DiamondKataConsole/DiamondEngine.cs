using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DiamondKataConsole
{
    public class DiamondEngine
    {
        private readonly char _patternChar;

        public DiamondEngine(char diamondChar)
        {
            _patternChar = diamondChar;

        }

        private int MatrixCount
        {
            get
            {
                int count = _patternChar - 'A';
                return count <= 1 ? 3 /* 'A' and 'B' only */
                                     : count * 2 + 1;
            }
        }

        public IEnumerable<DiamondCharacter> Create()
        {
            var list = new List<DiamondCharacter>();
            switch (_patternChar)
            {
                case 'A':
                    list.Add(new DiamondCharacter() { Value = _patternChar, Coordinate = new Point(1, 0) });
                    list.Add(new DiamondCharacter() { Value = _patternChar, Coordinate = new Point(0, 1) });
                    list.Add(new DiamondCharacter() { Value = _patternChar, Coordinate = new Point(1, 2) });
                    list.Add(new DiamondCharacter() { Value = _patternChar, Coordinate = new Point(2, 1) });
                    break;
                case 'B':

                    break;
                default:
                    //for (int i = 0; i < MatrixCount; i++)
                    //{

                    //}
                    break;
            }

            return list;
        }

    }
}
