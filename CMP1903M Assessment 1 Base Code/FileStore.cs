using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    //Class that will be used to create a file to store certain words
    class FileStore
    {
        //Method that analyses the text file and create an array with words longer than 7
        public void long_word_checker(ref string sentence_check) 
        {
            string[] sentence_words = sentence_check.Split(' '); //Each individual word is now an individual item in an array
            string[] long_words = new string[sentence_words.Length]; //Decalres an empty string list
            int word = 0; //Used as an index for the for loop and as counter for number of long words
            try 
            {
                //For loop to obtain words that have more than 7 characters
                for (int i = 0; i < sentence_words.Length; i++)
                {
                    if (sentence_words[i].Length > 7)
                    {
                        long_words[word] = sentence_words[i]; //Adds the word to the array
                        Console.WriteLine(long_words[word]);
                        word += 1;                                                
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
            
            return;
        }

        //Method that creates the text file that will host these long words
        public void file_make() 
        {

        }
    }
}
