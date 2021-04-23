using System;
using System.Collections.Generic;
using System.Linq;


namespace heist
{
    public class Game
    {


        // Prompts the user to enter a difficultly level for their game, validates their input, and returns the number of trial runs they entered
        public int PromptUserForTrialRuns()
        {
            bool canConvertTrialRuns = false;
            int numberOfTrialRuns = 0;
            while (!canConvertTrialRuns)
            {
                // Check out HelperMethods.cs to see what's going on with this .Ask() method
                string numberOfTrialRunsString = HelperMethods.Ask("How many trial runs would you like to run?");
                canConvertTrialRuns = Int32.TryParse(numberOfTrialRunsString, out numberOfTrialRuns);
            }
            return numberOfTrialRuns;
        }

        // Prompts the user to enter a difficultly level for their game, validates their input, and then returns the difficultly level they entered
        public int PromptUserForDifficultly()
        {
            bool canConvertDiffultly = false;
            int difficultyLevel = 0;
            while (!canConvertDiffultly)
            {
                // Check out HelperMethods.cs to see what's going on with this .Ask() method
                string difficultlyLevelString = HelperMethods.Ask("Enter a difficulty level");
                canConvertDiffultly = Int32.TryParse(difficultlyLevelString, out difficultyLevel);
            }

            return difficultyLevel;
        }


        // Prompts the user to enter as many teammates as they want
        // Each teammate should have a name, skill level, and courage factor
        // This method will validate all inputs from the user before adding a new teammate to the team
        public List<TeamMember> BuildTeam()
        {
            List<TeamMember> team = new List<TeamMember>();
            while (true)
            {
                // Check out HelperMethods.cs to see what's going on with this .Space() method
                HelperMethods.Space();
                HelperMethods.Space();
                string name = HelperMethods.Ask("What's the teammate's name?");

                // If we get a blank name, ask the user if they're sure they want to finish up with their team. If they say yes, break out of the loop.
                if (name == "")
                {
                    Console.WriteLine("Are you sure you're ready to commit a robbery? Y/N");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "y")
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }

                // Otherwise, continue prompting the user
                string courage = HelperMethods.Ask("What's their courage factor? Should be a positive whole number.");
                int courageInt = HelperMethods.ConvertToValidInt(courage); // Convert to the correct data type and validate input

                string skill = HelperMethods.Ask("What's their skill level? Should be a decimal between 0 and 2");
                double skillDbl = HelperMethods.ConvertToValidDouble(skill); // Convert to the correct data type and validate input

                // Once we're sure all the data is gucci (i.e. converted to the appropriate data types and within the correct ranges) we instantiate a new teammate
                TeamMember newPerson = new TeamMember(name, courageInt, skillDbl);

                // Aaand we add that person to the team
                team.Add(newPerson);

                Console.WriteLine($@"You just added {newPerson.Name} to your team! You now have {team.Count} members on the team");
            }

            // Once we've built our team, we return it
            return team;

        }



        // Accepts the number of trial runs the user wanted to run
        // Uses that number to run a given number of simulations. Passes the difficultly level and team to each simulations
        // Records successful and unsuccessful robberies and prints a final report
        public void PlayGame(int numberOfTrialRuns, int difficultyLevel, List<TeamMember> team)
        {
            int successfulRuns = 0;
            int failedRuns = 0;

            for (int i = 1; i <= numberOfTrialRuns; i++)
            {
                HelperMethods.Space();
                Console.WriteLine($"-----------------Game Number {i}-----------------");

                bool youWon = CalculateSuccess(difficultyLevel, team);

                if (youWon)
                {
                    Console.WriteLine("You and your team have successfuly robbed the bank! Woo!");
                    successfulRuns += 1;
                }
                else
                {
                    Console.WriteLine("You didn't rob the bank :( ");
                    failedRuns += 1;
                }

            }
            HelperMethods.Space();
            Console.WriteLine("-------------------------------");
            Console.WriteLine($@"Your team made {successfulRuns} successful robberies and {failedRuns} failed runs.

            Press any key to exit");

            Console.ReadLine();

        }


        // ---------------- Main game logic -------------------//
        // Accepts a team and a  difficultly level
        // Calculates whether the team was successful based on skill level of team, given difficultly level, and randomly generated luck value
        // Returns true if the team was successful
        // Returns false if they were un successful
        public static bool CalculateSuccess(int bankDifficultyLevel, List<TeamMember> robberyTeam)
        {
            int randomLuckValue = new Random().Next(-10, 10);

            int difficultyPlusLuck = bankDifficultyLevel + randomLuckValue;

            // Sum up the skill levels of the team
            int totalSkill = robberyTeam.Select(person => person.SkillLevel).Sum();

            // Did we win???
            if (totalSkill >= difficultyPlusLuck)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}