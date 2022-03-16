using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //Allows access to files and directories

namespace CMP1903M_Assessment_1_Base_Code
{
    //Class that will be used to create a file to store certain words
    class FileStore
    {
        //Method that analyses the text file and create an array with words longer than 7
        public void long_word_checker(ref string sentence_check) 
        {
            string[] sentence_words = sentence_check.Split(' '); //Each individual word is now an individual item in an array
            string[] long_words = new string[sentence_words.Length]; //Declares an empty string list
            string keyboard_symbols = System.IO.File.ReadAllText(@"C:\Users\Local User\Documents\GitHub\OOP_Code_Review\Keyboard Symbols.txt"); //Gets keyboard characters from the text file
            int word = 0; //Used as an index for the for loop and as counter for number of long words
            
            //For loop to convert the contents of keyboard_symbols into an array to be used
            string[] keyboard_symbols_array = new string[keyboard_symbols.Length]; //Declares an empty char list 
            for (int i = 0; i < keyboard_symbols.Length; i++) 
            {
                keyboard_symbols_array[i] = keyboard_symbols[i].ToString(); //Adds each character to this array
            }
            
            //Exception Handling in case of error when checking for valid words, or an index error
            try 
            {
                //For loop to obtain words that have more than 7 characters
                for (int i = 0; i < sentence_words.Length; i++)
                {
                    //If statement checks if the word has a length greater than 7
                    if (sentence_words[i].Length > 7)
                    {
                        //If statement checks if word contains characters other than letters by comparing to ASCII table
                        if (!keyboard_symbols_array.Contains(sentence_words[i]))
                        {
                            long_words[word] = sentence_words[i]; //Adds the word to the array
                            word += 1;
                        }                                                                                                     
                    }
                }
            
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }

            //For loop that will output the long words to console
            for (int j = 0; j < long_words.Length; j++) 
            {
                Console.WriteLine(long_words[j]);
            }

            file_make(ref long_words); //Calls the method, with long_words as a parameter
            return;
        }

        //Method that creates the text file that will host these long words
        public void file_make(ref string[] long_words) 
        {
            using StreamWriter text_file = new StreamWriter("Long_Words_Store.txt"); //Creates a new file called Long_Words_Store
            
            //Foreach loop used to add each word from the long_words array to the file on a new line
            foreach(string word in long_words) 
            {
                text_file.WriteLine(word); //Writes the word to the text file
            }
            Console.WriteLine("Long Word File Successfully Created");
            return;
        }
    }
}
