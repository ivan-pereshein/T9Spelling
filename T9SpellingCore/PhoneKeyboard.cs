using System;
using System.Collections.Generic;
using System.Text;

namespace T9Spelling
{
    public class PhoneKeyboard
    {
        public PhoneKeyboard()
        {
            // If PhoneKeyboard class will need to support other keyboard types (like Russian, French etc) 
            // then this responsibility (initialization of keys sequences for chars) may be easily extracted into special classes 
            // and injected via constructor (it won't affect tests or any existing code).
            InitCharsKeysSequences();
        }

        private void InitCharsKeysSequences()
        {
            _charsKeysSequences[' '] = "0";
            _charsKeysSequences['a'] = "2";
            _charsKeysSequences['b'] = "22";
            _charsKeysSequences['c'] = "222";
            _charsKeysSequences['d'] = "3";
            _charsKeysSequences['e'] = "33";
            _charsKeysSequences['f'] = "333";
            _charsKeysSequences['g'] = "4";
            _charsKeysSequences['h'] = "44";
            _charsKeysSequences['i'] = "444";
            _charsKeysSequences['j'] = "5";
            _charsKeysSequences['k'] = "55";
            _charsKeysSequences['l'] = "555";
            _charsKeysSequences['m'] = "6";
            _charsKeysSequences['n'] = "66";
            _charsKeysSequences['o'] = "666";
            _charsKeysSequences['p'] = "7";
            _charsKeysSequences['q'] = "77";
            _charsKeysSequences['r'] = "777";
            _charsKeysSequences['s'] = "7777";
            _charsKeysSequences['t'] = "8";
            _charsKeysSequences['u'] = "88";
            _charsKeysSequences['v'] = "888";
            _charsKeysSequences['w'] = "9";
            _charsKeysSequences['x'] = "99";
            _charsKeysSequences['y'] = "999";
            _charsKeysSequences['z'] = "9999";
        }

        /// <summary>
        /// Returns sequence of keys which should be pressed to input specified message.
        /// </summary>
        /// <param name="message">Text message.</param>
        public string GetPressedKeysSequence(string message)
        {
            var stringBuilder = new StringBuilder();

            // The key used for input of the previous character.
            var keyForPrevChar = '\0';

            foreach (char ch in message)
            {
                if (!_charsKeysSequences.ContainsKey(ch))
                    throw new ArgumentException($"Message contains unacceptable character [{ch}].");

                // Get sequence of pressed keys for the concrete character.
                var pressedKeysForChar = _charsKeysSequences[ch];

                // Need to set a pause mark if a previous character was inputted using the same key.
                if (keyForPrevChar == pressedKeysForChar[0])
                    stringBuilder.Append(PauseMark);

                stringBuilder.Append(pressedKeysForChar);

                keyForPrevChar = pressedKeysForChar[0];
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Magic const marking a pause in the pressed keys sequence.
        /// </summary>
        private const char PauseMark = ' ';

        /// <summary>
        /// Defines sequences of pressing keys for all acceptable characters.
        /// </summary>
        private readonly Dictionary<char, string> _charsKeysSequences = new Dictionary<char, string>();
    }
}
