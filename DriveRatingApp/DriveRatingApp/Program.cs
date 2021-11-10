using System;
using System.Collections.Generic;

namespace DriveRatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TeamMember> teamMembers = new List<TeamMember>();
            teamMembers = TeamMemberRepo.GetTeamMembers();
            string userID;
            bool userContinue = true;
            while (userContinue)
            {
                userID = GetInput("Please enter your ID: ");
                bool found = false;
                for (int i = 0; i < teamMembers.Count; i++)
                {
                    if (teamMembers[i].CommonId.Equals(userID) && teamMembers[i].CommonId.StartsWith("t"))
                    {
                        //Teammates
                        found = true;
                        DriveApp.TeamFlow(teamMembers);
                    }
                    else if (teamMembers[i].CommonId.Equals(userID) && teamMembers[i].CommonId.StartsWith("l"))
                    {
                        //Leaders
                        found = true;
                        DriveApp.LeaderFlow(teamMembers);
                    }
                    else if (teamMembers[i].CommonId.Equals(userID) && teamMembers[i].CommonId.StartsWith("d"))
                    {
                        //Directors
                        found = true;
                        DriveApp.DirectorFlow(teamMembers);
                    }
                }
                if (!found)
                {
                    Console.WriteLine("\nID was not found...");
                    userContinue = UserContinue();
                }
            }
            Console.WriteLine("::GOODBYE::");
        }
        /// <summary>
        /// Takes in a string as a prompt and returns input as a string
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine().Trim().ToLower();
        }
        /// <summary>
        /// Will validate and return user input if they wish to continue, will return true/false
        /// </summary>
        /// <returns></returns>
        public static bool UserContinue()
        {
            string input = GetInput("\nWould you like to enter another ID?" +
                "\n1) Yes" +
                "\n2) No" +
                "\n:: ");
            switch (input)
            {
                case "1":
                    return true;
                case "2":
                    return false;
                default:
                    Console.WriteLine("\n~INVALID INPUT: Enter a number from the list");
                    return UserContinue();
            }
        }
    }   
}