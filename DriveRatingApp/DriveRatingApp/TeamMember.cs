namespace DriveRatingApp
{
    public class TeamMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CommonId { get; set; }
        public DriveRating DriveRating { get; set; }
        public TeamMember(string firstName, string lastName, string commonId, DriveRating driveRating)
        {
            FirstName = firstName;
            LastName = lastName;
            CommonId = commonId;
            DriveRating = driveRating;
        }
        /// <summary>
        /// Will return a double based on Drive Rating.
        /// </summary>
        /// <returns></returns>
        public virtual double GetBonus()
        {
            switch (DriveRating)
            {
                case DriveRating.NeedsImprovement:
                    return 0;
                case DriveRating.AchievingExpectations:
                    return 1000;
                case DriveRating.ExceedExpectations:
                    return 5000;
                case DriveRating.RockStar:
                    return 10000;
                default:
                    return 0;
            }
        }
    }
    public enum DriveRating
    {
        NeedsImprovement,
        AchievingExpectations,
        ExceedExpectations,
        RockStar
    }
}