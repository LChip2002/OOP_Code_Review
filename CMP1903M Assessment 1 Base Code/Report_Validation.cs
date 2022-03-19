using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    //Class that checks if the stats from the text file matches the results of the analysis of the text file
    class Report_Validation
    {
        //Method that compares the numbered results of the analysis to ones in the text file to see if they match or not
        public void Stat_Comparison(ref List<int> sentence_result, ref string file_path) 
        {
            //Only need the section where the sentence stats of the file is
            file_path = file_path.Substring(file_path.IndexOf("*")); //Removes everything in the text file before the first asterick
            file_path = file_path.Substring(0, file_path.LastIndexOf("*") + 1); //Removes everything after the last asterick
            Console.WriteLine(file_path); //Outputs the important parts of the text file

            return;
        }
    }
}
