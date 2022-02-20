using System.Collections.Generic;

public class AthleteDto
{
    public string ibuId { get; set; }
    public string fullname { get; set; }
    public string familyName { get; set; }
    public string givenName { get; set; }
    public string country { get; set; }
    public string nat { get; set; }
    public string genderId { get; set; }
    public int maxHeartRate { get; set; }
    public string image { get; set; }
    public List<string> statSeasons { get; set; }
    public List<string> statShootingProne { get; set; }
    public List<string> statShootingStanding { get; set; }
}


