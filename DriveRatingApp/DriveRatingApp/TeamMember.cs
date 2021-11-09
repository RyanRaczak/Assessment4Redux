namespace DriveRatingApp
{
    public class TeamMember
    {
        //This is an auto-implemented property for the DriveRating Enum
            public DriveRating DriveRating { get; set; }
    }
    
    public enum DriveRating
    {
        NeedsImprovement,
        AchievingExpectations,
        ExceedExpectations,
        RockStar
    }
}