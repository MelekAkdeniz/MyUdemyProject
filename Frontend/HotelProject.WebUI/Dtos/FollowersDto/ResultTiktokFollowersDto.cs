namespace HotelProject.WebUI.Dtos.FollowersDto
{
    public class ResultTiktokFollowersDto
    {
        public Userinfo? userInfo { get; set; }
        public class Userinfo
        {
            public Stats? stats { get; set; }
        }

        public class Stats
        {
            public int followerCount { get; set; }
            public int followingCount { get; set; }
        
        }
    }
}
