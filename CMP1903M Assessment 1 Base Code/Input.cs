using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMP1903M_Assessment_1_Base_Code
{
    //Abstract class that contains the method file_search that will be inherited by the main input class
    //Example of Data Abstraction
    public abstract class search 
    {
        public abstract string file_search(); //Contains the method but without its body
    }

    // Class that handles the input from user and text file
    // Get either manually entered text, or text from a file
    public class Input:search //Input inherits the contents of the search abstract class
    {     
        
        // Method: manualTextInput
        // Arguments: none
        // Returns: string
        // Gets text input from the keyboard

        // Processes Human Input
        public string manualTextInput(ref string human_input)
        {            
            Console.WriteLine("Enter a sentence, make sure to finish the input with an asterisk (*)");
            human_input = Console.ReadLine()!; // Stores the user input into this variable
            int asterick_counter = 0; // Counter to check if an asterisk is present in the inputted sentence

            for (int i = 0; i < human_input.Length; i++) 
            {
                if(human_input[i] == '*') 
                {
                    asterick_counter += 1;
                }
            }
            // If statement checks if the asterisk counter isn't greater than 0
            if (asterick_counter == 0) 
            {
                human_input = " ";
                manualTextInput(ref human_input); // Function is called again if there are no asterisks - example of recursion
            }
            
            return human_input;            
            
        }

        // Method: fileTextInput
        // Arguments: string (the file path)
        // Returns: string
        // Gets text input from a .txt file

        // Processes Input from the Text File
        public string file_Text_Input()
        {
            // Exception handling used here in case the full directory is not present on the user's device
            try
            {
                // Sets the contents of the directory to a string
                string file_path = System.IO.File.ReadAllText(@"C:\Users\Local User\Documents\GitHub\OOP_Code_Review\CMP1903M_Assessment_1_Test_File.txt");
                return file_path;
            }

            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Original directory doesn't exist on device, searching for file now");
                string file_path = file_search();
                return file_path;
            }
                  
        }

        // Method searches for the text file on the user's device
        public override string file_search() //Overrides the base class method and gives body to the abstract method - example of data abstraction
        {
            string file_path;
            
            // Exception Handling used if the GetFullPath fails, if so the user will then have to manually input the file directory
            try 
            {
                // Gets the full directory that the file is in on the user's device
                file_path = System.IO.File.ReadAllText(Path.GetFullPath("CMP1903M_Assessment_1_Test_File.txt"));
                Console.WriteLine(file_path);
                
            }
            catch (Exception)
            {
                //If it fails the user has to manually enter the file directory
                Console.Clear();
                Console.WriteLine("Search error, Please enter the directory of the text file manually"+"\n"+":");
                file_path = Console.ReadLine()!;
            }
            return file_path;


        }

    }
}
