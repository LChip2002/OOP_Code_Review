//Base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Program
    {
        static void Main()
        {
            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();

            //Gives the user the option to either enter text or analyse text from file
            int checker = 0;
            while (checker == 0) 
            {
                Console.Write("Do you want to enter text " + "\n" +
                "1. Via keyboard" + "\n" + "2. Via text file");
                var option = Console.ReadLine();
                if (option == "1")
                {
                    Console.WriteLine("Selected via keyboard");
                    checker = 1;
                    //Calls the input class with the intention of using the physical input
                    Input Physinput = new Input();
                    string human_input = Physinput.manualTextInput();
                    Console.WriteLine(human_input);

                    // Calls the Analyse class with the intention of analysing the human input
                    string sentence_check = human_input; //Human_input becomes the value of the sentence_check variable to be used in the Analysis class
                    Analyse Analysetext = new Analyse();
                    int[] sentence_result = Analysetext.analyse_main(ref sentence_check); //Calls the analyse_humantext method within the class with human_input as the parameter

                    //Calls the report class with the intention of outputting a final report of the findings from the analysis
                    Report result_report = new Report();
                    result_report.main_report(ref sentence_result);

                    //Calls the FileStore class with the intention of checking for long words and storing them into a txt file
                    FileStore files = new FileStore();
                    files.long_word_checker(ref sentence_check);
                }
                else if (option == "2")
                {
                    Console.WriteLine("Selected via text file");
                    checker = 1;
                    Input File_Input = new Input(); //Calls the input class with the intention of using the file input
                    string file_name = " ";
                    string file_path = File_Input.file_Text_Input(ref file_name);

                    //Calls the Analyse class with the intention of analysing the inputted text file 
                    string sentence_check = file_path;
                    Analyse Analysetext = new Analyse();
                    int[] sentence_result = Analysetext.analyse_main(ref sentence_check);

                    //Calls the report class with the intention of outputting a final report of the findings from the analysis
                    Report result_report = new Report();
                    result_report.main_report(ref sentence_result);

                    //Calls the FileStore class with the intention of checking for long words and storing them into a txt file
                    FileStore files = new FileStore();
                    files.long_word_checker(ref sentence_check);

                }
                else 
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                                
            }
            Console.WriteLine("\n"+"The Program ran successfully");
            

            //Create 'Input' object
            //Get either manually entered text, or text from a file


            //Create an 'Analyse' object
            //Pass the text input to the 'analyseText' method


            //Receive a list of integers back


            //Report the results of the analysis


            //TO ADD: Get the frequency of individual letters?

           
        }     
        
    
    }
}
