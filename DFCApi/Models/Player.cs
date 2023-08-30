namespace API.Models
{
    public class Player
    {
        public Player(string name, int level, bool captain = false)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("The name cannot be null");
            if (level < 0 && level > 11) throw new ArgumentException("The level should be between 0 and 10");

            Name = name;
            Level = level;
            Captain = captain;
            Active = true;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool Captain { get; private set; }
        public bool Active { get; private set; }
    }
}