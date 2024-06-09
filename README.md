# OldKeyPad: .NET 8.0 Console Application
     
## Overview

OldKeyPad is a .NET 8.0 Console Application designed to emulate the functionality of the keypad found on old mobile devices. It processes a given input string to produce text as if typed on such a keypad, which will be used as a text message.

## Detailed Description of how an old keypad looks like

A classic mobile keypad contains 12 keys:

* **Keys from 0-9**: Used to enter characters and numbers.
* **\* key**: Acts as a backspace.
* **\# key**: Acts as a submit button.

Furthermore - 
* **Key 0**: Used to insert a space between characters.
* **Keys 1-9**: Each key corresponds to a set of characters (letters, numbers, and symbols). Pressing a key multiple times cycles through the characters assigned to that key,
  and the final character selected is displayed.

## Detailed Description of how an old keypad functions

* Character Entry: Pressing keys 1-9 cycles through the characters assigned to each key. For example, pressing key 2 could cycle through 'a', 'b', 'c', and '2'.
* Space Insertion: Pressing key 0 inserts a space between characters.
* Backspace: Pressing the <strong>*</strong> key deletes the last character entered.
* Submit: Pressing the **#** key finalizes the input and sends the text message.

This application allows users to input text as they would on an old school mobile device, providing a nostalgic and functional experience.

**Assumption**: All the input strings will have **#** character as the last character of the sequence, to signify that the message has been submitted/sent.

## Solution Code Overview

The solution code features a dictionary named **keys** that maps key codes to their corresponding alphanumeric characters, which can be accessed by pressing the specified key.

Additionally, several constants are defined for special key codes, such as **#** and **\***. A constant for **Pause** is also defined, which, while not an actual key code, indicates a delay beyond a certain threshold between the input events of two characters.

The solution is implemented within the **OldKeyPad** class, specifically in the **OldPhonePad** method, which has the predefined signature: **public static string OldPhonePad(string input)**. 
This method processes the input string, generating the output text to be sent as a text message once the **#** key code is encountered.

## Methodology
To convert the input into the desired output, the method employs three state variables:

* **output**: Stores the intermediate result, which is eventually returned as the output once the **#** key code is encountered.
* **currentPressedKey**: Tracks the current character from the input being processed, with a default value of **^**.
* **pressedCount**: Records the number of consecutive presses of the same key, with a default value of 0.

## Helper Methods
Four helper methods are defined to assist **OldPhonePad** in generating the output:

* **GetCharFromKeyPress**: Iterates over the list of characters for a given key code and returns the final character based on the number of times the key was pressed.
* **HandleSubmitClick**: Adds the final character to the output when the **#** key is encountered.
* **HandlePause**: Determines the last character based on pressedCount, adds it to the output, and resets the state variables.
* **HandleBackspaceClick**: Clears the state variables when the **\*** key is pressed. If there is no data in the state variables, it removes the last character from the output.


## Process Flow
1. Loop Through Input: The method loops through the provided input string.
2. Character Processing: It processes each character based on the state variables and the key codes.
3. Output Generation: It builds the output text incrementally, updating state variables as needed.
4. Final Output: The final text message is generated and returned once the **#** key code is encountered.


By following this structure, the OldPhonePad method efficiently simulates the behavior of an old school mobile keypad to produce the desired text message output.








