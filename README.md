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
* Keys 1-9: Each key corresponds to a set of characters (letters, numbers, and symbols). Pressing a key multiple times cycles through the characters assigned to that key,
  and the final character selected is displayed.

**Functionality**

* Character Entry: Pressing keys 1-9 cycles through the characters assigned to each key. For example, pressing key 2 could cycle through 'a', 'b', 'c', and '2'.
* Space Insertion: Pressing key 0 inserts a space between characters.
* Backspace: Pressing the * key deletes the last character entered.
* Submit: Pressing the # key finalizes the input and sends the text message.

This application allows users to input text as they would on an old school mobile device, providing a nostalgic and functional experience.

**Assumption**
All the input strings will have **#** character as the last character of the sequence, to signify that the message has been submitted/sent.

## Deep Dive into the Solution

The Solution code contains a dictionary named **keys** which contains the mapping between key codes and the alphanumeric characters which can be accessed by clicking the key marked with the particular key code.

Also, constants have been defined to contain the key codes which are of special significance - **#**, **\***. One constant has been defined to signify Pause, which isn't a keycode, but marks a delay above a certain threshold between input of 2 character.

The Solution has been implemented in the class - **OldKeyPad** under the method - **OldPhonePad** which has a pre-defined signature of -
**public static string OldPhonePad(string input);**. In the mentioned method, we loop through the input provided and try to generate the output text, which we will be sent as a text message, once the **#** keycode is encountered. 

To transform the input into output, three state variables have been defined in the above mentioned method. 

* **output** - contains the intermediate result and finally is returned as output, once the **#** keycode is encountered.
* **currentPressedKey** - keeps track of current character from input, being interated. It has a default value of **^**.
* **pressedCount** - keeps track of the number of times - the same character was pressed repeatedly.

Also, Four helper methods have been defined to be used by **OldPhonePad** in calculating the output -

* **GetCharFromKeyPress** - iterates over the list of characters for a given keycode and returns the final character which will be added to output, on the basis of number of times a key was pressed.
* **HandleSubmitClick** - Adds the final character to output once **#** is encountered.
* **HandlePause** - gets the last character on the basis of **pressedCpunt** and adds it to output. Additionally, resets the state variables.
* **HandleBackspaceClick**- on press of **\*** key, clears the state variables. If they don't contain any data, then removes last character from output.








