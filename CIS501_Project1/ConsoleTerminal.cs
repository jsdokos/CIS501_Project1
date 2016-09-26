using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501_Project1
{
    class ConsoleTerminal : ITerminal
    {
        public void Display(string s)
        {
            Console.Write(s);
        }

        public void DisplayLine(string s)
        {
            Console.WriteLine(s);
        }

        public char getChar(string prompt, string chars) //TODO Test
        {

            Console.Write(prompt);

            string playResponse = "";

            char[] acceptableAnswers = chars.ToCharArray();

            do
            {
                try
                {
                    playResponse = Console.ReadLine();
                    playResponse = playResponse.Trim();

                    if (playResponse.Length > 1)
                    {
                        throw new InsufficientMemoryException();
                    }

                    for (int i = 0; i < acceptableAnswers.Length; i++)
                    {
                        if (playResponse[0] == acceptableAnswers[i])
                        {
                            break;
                        }
                    }

                    throw new InsufficientExecutionStackException();
                }
                catch (Exception ex)
                {
                    Console.Write(prompt);
                }
            }
            while (true);

            return playResponse[0];
        }

        public string GetString(string prompt, int length)
        {

            Console.Write(prompt);
            string playResponse = "";
            do
            {
                try
                {
                    playResponse = Console.ReadLine();

                    if (playResponse.Length >= length)
                    {
                        break;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(prompt);
                }
            }
            while (playResponse.Length >= length);

            return playResponse;
        }

        public int GetInt(string prompt, int min, int max) //TODO Test
        {
            Console.Write(prompt);
            int answer = -1000;

            do
            {
                try
                {
                    answer = Convert.ToInt32(Console.ReadLine());

                    if (answer >= min || answer <= max)
                    {
                        break;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(prompt);
                }
            }
            while (answer >= min || answer <= max);

            return answer;

        }
    }
}
