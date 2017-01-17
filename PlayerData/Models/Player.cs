using System.Collections.Generic;
using GameData.Models;

namespace PlayerData.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Friends { get; set; }
        public List<int> Games { get; set; }
    }
}
