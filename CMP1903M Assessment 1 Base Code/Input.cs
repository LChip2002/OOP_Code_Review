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
