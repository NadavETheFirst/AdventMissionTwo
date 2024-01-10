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
                int sum = 0;
                foreach (string line in lines)
                {
                    Console.ForegroundColor = ConsoleColor.White;                 
                    string[] game = GetGame(line);
                    int power = getPower(game); 
                    System.Console.WriteLine($"{line}, \npower:{power}");                   
                    sum+=power;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine($"The sum is {sum}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while reading the file: {e.Message}");
            }
        }

        // Gets the game from each line as a string arry, each node represent a round
        public static string[] GetGame(string line)
        {
            return line.Split(':')[1].Split(";");
        }

        // Determine if every round in a given game is legal
        public static bool isGameLegal(string[] game)
        {
            foreach(string round in game){
                if(!isRoundLegal(round))
                    return false;
            }
            return true;
        }

        // Used to determine whether aa round is legal or not - no more then 12 red 13 green and 14 blue 
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

        // Gets the number of cubes taken out 
        public static int getNumberFrom(string round)
        {
            string number = "";
            foreach (char ch in round)
                if (char.IsDigit(ch))
                    number += ch;
            return int.Parse(number);    
        }

        public static int getPower(string[] game)
        {
            int[] currentMin = new int[] { 0, 0, 0 };
            foreach (string round in game)
            {
                int[] mins = getNumFromRound(round);
                for (int i = 0; i < 3; i++)                
                    if (currentMin[i] < mins[i])
                        currentMin[i] = mins[i];                
            }
            return currentMin[0]*currentMin[1]*currentMin[2];
        }
        public static int[] getNumFromRound(string round)
        {
            string[] cubes = round.Split(',');
            int green = 0, red = 0, blue = 0;            
            foreach (string cube in cubes)
            {
                if (cube.Contains("green"))
                    green += getNumberFrom(cube);
                else if (cube.Contains("red"))
                    red += getNumberFrom(cube);
                else if (cube.Contains("blue"))
                    blue += getNumberFrom(cube);
            }
            return new int[] { red, green, blue };
        }

        
    }
}
