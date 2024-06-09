using System.Text;

namespace Keypad
{
    public class OldKeyPad
    {
        // contains mapping of symbols to corresponding characters
        private static readonly Dictionary<char, string> keys = new Dictionary<char, string>
        {
            { '0', " " },
            { '1', "&,(" },
            { '2', "ABC" },    
            { '3', "DEF" },  
            { '4', "GHI" },   
            { '5', "JKL" },   
            { '6', "MNO" },   
            { '7', "PQRS" },   
            { '8', "TUV" },   
            { '9', "WXYZ" },
        };

        private const char ACTION_KEY_SUBMIT = '#'; // CODE FOR SUBMIT KEY
        private const char ACTION_KEY_BACKSPACE = '*'; // CODE FOR BACKSPACE KEY
        private const char PAUSE = ' '; // CODE FOR PAUSE SEQUENCE

        /// <summary>
        /// method with pre-defined structure, which takes a character sequence as input 
        /// and returns output which will be displayed on screen
        /// </summary>
        /// <param name="input" type="string"></param>
        /// <returns></returns>
        public static string OldPhonePad(string input)
        {
            int pressedCount = 0; // local variable to track how many times a key was pressed
            char currentPressedKey = '^'; // local varible which acts as a buffer before flushing a character to the screen

            StringBuilder output = new StringBuilder(); // string builder in which the output will be stored
            
            foreach (char c in input)
            {
                if (c >= '0' && c <= '9') // One of the digits was pressed
                {

                    if (c == currentPressedKey) // currentPressedKey pressed 1 more time
                    {
                        pressedCount++;
                    }
                    else // a key other than currentPressedKey was pressed
                    {
                        if (currentPressedKey != '^')
                        {
                            var lastChar = GetCharFromKeyPress(currentPressedKey, pressedCount);
                            output.Append(lastChar); // Adds character for currentPressedKey to output
                        }
                        currentPressedKey = c;
                        pressedCount = 1;
                    }
                }
                else if (c == ACTION_KEY_BACKSPACE)
                {
                    handleBackspaceClick(ref pressedCount, ref currentPressedKey, output);
                }
                else if (c == ACTION_KEY_SUBMIT)
                {
                    handleSubmitClick(pressedCount, currentPressedKey, output);
                    break; // breaks out of loop on submit and returns the output
                }
                else if (c == PAUSE)
                {
                    handlePause(ref pressedCount, ref currentPressedKey, output);
                }
            }
            return output.ToString();
        }

        /// <summary>
        /// method to handle click functionality for backspace button
        /// </summary>
        /// <param name="pressedCount" type="integer"></param>
        /// <param name="currentPressedKey" type="character"></param>
        /// <param name="output" type="StringBuilder"></param>
        private static void handleBackspaceClick(ref int pressedCount, ref char currentPressedKey, StringBuilder output)
        {
            if (currentPressedKey != '^')
            {
                pressedCount = 0;
                currentPressedKey = '^'; // Removes the character in the buffer
            }
            else if (output.Length > 0)
            {
                output.Length -= 1; // Removes the last character added to output if none is available in buffer
            }
        }

        /// <summary>
        /// method to handle Pause functionality
        /// </summary>
        /// <param name="pressedCount" type="integer"></param>
        /// <param name="currentPressedKey" type="character"></param>
        /// <param name="output" type="StringBuilder"></param>
        private static void handlePause(ref int pressedCount, ref char currentPressedKey, StringBuilder output)
        {
            if (currentPressedKey != '^')
            {
                var lastChar = GetCharFromKeyPress(currentPressedKey, pressedCount);
                output.Append(lastChar); // Adds previous character to the output
                pressedCount = 0; // Resets the pressed count for current key
                currentPressedKey = '^'; // Resets the current sequence
            }
        }

        /// <summary>
        /// method which contains logic to handle Submit button click
        /// </summary>
        /// <param name="pressedCount" type="integer"></param>
        /// <param name="currentPressedKey" type="character"></param>
        /// <param name="output" type="StringBuilder"></param>
        private static void handleSubmitClick(int pressedCount, char currentPressedKey, StringBuilder output)
        {
            if (currentPressedKey != '^')
            {
                var lastChar = GetCharFromKeyPress(currentPressedKey, pressedCount);
                output.Append(lastChar); // Adds previous character to the output
            }
        }

        /// <summary>
        /// method which returns character to be added to output,
        /// on the basis of key pressed and number of times it was pressed
        /// </summary>
        /// <param name="key" type="character"></param>
        /// <param name="pressedCount" type="integer"></param>
        /// <returns></returns>
        private static char GetCharFromKeyPress(char key, int pressedCount)
        {
            if (keys[key].Length == 0)
            {
                return '\n';
            }
            int index = (pressedCount - 1) % keys[key].Length; // Fetch character for a given key on the basis of pressed count
            return keys[key][index];
        }
    }
}
