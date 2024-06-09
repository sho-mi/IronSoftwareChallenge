# OldKeyPad: .NET 8.0 Console Application
     
**Overview**

OldKeyPad is a .NET 8.0 Console Application designed to emulate the functionality of the keypad found on old mobile devices. It processes a given input string to produce text as if typed on such a keypad, which will be used as a text message.

**Problem Description**

The application simulates a classic mobile keypad with 12 keys:

* Keys from 0-9: Used to enter characters and numbers.
* \* key: Acts as a backspace.
* \# key: Acts as a submit button.

Furthermore - 
* Key 0: Used to insert a space between characters.
* Keys 1-9: Each key corresponds to a set of characters (letters, numbers, and symbols). Pressing a key multiple times cycles through the characters assigned to that key, and the final character selected is displayed.

**Functionality**

* Character Entry: Pressing keys 1-9 cycles through the characters assigned to each key. For example, pressing key 2 could cycle through 'a', 'b', 'c', and '2'.
* Space Insertion: Pressing key 0 inserts a space between characters.
* Backspace: Pressing the * key deletes the last character entered.
* Submit: Pressing the # key finalizes the input and sends the text message.

This application allows users to input text as they would on an old school mobile device, providing a nostalgic and functional experience.


## Deep Dive into the Solution

The Solution has been implemented in the class - **OldKeyPad** under the method - **OldPhonePad** which has a pre-defined signature of -
**public static string OldPhonePad(string input);**.








