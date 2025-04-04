using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading;

namespace Chatbot_Poe_Part1
{
    public class ChatBot_Ai
    {
        //declaring and initializing variables
        List<string> replies = new List<string>(); //array that stores replies 
        List<string> ignore = new List<string>(); //array that stores ignored words

        private string name;
        private string CybersecurityTip;

        //constructor
        public ChatBot_Ai()
        {

            //call methods in the constructor
            Logo();//method to display Ascii art
            Greeting();//method to play audio wav file
            userInfo();//method to collect the user details
            MainMenu();//method to display the menu options
        }//end of constructor

        //method to play greeting audio
        private void Greeting()
        {
            // Getting full location of the project
            string full_location = System.AppDomain.CurrentDomain.BaseDirectory;

            // Replace the bin\Debug folder in the full_location
            string new_path = full_location.Replace("bin\\Debug\\", "");

            // Try and catch
            try
            {
                string full_path = Path.Combine(new_path, "greeting.wav");

                // Now we create an instance for the SoundPlay class
                using (SoundPlayer play = new SoundPlayer(full_path))
                {
                    // Play the file
                    play.PlaySync();
                } // End of using
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
            } // End of catch
        } // End of welcome audio method

        //method to display the logo
        private void Logo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string paths = AppDomain.CurrentDomain.BaseDirectory;
            //then replace the bin\\bebug\\
            string new_path = paths.Replace("bin\\Debug\\", "");
            //then combine the logo and the image
            string full_path = Path.Combine(new_path, "chat.jpeg");

            Bitmap Logo = new Bitmap(full_path);
            Logo = new Bitmap(Logo, new Size(120, 100));

            for (int height = 0; height < Logo.Height; height++)
            {
                //for width
                for (int width = 0; width < Logo.Width; width++)
                {
                    Color pixelColor = Logo.GetPixel(width, height);
                    int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char asciiChar = gray > 250 ? '.' : gray > 150 ? '*' : gray > 100 ? 'o' : gray > 50 ? '#' : '@';
                    Console.Write(asciiChar);
                }//end of loop in a loop
            }//end of loop
            Console.ResetColor();//changes the color back to default
        }//end of logo design method

        //method that will store the user details
        private void userInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue; //chatbot ai text color
            Console.WriteLine("=========================================================================================================");
            TypeWriterEffect("Chatbot AI -> Please enter your name:", 30);
            Console.WriteLine("=========================================================================================================");
            Console.ForegroundColor = ConsoleColor.White; //user text color
            Console.Write("user -> ");
            name = Console.ReadLine();

            // Combined validation for empty input and letters-only
            while (true)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeWriterEffect("Chatbot AI -> Invalid input! Please do not leave the space empty!", 30);
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeWriterEffect("Chatbot AI -> Invalid input! Names should contain only letters and spaces.", 30);
                }
                else
                {
                    break; // Input is valid
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("user -> ");
                name = Console.ReadLine();
            }

            Console.WriteLine("=========================================================================================================");
            TypeWriterEffect($"ChatBot AI-> I have saved your name as {name}", 30);
            Console.ForegroundColor = ConsoleColor.Blue; //chatbot ai text color
            TypeWriterEffect("Please enter your favourite cybersecurity tip:", 30);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("user -> ");
            CybersecurityTip = Console.ReadLine();

            // Validation for cybersecurity tip
            while (string.IsNullOrWhiteSpace(CybersecurityTip))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                TypeWriterEffect("Chatbot AI -> Invalid input! Please enter your favourite cybersecurity tip:", 30);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("user -> ");
                CybersecurityTip = Console.ReadLine();
            }

            TypeWriterEffect($"I will remember that your favourite cybersecurity tip is {CybersecurityTip}", 30);

            Boolean validInput = false;
            while (!validInput)
            {
                Console.WriteLine("\n=========================================================================================================");
                TypeWriterEffect("Chatbot AI -> Would you like to see your details (yes/no) ", 30);
                Console.Write($"{name} -> ");
                Console.ForegroundColor = ConsoleColor.White; //user text color
                string optionone = Console.ReadLine()?.ToLower();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("=========================================================================================================");

                switch (optionone)
                {
                    case "yes":
                        Console.WriteLine("\n=========================================================================================================");
                        TypeWriterEffect("ChatBot AI-> you selected 'yes'", 30);
                        TypeWriterEffect($"Your full name is {name}", 30);
                        TypeWriterEffect($"Your favourite cybersecurity fact is {CybersecurityTip}", 30); 
                        TypeWriterEffect("**************************taking you to the main menu**************************", 30);
                        validInput = true;
                        break;

                    case "no":
                        TypeWriterEffect("you selected 'no'", 30);
                        TypeWriterEffect("**************************taking you to the main menu**************************", 30);
                        validInput = true;
                        break;

                    default:
                        TypeWriterEffect("invalid option!! try again", 30);
                        break;
                }//end of switch statement
            }//end of while loop
        }//end of method userInfo



        //method for the main menu that contains all the available options
        private void MainMenu()
        {
            ClearConsole();
            Console.ForegroundColor = ConsoleColor.Blue; //chatbot ai text color
            Console.WriteLine("===================================================================================================================");
            Console.WriteLine("__        __   _                            _          _   _          \r\n\\ \\      / /__| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___ \r\n \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\ | __/ _ \\  | __| '_ \\ / _ \\\r\n  \\ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/\r\n __\\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|  \\__\\___/   \\__|_| |_|\\___|\r\n|  \\/  | __ _(_)_ __    _ __ ___   ___ _ __  _   _                    \r\n| |\\/| |/ _` | | '_ \\  | '_ ` _ \\ / _ \\ '_ \\| | | |                   \r\n| |  | | (_| | | | | | | | | | | |  __/ | | | |_| |                   \r\n|_|  |_|\\__,_|_|_| |_| |_| |_| |_|\\___|_| |_|\\__,_|                   ");
            Console.WriteLine("===================================================================================================================");
            TypeWriterEffect($"Chatbot AI -> Welcome to the main menu {name} ", 30);
            TypeWriterEffect("ChatBot AI-> Pick an option (numbers only)", 30);
            TypeWriterEffect("1. View user details \n2. Ask ChatBot AI questions \n3. Close", 30);
            Console.ForegroundColor = ConsoleColor.White; //user text color
            Console.Write($"{name} -> ");
            string optiontwo = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; //chatbot ai text color

            Boolean validInput2 = false; //boolean that will run the switch statement continously until a valid option is selected

            while (!validInput2)
            {
                //switch statement that reads the userinput 
                switch (optiontwo)
                {
                    case "1":
                        TypeWriterEffect("ChatBot AI-> You have selected option: " + optiontwo, 30);
                        TypeWriterEffect($"Your full name is {name}", 30);
                        TypeWriterEffect($"Your favourite cybersecurity fact is{CybersecurityTip}", 30);
                        validInput2 = true;
                        MainMenu();
                        break;
                    case "2":
                        TypeWriterEffect("ChatBot AI-> You have selected option: " + optiontwo, 30);
                        FilterandSort();
                        validInput2 = true;
                        MainMenu();
                        break;
                    case "3":
                        TypeWriterEffect("ChatBot AI-> You have selected option: " + optiontwo, 30);
                        TypeWriterEffect($"Before you leave {name}, i still remember your favourite cybersecuity tip {CybersecurityTip}", 30);
                        TypeWriterEffect("Goodbye", 30);
                        validInput2 = true;
                        break;
                    default:
                        TypeWriterEffect($"ChatBot AI-> Pleae select a valid number {name}!", 30);
                        optiontwo = Console.ReadLine();
                        break;
                }//end of switch statement
            }//end of while loop
        }//end of main menu method

        //method to show a countdown then clear all the text on the screen
        private void ClearConsole(string notice = "Clearing console", int timer = 5)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n {notice}");

            //for loop to countdown from 5 till 0 
            //when the loop ends The console will be cleared 
            for (int i = timer; i > 0; i--)
            {
                Console.Write($"{i}... ");
                Thread.Sleep(1000); // 1 second delay
            }//end of for loop
            Console.Clear();
        }//end of clear console method

        //method to filter and sort questions
        private void FilterandSort()
        {
            //call both methods to auto store the values
            Store_ignore();
            Store_replies();

            //main question loop
            while (true)
            {
                ClearConsole();//calling this method to clear the console

                Console.ForegroundColor = ConsoleColor.Blue; //chatbot ai text color
                Console.WriteLine("\n=========================================================================================================");
                Console.WriteLine("    _        _       ____ _           _   ____        _        _    ___   \r\n   / \\   ___| | __  / ___| |__   __ _| |_| __ )  ___ | |_     / \\  |_ _|  \r\n  / _ \\ / __| |/ / | |   | '_ \\ / _` | __|  _ \\ / _ \\| __|   / _ \\  | |   \r\n / ___ \\\\__ \\   <  | |___| | | | (_| | |_| |_) | (_) | |_   / ___ \\ | |   \r\n/_/   \\_\\___/_|\\_\\  \\____|_| |_|\\__,_|\\__|____/ \\___/ \\__| /_/   \\_\\___|  \r\n        __ _ _   _  ___  ___| |_(_) ___  _ __  ___                        \r\n       / _` | | | |/ _ \\/ __| __| |/ _ \\| '_ \\/ __|                       \r\n      | (_| | |_| |  __/\\__ \\ |_| | (_) | | | \\__ \\                       \r\n       \\__, |\\__,_|\\___||___/\\__|_|\\___/|_| |_|___/                       \r\n          |_|                                                             ");
                Console.WriteLine("\n=========================================================================================================");
                //prompting the user for the question
                Console.WriteLine("\n=========================================================================================================");
                TypeWriterEffect("  ChatBot AI -> You can ask me about ", 30);
                TypeWriterEffect($" I hope I may be of assistance today in helping you further your understanding on {CybersecurityTip}", 30);
                Console.WriteLine("| 1. My purpose                                                                                            |");
                Console.WriteLine("| 2. Password safety                                                                                       |");
                Console.WriteLine("| 3. Safe browsing                                                                                         |");
                TypeWriterEffect("  Enter your question (or type 'menu' to return to menu)", 30);
                Console.WriteLine("===========================================================================================================");
                Console.ForegroundColor = ConsoleColor.White;
                string question = Console.ReadLine();

                // Add empty input validation
                while (string.IsNullOrWhiteSpace(question))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeWriterEffect("Chatbot AI -> Invalid input! Please enter a question or 'menu' to return", 30);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{name} -> ");
                    question = Console.ReadLine();
                }

                Console.ForegroundColor = ConsoleColor.Blue;

                //exit condition
                if (question?.ToLower() == "menu")
                    break;

                //making use of split function to store each word
                string[] store_word = question.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ArrayList store_final_words = new ArrayList();

                //for loop to check and store the words
                for (int count = 0; count < store_word.Length; count++)
                {
                    //if statement to check if words in 1D array are not ignored
                    if (!ignore.Contains(store_word[count].ToLower()))
                    {
                        //then store the not ignored word
                        store_final_words.Add(store_word[count]);
                    }//end of if statement
                }//end of for loop for checking words

                //temp variables 
                Boolean found = false;
                string message = String.Empty;

                // Loop through each word in the filtered words list (words that weren't ignored)
                for (int counting = 0; counting < store_final_words.Count; counting++)
                {
                    // Get the current word from the filtered list and convert to string
                    string currentWord = store_final_words[counting].ToString();

                    // Search all replies for matches with the current word
                    for (int count = 0; count < replies.Count; count++)
                    {
                        // Get the current reply from the knowledge base
                        string currentReply = replies[count];

                        // Check if the current reply contains the current word
                        if (currentReply.IndexOf(currentWord, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            // If match found:

                            message += "ChatBot AI-> " + currentReply + "\n";


                            found = true;
                        }
                    }
                }

                //display error message or answers
                if (found)
                {
                    //then display
                    TypeWriterEffect(message, 40);
                }
                else
                {
                    TypeWriterEffect("ChatBot AI-> Try a different question!", 30);
                }//end of display statement
            }//end of main question loop
        }//end of filter and sort method

        //method to store replies
        private void Store_replies()
        {
            // Phishing responses
            replies.Add("phishing : attacks often come through emails pretending to be from trusted sources - always verify sender addresses.");
            replies.Add("phishing : watch for urgent language in messages asking for personal info - this is a common scam tactic.");

            // Safe browsing responses
            replies.Add("safe browsing : always look for the padlock icon and 'https://' in website addresses.");
            replies.Add("safe browsing : Keep your browser updated and avoid downloading files from untrusted sources.");

            //password responses
            replies.Add("password safety : Always use a mix of uppercase, lowercase, numbers, and symbols!");
            replies.Add("password safety : Never reuse passwords across different accounts.");
            // Purpose responses
            replies.Add("purpose : I'm a cybersecurity chatbot designed to help you understand online threats and protection methods.");
            replies.Add("purpose : is to provide basic cybersecurity awareness and answer your related questions.");

            // Greeting responses
            replies.Add("hello , I'm an AI assistant, so I don't have feelings, but I'm ready to help with cybersecurity questions!");
        }//end of store replies method

        //method to store ignored words
        private void Store_ignore()
        {
            ignore.Add("tell");
            ignore.Add("me");
            ignore.Add("about");
            ignore.Add("are");
            ignore.Add("you");
            ignore.Add("your");
            ignore.Add("whats");
            ignore.Add("can");
            ignore.Add("i");
            ignore.Add("ask");
            ignore.Add("safety");
            ignore.Add("safe");
            ignore.Add("and");
            ignore.Add("also");
            ignore.Add("with");
            ignore.Add("together");
        }//end of store ignore method

        //method that delays the console text output
        private void TypeWriterEffect(string text, int delayMs = 50)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(delayMs); // Pause between characters
            }
            Console.WriteLine(); // Move to next line after typing
        }
    }//end of class
}//end of namespace