using System;
using System.Collections.Generic;
using System.Linq;

namespace heist
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Plan Your Heist!");

            // Create a new instance of a game
            Game currentGame = new Game();

            // To play a game, we need to prompt the user for three things:

            // How many times they want to run the robbery simulator
            int numberOfTrialRuns = currentGame.PromptUserForTrialRuns();

            // How difficultly they want their robbery to be
            int difficultyLevel = currentGame.PromptUserForDifficultly();

            // And finally, they need to create the members of their team
            List<TeamMember> team = currentGame.BuildTeam();

            // Once we have the info we need from the user, we can run the simulation however many times they want
            currentGame.PlayGame(numberOfTrialRuns, difficultyLevel, team);
        }
    }
}
