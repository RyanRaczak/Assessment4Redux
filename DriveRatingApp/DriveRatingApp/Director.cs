using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveRatingApp
{
    public class Director : TeamMember
    {
        public Director(string firstName, string lastName, string commonId, DriveRating driveRating)
            : base(firstName, lastName, commonId, driveRating) { }
        /// <summary>
        /// Director Override: Will return a double based on Drive rating
        /// </summary>
        /// <returns></returns>
        public override double GetBonus()
        {
            switch (DriveRating)
            {
                case DriveRating.NeedsImprovement:
                    return 0;
                case DriveRating.AchievingExpectations:
                    return 3000;
                case DriveRating.ExceedExpectations:
                    return 15000;
                case DriveRating.RockStar:
                    return 30000;
                default:
                    return 0;
            }
        }
        public void GetDrive(List<TeamMember> teamMembers)
        {
            int exceedsCount = 0;
            int needImproveCount = 0;
            int achievesCount = 0;
            int rockstarCount = 0;
            int teamCount = 0; //Excludes directors in list

            //Adds up total of Drive ratings for team members
            for (int i = 0; i < teamMembers.Count; i++)
            {
                if (!teamMembers[i].CommonId.StartsWith("d"))
                {
                    teamCount++;
                    if (teamMembers[i].DriveRating == DriveRating.ExceedExpectations)
                    {
                        exceedsCount++;
                    }
                    else if (teamMembers[i].DriveRating == DriveRating.NeedsImprovement)
                    {
                        needImproveCount++;
                    }
                    else if (teamMembers[i].DriveRating == DriveRating.AchievingExpectations)
                    {
                        achievesCount++;
                    }
                    else if (teamMembers[i].DriveRating == DriveRating.RockStar)
                    {
                        rockstarCount++;
                    }
                }
            }
            if (teamCount == exceedsCount)
            {
                DriveRating = DriveRating.RockStar;
            }
            else if (exceedsCount >= 3 && needImproveCount == 0)
            {
                DriveRating = DriveRating.ExceedExpectations;
            }
            else if (needImproveCount <= 1)
            {
                DriveRating = DriveRating.AchievingExpectations;
            }
            else if (needImproveCount >= 2)
            {
                DriveRating = DriveRating.NeedsImprovement;
            }
        }
    }
}
