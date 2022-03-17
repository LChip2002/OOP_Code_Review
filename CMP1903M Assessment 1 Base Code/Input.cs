using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMP1903M_Assessment_1_Base_Code
{
    //Class that handles the input from user and text file
    public class Input
    {
        //Handles the text input for Assessment 1
        //string text = "nothing";
        
        
        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        //Processes Human Input
        public string manualTextInput(ref string human_input)
        {            
            Console.WriteLine("Enter a sentence, make sure to finish the input with an asterick (*)");
            human_input = Console.ReadLine(); //Stores the user input into this variable
            int asterick_counter = 0; //Counter to check if an asterick is present in the inputted sentence
            
            for (int i = 0; i < human_input.Length; i++) 
            {
                if(human_input[i] == '*') 
                {
                    asterick_counter += 1;
                }
            }
            //If statement checks if the asterick counter isn't greater than 0
            if (asterick_counter == 0) 
            {
                human_input = " ";
                manualTextInput(ref human_input); //Function is called again if there are no astericks - example of recursion
            }
            
            Console.WriteLine(human_input);
            return human_input;
            
            
            //return text;
        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file
        //Processes Input from the Text File
        public string file_Text_Input(ref string file_name)
        {
            //Sets the contents of the directory to a string
            string file_path = System.IO.File.ReadAllText(@"C:\Users\Local User\Documents\GitHub\OOP_Code_Review\CMP1903M Assessment 1 Test File.txt");
            Console.WriteLine(file_path);
            return file_path;      

            //return text;
        }

    }
}
