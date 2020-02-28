using System;
using System.Collections.Generic;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dictionary<string, string>> teammates = new List<Dictionary<string, string>>();

            Dictionary<string, int> bank = new Dictionary<string, int>();

            Console.WriteLine("Plan your heist!");

            Console.WriteLine("Please enter the difficulty level of the bank your team will rob:");
            string bankDifficulty = Console.ReadLine();
            int bankDifficultyParsed = int.Parse(bankDifficulty);
            bank.Add("difficulty", bankDifficultyParsed);

            Console.WriteLine("\nIt's time to build your team for the heist");
            Console.WriteLine("You must add your teammates to the database \n");


            bool teamNameBlank = false;

            int numberOfTrials = 0;

            int successes = 0;
            int failures = 0;

            while (!teamNameBlank)
            {
                Dictionary<string, string> teammate = new Dictionary<string, string>();

                Console.WriteLine("Enter your teammate's name:");

                string teammateName = Console.ReadLine();

                if (teammateName == "")
                {
                    teamNameBlank = true;
                    while (numberOfTrials <= 0)
                    {
                        Console.WriteLine("\nHow many times do you want to run the heist trial?");
                        string trialNumber = Console.ReadLine();
                        int trailNumberParsed = int.Parse(trialNumber);
                        if (trailNumberParsed <= 0)
                        {
                            Console.WriteLine("You must enter a number greater than 0. Please try again\n");
                        }
                        else
                        {
                            numberOfTrials += trailNumberParsed;
                        }
                    }
                }
                else
                {
                    teammate.Add("name", teammateName);
                    Console.WriteLine("Enter your teammate's skill level:");
                    string teammateSkill = Console.ReadLine();
                    teammate.Add("skill_level", teammateSkill);
                    Console.WriteLine("Enter your teammate's courage factor:");
                    string courageFactor = Console.ReadLine();
                    teammate.Add("courage_factor", courageFactor);
                    teammates.Add(teammate);
                }
            }

            for (int i = 0; i < numberOfTrials; i++)
            {
                Random rand = new Random();
                int luck = rand.Next(-10, 11);

                bank["difficulty"] += luck;

                int skillSum = 0;

                foreach (Dictionary<string, string> teamMember in teammates)
                {
                    skillSum += int.Parse(teamMember["skill_level"]);
                }

                Console.WriteLine($"Your team's combined skill level is {skillSum}");
                Console.WriteLine($"The bank's difficulty level is {bank["difficulty"]}");

                if (skillSum < bank["difficulty"])
                {
                    Console.WriteLine("Your team has failed! Their total skill level was too low.");
                    failures++;

                }
                else if (skillSum >= bank["difficulty"])
                {
                    Console.WriteLine("Your team was successful! The heist went off without a hitch.");
                    successes++;
                }
            }

            Console.WriteLine($"You had {successes} successes and {failures} failures");

        }
    }
}
