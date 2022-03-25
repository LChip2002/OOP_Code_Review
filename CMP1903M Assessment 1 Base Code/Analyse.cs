using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse
    {   
        // Handles the analysis of text
        // Method: analyseText
        // Arguments: string
        // Returns: list of integers
        // Calculates and returns an analysis of the text

        // Method refers to the analyse_main to be able to convert return_array to a list
        private List<int> Array_to_list(ref int[] return_array)
        {
            // List of integers to hold the first five measurements:
            // 1. Number of sentences
            // 2. Number of vowels
            // 3. Number of consonants
            // 4. Number of upper case letters
            // 5. Number of lower case letters

            List<int> values = new List<int>(); // Initializes a new list 

            // Adds every value in the array to values list
            for (int i = 0; i < return_array.Length; i++)
            {
                values.Add(return_array[i]); // Adds element of array to list
            }
            return values;
        }

        // Method that takes in the input and gets the number of letters and characters from the input
        public List<int> analyse_main(ref string sentence_check) 
        {
            // Removes all characters from the input after an asterisk(*) has been found
            sentence_check = sentence_check.Remove(sentence_check.IndexOf("*") + 1); // Removes everything after the index location of the first asterisk
            Console.WriteLine(sentence_check);

            // Gets the amount of characters from the whole sentence including spaces
            int human_input_length = sentence_check.Length;
            Console.WriteLine("There are "+human_input_length+ " characters in this sentence");

            // Removes the spaces in between the words by concatonating the words together
            string trimmed_input = String.Concat(sentence_check.Where(c => !Char.IsWhiteSpace(c)));

            // Works out and outputs the amount of letters there are in the inputted sentence(s)
            int input_letter_count = trimmed_input.Length;
            Console.WriteLine("There are " + input_letter_count + " letters in this sentence");

            // Calls the sentence_statistics method with sentence_check as a parameter
            int[] return_array = this.sentence_statistics(ref sentence_check); 
            Console.WriteLine(return_array.Length); // Gets the length of the array

            // Resizes the array and adds the value of the sentence_count method to the return_array list
            int new_length = return_array.Length + 1;
            Array.Resize(ref return_array, new_length); // Changes the size of the array to allow for another value to be added to it

            // Calls the sentence_counter method and places it in the array
            return_array[new_length-1] = this.sentence_count(ref sentence_check); // Calls the sentence_count method and set the output as an element to the return_array
            
            // Calls function that will convert the array to a list and generate the expected output from this class
            List<int> return_list = Array_to_list(ref return_array);

            // Calls function that will calculate which letter/character appears the most in the input
            string frequency = letter_frequency(ref sentence_check);

            // Returns the list with the results of the analysis
            return return_list;            
        }

        // Method that analyses the sentence and returns number of vowels, constants, upper and lower case, etc and returns a list. 
        // Declared as private as only needed to be accessed by analyse_main method in this class and nowhere else
        // Example of Encapsulation
        private int[] sentence_statistics(ref string sentence_check) 
        {
            // Variables and lists that will be used to analyse the file or user input
            char[] vowels = { 'a', 'e', 'i', 'o', 'u','A','E','I','O','U' }; // Stores the vowels  
            char[] consonants = {'b','c','d','f','g','h','j','k','l','m','n','p','q','r','s','t'
                    ,'v','w','x','y','z','B','C','D','F','G','H','J','K','L','M','N','P','Q','R','S','T'
                    ,'V','W','X','Y','Z'}; // Stores all the consonants
            char[] numbers = { '0','1', '2','3','4','5','6','7','8','9' }; // Stores numbers
            
            // Counters used when analysing the sentence(s)
            int vowel_counter = 0;
            int consonants_counter = 0;
            int number_counter = 0;
            int space_counter = 0;
            int other_characters_counter = 0;
            int upper_counter = 0;
            int lower_counter = 0;
            
            // For loop works out number of vowels, consonants, numbers and other symbols in the sentence(s)
            for (int i = 0; i < sentence_check.Length; i++)
            {
                // If any of these elements are in the sentence, the specific counter that it applies to will be added to
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
            // For loop works out how many upper and lower case letters there are in the sentence
            for (int i = 0; i < sentence_check.Length; i++) 
            {
                if (sentence_check[i] >= 65 && sentence_check[i] <= 90) // If statement checks if character's ASCII value is the same as upper character
                {
                    upper_counter += 1;
                }
                else if (sentence_check[i] >= 97 && sentence_check[i] <= 122) // If statement checks if character's ASCII value is the is same as lower character
                {
                    lower_counter += 1;
                }
            }
            // Outputs the stats of the sentence
            Console.WriteLine("Number of vowels: " + vowel_counter);
            Console.WriteLine("Number of consonants: " + consonants_counter);
            Console.WriteLine("Number of integers: " + number_counter);
            Console.WriteLine("Number of spaces: " + space_counter);
            Console.WriteLine("Number of other characters: " + other_characters_counter);
            Console.WriteLine("Number of Uppercase letters: " + upper_counter);
            Console.WriteLine("Number of Lowercase letters: " + lower_counter);

            // An array that contains the counters is created and return to the analyse_main method in the Analyse class
            int[] counters = { vowel_counter, consonants_counter, number_counter, space_counter, other_characters_counter, upper_counter, lower_counter};
            return counters;
        }

        // Method counts how many sentences there are in the input
        // Declared as private as only needed to be accessed by analyse_main method in this class and nowhere else
        // Example of Encapsulation
        private int sentence_count(ref string sentence_check)
        {
            int sentence_counter = 0;// Counter for the number of sentences in the input

            // For loop to analyse the input to calculate the number of sentences within the input
            for (int i =0; i < sentence_check.Length; i++) 
            {
                // If statement to check if the sentence contains punctuation that typically ends a sentence
                if (sentence_check[i] == '.' || sentence_check[i] == '?' || sentence_check[i] == '!') // || = OR Statement
                {
                    sentence_counter += 1;  
                }                
            }
            Console.WriteLine("Number of sentences: " + sentence_counter); // Outputs the number of sentences
            return sentence_counter; // Returns the sentence_counter variable to the analyse_main method in the Analyse class

        }
        // TO ADD: Get the frequency of individual letters?
        private string letter_frequency(ref string sentence_check) 
        {
            string xy = "x";
            // New dictionary created that will be the host to all letters and characters that will be checked for.
            Dictionary<char, int> individual_letters = new Dictionary<char, int>();

            // For loop used to add the entire alphabet to the dictionary
            for(char x = ' '; x <= '~'; x++) 
            {
                individual_letters.Add(x, 0);
            }

            // For loop to check each character in the input and count the
            for (int i = 0; i < sentence_check.Length; i++) 
            {
                if (individual_letters.TryGetValue(sentence_check[i], out int indiv_letter_count))
                {
                    individual_letters[sentence_check[i]] = indiv_letter_count + 1;
                }
                
            }
                      

            return xy;
        }

    }
}
