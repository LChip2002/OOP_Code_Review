using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; // Regex library used to be able to extract numbers from a string 

namespace CMP1903M_Assessment_1_Base_Code
{
    // Class that checks if the stats from the text file matches the results of the analysis of the text file
    class Report_Validation
    {
        // Method that compares the numbered results of the analysis to ones in the text file to see if they match or not
        public bool Stat_Comparison(ref List<int> sentence_result, ref string file_path)
        {
            // Eliminates everything before and after the sentence stats where there is a asterisk before and after it
            file_path = file_path.Substring(file_path.IndexOf("*")); // Removes everything in the text file before the first asterisk
            file_path = file_path.Substring(0, file_path.LastIndexOf("*") + 1); // Removes everything after the last asterisk
            Console.WriteLine(file_path); // Outputs the important parts of the text file

            // Regex used to extract the numbers from the statistics section of the text file.
            string[] file_split = Regex.Split(file_path, @"\D+"); // Split on one or more non-digit characters
            List<int> stats_from_text_file = new List<int>(); // New list created to store stats from the text file

            // Foreach loop used to go through each string value and checks for numbers
            foreach (string value in file_split)
            {
                // If statement checks if the value is not a string
                if (!string.IsNullOrEmpty(value))
                {
                    stats_from_text_file.Add(int.Parse(value)); // Adds the converted int value to the list
                }
            }

            //Lists are ordered to match each other to be able to compare the values of them
            List<int> ordered_stats_from_txt = new List<int>{stats_from_text_file[1], stats_from_text_file[2], stats_from_text_file[3]
                , stats_from_text_file[4], stats_from_text_file[0]};
            List<int> sorted_stats_from_analyse = new List<int> {sentence_result[0], sentence_result[1], sentence_result[6], sentence_result[7]
                , sentence_result[8]};
            
            // For loop to check if the stats from analysis and text file match up or not 
            for (int i = 0; i < ordered_stats_from_txt.Count; i++) 
            {
                // Checks if the values equal one another, if not it will be shown to the user and False would be returned
                if (ordered_stats_from_txt[i] == sorted_stats_from_analyse[i]) 
                {
                    Console.WriteLine("Stat matches");
                }
                else 
                {
                    Console.WriteLine("Report error, values do not match text file stats");
                    return false; 
                }
            }

            // Return true if everything in the report is valid and correct.
            return true;
        }
    }
}
