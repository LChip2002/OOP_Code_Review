using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Allows access to files and directories

namespace CMP1903M_Assessment_1_Base_Code
{
    // Class that will be used to create a file to store certain words
    class FileStore
    {
        // Method that analyses the text file and create an array with words longer than 7
        public void long_word_checker(ref string sentence_check) 
        {
            string[] sentence_words = sentence_check.Split(' '); // Each individual word is now an individual item in an array
            string[] long_words = new string[sentence_words.Length]; // Declares an empty string array
            string keyboard_symbols; // Declares the string variable so can be used in local try catch scope as well as in the scope of the method
            string[] punctuation = {".",",","!","?",";",":","'","*"}; // Declares array that will be used as a back up if any words slip past keyboard_symbol check
            
            // Exception handling used here in case the full file directory is not present in the user's device
            try 
            {
                // Gets keyboard characters from the text file
                keyboard_symbols = System.IO.File.ReadAllText(@"C:\Users\Local User\Documents\GitHub\OOP_Code_Review\Keyboard_Symbols.txt"); 
            }
            catch (Exception) 
            {
                Console.WriteLine("Original directory doesn't exist on device, searching for file now");
                keyboard_symbols = symbol_file_search(); // Calls file search function
            }
           
            int word = 0; // Used as an index for the for loop and as counter for number of long words
            
            // For loop to convert the contents of keyboard_symbols into an array to be used
            string[] keyboard_symbols_array = new string[keyboard_symbols.Length]; // Declares an empty char list 
            for (int i = 0; i < keyboard_symbols.Length; i++) 
            {
                keyboard_symbols_array[i] = keyboard_symbols[i].ToString(); //Adds each character to this array
            }
            
            // Exception Handling in case of error when checking for valid words, or an index error
            try 
            {
                // For loop to obtain words that have more than 7 characters
                for (int i = 0; i < sentence_words.Length; i++)
                {
                    // If statement checks if the word has a length greater than 7
                    if (sentence_words[i].Length > 7)
                    {
                        // If statement checks if word contains characters other than letters by comparing to ASCII table
                        if (!keyboard_symbols_array.Contains(sentence_words[i]))
                        {
                            long_words[word] = sentence_words[i]; // Adds the word to the array
                            word += 1;
                        } 
                        else if (!punctuation.Contains(sentence_words[i])) 
                        {
                            long_words[word] = sentence_words[i]; // Adds the word to the array
                            word += 1;
                        }
                    }
                    else 
                    {
                        continue;
                    }
                }
            
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
            
            file_make(ref long_words); // Calls the method, with long_words as a parameter
        }

        // Method that creates the text file that will host these long words
        public void file_make(ref string[] long_words) 
        {
            using StreamWriter text_file = new StreamWriter("Long_Words_Store.txt"); // Creates a new file called Long_Words_Store
            
            // Foreach loop used to add each word from the long_words array to the file on a new line
            foreach(string word in long_words) 
            {
                text_file.WriteLine(word); // Writes the word to the text file
            }
            Console.WriteLine("Long Word File Successfully Created");

            // Gives the user the option to view all of the long words that are in the text file
            bool correct_input = false;
            while (correct_input == false) // While loop will keep going until a valid input has been entered 
            {
                Console.WriteLine("Do you want to view the long words: Y/N");
                var decision = Console.ReadLine();

                if (decision == "Y" || decision == "y")
                {
                    correct_input = true;
                    Console.Clear(); // Clears the console

                    // For loop that will output the long words to console
                    for (int j = 0; j < long_words.Length; j++)
                    {
                        if (long_words[j] == "*")
                        {
                            break; // Loop breaks if an asterisk is found 
                        }
                        else if (long_words[j] == null) 
                        {
                            continue;
                        }
                        
                        Console.WriteLine(long_words[j]);
                    }

                }
                else if (decision == "N" || decision == "n")
                {
                    Console.WriteLine("You have chosen not to view the long words");
                    correct_input = true;
                }
                else
                {
                    Console.WriteLine("Error: Invalid input, you need to input Y/N");
                }
            }
            
        }

        // Method searches for the text file on the user's device
        private string symbol_file_search() 
        {
            // Gets the full directory that the file is in on the user's device
            string keyboard_symbols = System.IO.File.ReadAllText(Path.GetFullPath("Keyboard_Symbols.txt"));
            return keyboard_symbols;    
        }
    }
}
