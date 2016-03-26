
namespace DiamondKataLib
{
    public class CycleCharacter
    {
        private readonly char _startChar;
        int _incValue = -1;

        public CycleCharacter(char startChar)
        {
            _startChar = startChar;
            CurrentChar = _startChar;
        }

        public char CurrentChar { get; private set; }

        public char Next()
        {
            if (_startChar == 'A') return _startChar;

            var nextChr = (char)(CurrentChar + _incValue);

            if (nextChr == 'A') _incValue = 1;
            if (nextChr == _startChar) _incValue = -1;

            CurrentChar = nextChr;

            return nextChr;
        }
    }
}
