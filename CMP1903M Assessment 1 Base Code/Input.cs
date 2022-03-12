using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    //Class that handles the input from user and text file
    public class Input
    {
        //Handles the text input for Assessment 1
        string text = "nothing";
        
        
        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        //Processes Human Input
        public string manualTextInput()
        {
            Console.WriteLine("Enter a sentence, make sure to finish the input with an asterick (*)");
            string humaninput = Console.ReadLine(); //Stores the user input into this variable
            Console.WriteLine(humaninput);
            return humaninput;
            
            
            //return text;
        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file
        //Processes Input from the Text File
        public string fileTextInput(string fileName)
        {

            return text;
        }

    }
}
