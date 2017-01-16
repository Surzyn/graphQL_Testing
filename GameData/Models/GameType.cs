using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;

namespace GameData.Models
{
    public class GameTypeEnum : EnumerationGraphType
    {
        public GameTypeEnum()
        {
            Name = "Game Type";
            Description = "Test Desc";
            AddValue("Simulations" , "Simulations",0);
            AddValue("Action", "Action", 1);
            AddValue("Sports", "Sports", 2);
            AddValue("RPG", "RPG", 3);
            AddValue("FPS", "FPS", 4);
        }
    }
    public enum GameType
    {
        Simulations,
        Action,
        Sports,
        RPG,
        FPS
    }
}
