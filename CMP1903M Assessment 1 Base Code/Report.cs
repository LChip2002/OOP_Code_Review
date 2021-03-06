using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    // Class outputs the findings of the analysis of the user or file input
    class Report
    {
        // Handles the reporting of the analysis
        // Maybe have different methods for different formats of output?
        // eg.   public void outputConsole(List<int>)
        public void main_report(ref List<int> sentence_result, ref string sentence_check) 
        {
            // Outputs the stats of the sentence
            string[] stat_options = {"total characters/letters","vowels","consonants","integers","spaces"
                    ,"Other characters","Uppercase letters","Lowercase Letters","Sentences" +
                    "" }; 
            int x = 0; // Extra increment for for loop
            
            // For loop that will output to console with values from analysis
            for (int i = 0; i < sentence_result.Count; i++)
            {
                Console.WriteLine("Number of" + " " + stat_options[x] + ":" + " " + sentence_result[i]);

                // If statement used to move on the stat_options so it matches the value of the sentence_result 
                if (x < sentence_result.Count) 
                {
                    x += 1;
                }                    
            }

            // Calls the Analyse class to obtain the value returned from the letter frequency method
            // Calls function that will calculate which letter/character appears the most in the input
            // Console output will come from the Analysis class method
            Analyse letter_freq = new Analyse();
            letter_freq.letter_frequency(ref sentence_check); // Calls letter_frequency function in Analyse class
        }

    }
}
