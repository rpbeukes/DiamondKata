using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace DiamondKataTests
{
    [TestClass]
    public class CycleCharacterTests
    {
        [TestMethod]
        public void CycleCharacter_Next_should_cycle_through_character()
        {
            var cycleCharacter = new DiamondKataLib.CycleCharacter('C');
            var nextChar = cycleCharacter.Next();
            nextChar.ShouldBe('B');
            nextChar = cycleCharacter.Next();
            nextChar.ShouldBe('A');
            nextChar = cycleCharacter.Next();
            nextChar.ShouldBe('B');
            nextChar = cycleCharacter.Next();
            nextChar.ShouldBe('C');
            nextChar = cycleCharacter.Next();
            nextChar.ShouldBe('B');
            nextChar = cycleCharacter.Next();
            nextChar.ShouldBe('A');
            nextChar = cycleCharacter.Next();
            nextChar.ShouldBe('B');
        }

        [TestMethod]
        public void CycleCharacter_Next_should_not_Cycle_when_A()
        {
            var cycleCharacter = new DiamondKataLib.CycleCharacter('A');
            var nextChar = cycleCharacter.Next();
            nextChar.ShouldBe('A');
            nextChar = cycleCharacter.Next();
            nextChar.ShouldBe('A');
        }
    }
}
