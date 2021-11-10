using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveRatingApp
{
    public class Leader : TeamMember
    {
        public Leader(string firstName, string lastName, string commonId, DriveRating driveRating)
            : base(firstName, lastName, commonId, driveRating) { }

        /// <summary>
        /// Leader Override: Will return double based on Drive rating
        /// </summary>
        /// <returns></returns>
        public override double GetBonus()
        {
            switch (DriveRating)
            {
                case DriveRating.NeedsImprovement:
                    return 0;
                case DriveRating.AchievingExpectations:
                    return 2000;
                case DriveRating.ExceedExpectations:
                    return 10000;
                case DriveRating.RockStar:
                    return 20000;
                default:
                    return 0;
            }
        }
    }
}
