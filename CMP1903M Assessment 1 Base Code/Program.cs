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

                    // Calls the Analyse class with the intention of using analysing the input
                    Analyse Analysetext = new Analyse();
                    Analysetext.analyse_humantext(ref human_input); //Calls the analyse_humantext method within the class with human_input as the parameter

                }
                else if (option == "2")
                {
                    Console.WriteLine("Selected via text file");
                    checker = 1;
                    Input File_Input = new Input(); //Calls the input class with the intention of using the file input
                }
                else 
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                    
                
            }
            

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
