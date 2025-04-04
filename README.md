Project Details
Project Name: Chatbot_Poe_Part1

.NET Framework: 4.7.2

Template: Console Application (C#)

Key Features
1. ASCII Art Logo
Technology: System.Drawing.Bitmap

Process:

Converts chat.jpeg to ASCII characters by analyzing pixel brightness

Displays using colored console output

Error Handling: Shows "error image is not found!" if file missing
2. Voice Greeting
Technology: System.Media.SoundPlayer

Behavior:

Plays greeting.wav synchronously on startup

Error message displayed if file not found
 User Interaction System
A. Name Collection:

Validates input:

Rejects empty entries

Allows only letters/spaces (no numbers)

Cybersecurity Tip:

Stores user's security tip in CybersecurityTip variable

Validates non-empty input

C. Main Menu:

1. View user details
2. Ask questions
3. Exit


Question Handling 
Core Components:

List<string> replies = new List<string>();  // Knowledge base
List<string> ignore = new List<string>();   // Filtered words
Processing Flow:

1.Input Cleaning:

Splits question into words

Removes ignored words ("whats", "tell", etc.)

2.Keyword Matching:

Case-insensitive comparison against replies

3.Response Generation:

Displays all matching replies

Typewriter effect with 40ms delay per character

Error Cases:

Empty input: "Please enter a valid question"

No matches: "I don't understand please rephrase..."

User Guide
1. Startup Sequence
ASCII logo renders

Voice greeting plays

Displays welcome message

2. Interaction Flow
example of the chatbot interaction flow

=================================================================
Chatbot AI -> Please enter your name:
=================================================================
user -> Alice
ChatBot AI-> I have saved your name as Alice
Please enter your favourite cybersecurity tip:
user -> Use strong passwords
=================================================================
Would you like to see your details (yes/no) 
Alice -> yes
Your full name is Alice
Your favourite cybersecurity fact is Use strong passwords
3. Question Answering
Valid Questions:

"password safety"

"phishing emails"

"safe browsing"

Output Example:

ChatBot AI-> password safety : Never reuse passwords across accounts.
ChatBot AI-> password safety : Always use a mix of character types!
4. Exit Protocol
Type "menu" during questions or select option 3

Displays personalized goodbye: 
TypeWriterEffect($"Goodbye {name}, remember: {CybersecurityTip}", 30);

Technical Highlights
1.Typewriter Effect:

Thread.Sleep(delayMs); // Between characters

2. Console Formatting:

User input: White

Bot responses: Blue

Errors: Red

3. Input Validation:

Name: Letters only

Cybersecurity tip: Non-empty

Menu options: Numeric check

Example of the session

 __        __   _                            _          _   _          
\ \      / /__| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___ 
 \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \
  \ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/
   \_/\_/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \__|_| |_|\___|

Welcome to the Cyber Security Awareness Bot

Chatbot AI -> Please enter your name:
user -> Bob
ChatBot AI-> I have saved your name as Bob
Please enter your favourite cybersecurity tip:
user -> Enable 2FA
=================================================================
1. View details | 2. Ask questions | 3. Exit
Bob -> 2

ChatBot AI -> You can ask me about:
1. Password safety
2. Phishing
3. Safe browsing

You: how to spot phishing
Chatbot is typing...
ChatBot AI-> phishing : watch for urgent language in messages...
ChatBot AI-> phishing : verify sender addresses...
