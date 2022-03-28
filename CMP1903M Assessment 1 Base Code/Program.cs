// Base code project for CMP1903M Assessment 1
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
            // Gives the user the option to either enter text or analyse text from file
            bool checker = false; 
            
            while (checker == false) // While loop will keep going until the user enters a valid input which would set checker to true
            {
                Console.Write("Do you want to enter text " + "\n" + "1. Via keyboard" + "\n" + "2. Via text file" + "\n" + "Or press enter to quit");
                var option = Console.ReadLine(); // The option the user chooses is set to a variable
                Input Program_Input = new Input(); // Input object instantiated, will be used in calling methods within the Input class
                Console.Clear();
                // If statement that will allow the user to respond and navigate to what input they want to use
                if (option == "1")
                {
                    Console.WriteLine("Selected enter via keyboard."+"\n");
                    checker = true;
                    string human_input = " "; // Initializes the human input as a blank
            
                    // Calls the input class with the intention of using the physical input
                    string returned_human_input = Program_Input.manualTextInput(ref human_input);
                    Console.WriteLine(returned_human_input);

                    // Calls the Analyse class with the intention of analysing the human input
                    string sentence_check = returned_human_input; // Human_input becomes the value of the sentence_check variable to be used in the Analysis class
                    Analyse Analysetext = new Analyse(); // Create an 'Analyse' object
                    List<int> sentence_result = Analysetext.analyse_main(ref sentence_check); // Calls the analyse_humantext method within the class with human_input as the parameter

                    // Calls the report class with the intention of outputting a final report of the findings from the analysis
                    Report result_report = new Report();
                    result_report.main_report(ref sentence_result, ref sentence_check);

                    // Calls the FileStore class with the intention of checking for long words and storing them into a txt file
                    FileStore files = new FileStore();
                    files.long_word_checker(ref sentence_check);
                    Console.WriteLine("\n" + "The Program ran successfully.");
                }
                else if (option == "2")
                {
                    Console.WriteLine("Selected enter via text file." + "\n");
                    checker = true;                    
                    string file_path = Program_Input.file_Text_Input(); // Calls the input class with the intention of using file input

                    // Calls the Analyse class with the intention of analysing the inputted text file 
                    string sentence_check = file_path;  
                    Analyse Analysetext = new Analyse(); // Create an 'Analyse' object
                    List<int> sentence_result = Analysetext.analyse_main(ref sentence_check);

                    // Calls the report class with the intention of outputting a final report of the findings from the analysis
                    Report result_report = new Report();
                    result_report.main_report(ref sentence_result, ref sentence_check);

                    // Calls the Report_Validation class with the purpose of comparing the statistics from the final report to those in the original input
                    // Only in option == '2', as this class requires the text file and not the human input
                    Report_Validation Validate = new Report_Validation();

                    // The program will continue to run if Report_Validation class returns true
                    if(Validate.Stat_Comparison(ref sentence_result, ref file_path)) 
                    {
                        // Calls the FileStore class with the intention of checking for long words and storing them into a txt file
                        FileStore files = new FileStore();
                        files.long_word_checker(ref sentence_check);
                        Console.WriteLine("\n" + "The Program ran successfully.");
                    }
                    else 
                    {
                        Console.WriteLine("The program ran unsuccessfully.");
                    }

                }
                else if (option == "") 
                {
                    Environment.Exit(1); // Closes the console if the user presses enter
                }
                else 
                {
                    Console.Clear(); //Clears the console, reducing clutter
                    Console.WriteLine("Invalid input.");
                }
                                
            }      
                       
           
        }     
        
    
    }
}
