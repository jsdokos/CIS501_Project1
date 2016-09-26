using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501_Project1
{
    class ITerminal
    {

        public void Display(string s)
        {
            Console.Write(s);
        }

        public void DisplayLine(string s)
        {
            Console.WriteLine(s);
        }

        public char getChar(string prompt, string chars)
        {
            Display(prompt);

            string playresponse = "";
            playresponse = Console.ReadLine();
            int index = playresponse.IndexOf(chars);
            //TODO this
        }
    }
}
