using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse
    {
        //Handles the analysis of text
        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text

        //Method that takes in the input and analyses the text 
        public void analyse_humantext(ref string human_input) 
        {
            int human_input_length = human_input.Length;
            Console.WriteLine("There are"+" "+human_input_length+" "+ "characters in this sentence");
            Console.WriteLine(human_input[0]);

            // Removes the spaces in between the words by concatonating the words together
            string trimmed_human_input = String.Concat(human_input.Where(c => !Char.IsWhiteSpace(c)));
            Console.WriteLine(trimmed_human_input);

            //Works out and outputs the amount of letters there are in the inputted sentence(s)
            int input_letter_count = trimmed_human_input.Length;
            Console.WriteLine("There are" + " " + input_letter_count + " " + "letters in this sentence");

            string sentence_check = human_input; //Human_input becomes the value of the sentence_check variable to be used in the sentence_statistics method
            sentence_statistics(ref sentence_check); //Calls the sentence_statistics method with sentence_check as a parameter
        }

        //Method that analyses the sentence and returns number of vowels, constants, upper and lower case, etc. 
        public void sentence_statistics(ref string sentence_check) 
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

            //Calls the sentence_counter method 
            sentence_counter(ref sentence_check);        

        }

        //Method counts how many sentences there are in the input
        public void sentence_counter(ref string sentence_check)
        {
            int sentence_counter = 0;//Counter for the number of sentences in the input

            //For loop to analyse the input to calculate the number of sentences within the input
            for (int i =0; i < sentence_check.Length; i++) 
            {
                //If statement to check if the sentence contains punctuation that typically ends a sentence
                if (sentence_check.Contains('.') || sentence_check.Contains('?') || sentence_check.Contains('!')) // || = OR Statement
                {
                    sentence_counter += 1;
                }
                Console.WriteLine("Number of sentences:"+" "+sentence_counter);
            }
            
        }
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
