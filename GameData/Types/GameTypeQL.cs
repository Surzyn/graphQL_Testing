using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using GameData.Models;
using GraphQL.Types;
using GraphQLParser.AST;

namespace GameData.Types
{
    public class GameTypeQL : ObjectGraphType<Game>
    {
        public GameTypeQL()
        {
            Field(x => x.Id).Description("Id of game");
            Field(x => x.Name,true).Description("Name of game");
            Field<ListGraphType<GameTypeEnum>>("GameType");
            //Field<ListGraphType<GameTypeQL>>("friends");

            Field(x => x.Year, true).Description("Year");
        }
    }
}
