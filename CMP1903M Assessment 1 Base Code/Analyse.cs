using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse
    {     
        //Method that takes in the input and gets the number of letters and characters from the input
        public int[] analyse_main(ref string sentence_check) 
        {
            int human_input_length = sentence_check.Length;
            Console.WriteLine("There are"+" "+human_input_length+" "+ "characters in this sentence");

            // Removes the spaces in between the words by concatonating the words together
            string trimmed_input = String.Concat(sentence_check.Where(c => !Char.IsWhiteSpace(c)));

            //Works out and outputs the amount of letters there are in the inputted sentence(s)
            int input_letter_count = trimmed_input.Length;
            Console.WriteLine("There are" + " " + input_letter_count + " " + "letters in this sentence");

            //Calls the sentence_statistics method with sentence_check as a parameter
            int[] return_array = this.sentence_statistics(ref sentence_check); 
            Console.WriteLine(return_array.Length); //Gets the length of the array

            //Resizes the array and adds the value of the sentence_count method to the return_array list
            int new_length = return_array.Length + 1;
            Array.Resize(ref return_array, new_length); //Changes the size of the array to allow for another value to be added to it

            //Calls the sentence_counter method and places it in the array
            return_array[new_length-1] = this.sentence_count(ref sentence_check); 
            Console.WriteLine(return_array.Length);


            //For loop prints out each value in the array
            for (int i = 0; i < return_array.Length; i++) 
            {
                Console.WriteLine("Return array:" + return_array[i]);
            }

            //Returns the array with the results of the analysis
            return return_array;            
        }

        //Method that analyses the sentence and returns number of vowels, constants, upper and lower case, etc and returns a list. 
        public int[] sentence_statistics(ref string sentence_check) 
        {
            //Variables and lists that will be used to analyse the file or user input
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' }; //Stores the vowels  
            char[] consonants = {'b','c','d','f','g','h','j','k','l','m','n','q','r','s','t'
                    ,'v','w','x','y','z'}; //Stores all the consonants
            char[] numbers = { '0','1', '2','3','4','5','6','7','8','9' }; //Stores numbers
            
            //Counters used when analysing the sentence(s)
            int vowel_counter = 0;
            int consonants_counter = 0;
            int number_counter = 0;
            int space_counter = 0;
            int other_characters_counter = 0;
            int upper_counter = 0;
            int lower_counter = 0;
            
            //For loop works out number of vowels, consonants, numbers and other symbols in the sentence(s)
            for (int i = 0; i < sentence_check.Length; i++)
            {
                //If any of these elements are in the sentence, the specific counter that it applies to will be added to
                if (vowels.Contains(sentence_check[i])) 
                {
                    vowel_counter += 1;
                }
                else if (consonants.Contains(sentence_check[i])) 
                {
                    consonants_counter += 1;
                }
                else if (numbers.Contains(sentence_check[i])) 
                {
                    number_counter += 1;
                }
                else if (sentence_check[i] == ' ') 
                {
                    space_counter += 1;
                }
                else 
                {
                    other_characters_counter += 1;
                }                   
                
            }
            //For loop works out how many upper and lower case letters there are in the sentence
            for (int i = 0; i < sentence_check.Length; i++) 
            {
                if (sentence_check[i] >= 65 && sentence_check[i] <= 90) //If statement checks if character is same as upper character
                {
                    upper_counter += 1;
                }
                else if (sentence_check[i] >= 97 && sentence_check[i] <= 122) //If statement checks if character is same as lower character
                {
                    lower_counter += 1;
                }
            }
            //Outputs the stats of the sentence
            Console.WriteLine("Number of vowels:"+" "+vowel_counter);
            Console.WriteLine("Number of consonants:" + " " + consonants_counter);
            Console.WriteLine("Number of integers:" + " " + number_counter);
            Console.WriteLine("Number of spaces:" + " " + space_counter);
            Console.WriteLine("Number of other characters:" + " " + other_characters_counter);
            Console.WriteLine("Number of Uppercase letters:" + " " + upper_counter);
            Console.WriteLine("Number of Lowercase letters:" + " "+ lower_counter);

            //An array that contains the counters is created and return to the analyse_main method in the Analyse class
            int[] counters = { vowel_counter, consonants_counter, number_counter, space_counter, other_characters_counter, upper_counter, lower_counter};
            return counters;
        }

        //Method counts how many sentences there are in the input
        public int sentence_count(ref string sentence_check)
        {
            int sentence_counter = 0;//Counter for the number of sentences in the input

            //For loop to analyse the input to calculate the number of sentences within the input
            for (int i =0; i < sentence_check.Length; i++) 
            {
                //If statement to check if the sentence contains punctuation that typically ends a sentence
                if (sentence_check[i] == '.' || sentence_check[i] == '?' || sentence_check[i] == '!') // || = OR Statement
                {
                    sentence_counter += 1;
                }                
            }
            Console.WriteLine("Number of sentences:" + " " + sentence_counter); //Outputs the number of sentences
            return sentence_counter; //Returns the sentence_counter variable to the analyse_main method in the Analyse class

        }

        //Original Method Template - ignore as didn't use

        //Handles the analysis of text
        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> analyseText(string input)
        {
            //List of integers to hold the first five measurements:
            //1. Number of sentences
            //2. Number of vowels
            //3. Number of consonants
            //4. Number of upper case letters
            //5. Number of lower case letters
            List<int> values = new List<int>();
            //Initialise all the values in the list to '0'
            for(int i = 0; i<5; i++)
            {
                values.Add(0);
            }
            return values;
        }
    }
}
