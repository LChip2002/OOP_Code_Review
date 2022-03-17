using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    //Class outputs the findings of the analysis of the user or file input
    class Report
    {
        //Handles the reporting of the analysis
        //Maybe have different methods for different formats of output?
        //eg.   public void outputConsole(List<int>)
        public void main_report(ref List<int> sentence_result) 
        {
            //Outputs the stats of the sentence
            string[] stat_options = {"vowels","consonants","integers","spaces"
                    ,"Other characters","Uppercase letters","Lowercase Letters","Sentences" +
                    "" }; 
            int x = 0; //Extra increment for for loop

            //Exception Handling to prevent the program from halting due to an error
            try 
            {
                //For loop that will output to console with values from analysis
                for (int i = 0; i < sentence_result.Count; i++)
                {
                    Console.WriteLine("Number of" + " " + stat_options[x] + ":" + " " + sentence_result[i]);

                    //If statement used to move on the stat_options so it matches the value of the sentence_result 
                    if (x < sentence_result.Count) 
                    {
                        x += 1;
                    }                    
                }
            }
            catch (Exception) 
            {
                //Typically the error from this was an index error, this will be printed onto the console
                //Original error was solved as length of sentence_result and stat_options didn't match
                //Able to solve by remembering to add another value to the stat_options array
                Console.WriteLine("Error: Index out of range");
            }
            return; //Return back to main program 

        }

    }
}
