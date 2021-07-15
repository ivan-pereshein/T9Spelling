using System;
using NUnit.Framework;

namespace T9Spelling.Tests
{
    [TestFixture]
    public class PhoneKeyboardTest
    {
        [Test]
        [TestCase("", "")]  // Empty line
        [TestCase("   ", "0 0 0")] // Only spaces
        [TestCase("  abc", "0 02 22 222")] // Leading spaces
        [TestCase("abc   ", "2 22 2220 0 0")] // Trailing spaces
        [TestCase("a", "2")] // One symbol.
        [TestCase("k", "55")] // One symbol.
        [TestCase("z", "9999")] // Last symbol.
        [TestCase("hi", "44 444")] // Tests taken from Problem C.
        [TestCase("yes",  "999337777")]
        [TestCase("foo  bar", "333666 6660 022 2777")]
        [TestCase("hello world", "4433555 555666096667775553")]
        public void Test(string message, string expectedPressedKeysSequence)
        {
            var phoneKeyboard = new PhoneKeyboard();
            var result = phoneKeyboard.GetPressedKeysSequence(message);
            Assert.AreEqual(expectedPressedKeysSequence, result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUnacceptableCharacter()
        {
            var phoneKeyboard = new PhoneKeyboard();
            phoneKeyboard.GetPressedKeysSequence("This is Σ sigma");
        }

    }
}
