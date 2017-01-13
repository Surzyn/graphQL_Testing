using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using GameData.Models;
using GraphQL.Types;

namespace GameData.Types
{
    public class GameTypeQL : ObjectGraphType<Game>
    {
        public GameTypeQL()
        {
            Field(x => x.Id).Description("Id of game");
            Field(x => x.Name,true).Description("Name of game");
            //Field(x => x.GameType, true).Description("Game Type");
            Field(x => x.GameType.ToList()).Description("Description");
            Field(x => x.Year, true).Description("Year");
        }
    }
}
