namespace API.Models
{
    public class Team
    {
        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }

        public string Name { get; private set; }
        public List<Player> Players { get; private set; }
    }
}