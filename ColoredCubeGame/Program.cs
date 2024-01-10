using System;
using System.IO;

namespace ColoredCubeGame
{
    class Program
    {
        static void Main()
        {
            // path for the inputs from the question
            string filePath = "../inputs.txt";

            try
            {            
                string[] lines = File.ReadAllLines(filePath);
                int i = 0;
                int sum = 0;
                foreach (string line in lines)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    i++;                    
                    string[] game = GetGame(line);
                    System.Console.Write(line);                   
                    if(isGameLegal(game)){
                        sum+=i;
                        Console.ForegroundColor = ConsoleColor.Green;   
                        System.Console.WriteLine(" Legal");                   
                    }
                    else{
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine(" ILegal");
                    }                        
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine($"The sum is {sum}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while reading the file: {e.Message}");
            }
        }

        public static string[] GetGame(string line)
        {
            return line.Split(':')[1].Split(";");
        }

        public static bool isGameLegal(string[] game)
        {
            foreach(string round in game){
                if(!isRoundLegal(round))
                    return false;
            }
            return true;
        }

        public static bool isRoundLegal(string round)
        {
            string[] cubes = round.Split(',');
            int green=0,red=0,blue = 0;
            foreach (string cube in cubes)
            {
                if (cube.Contains("green"))
                    green += getNumberFrom(cube);
                else if (cube.Contains("red"))
                    red += getNumberFrom(cube);
                else if (cube.Contains("blue"))
                    blue += getNumberFrom(cube);
            }
            return red < 13 && green < 14 && blue < 15;
        }
        public static int getNumberFrom(string round)
        {
            string number = "";
            foreach (char ch in round)
                if (char.IsDigit(ch))
                    number += ch;
            return int.Parse(number);    
        }
    }
}
