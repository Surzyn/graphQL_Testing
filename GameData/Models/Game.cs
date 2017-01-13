using System.Collections.Generic;

namespace GameData.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<GameType> GameType { get; set; }

    }
}
