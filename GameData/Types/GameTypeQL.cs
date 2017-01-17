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
            Field<ListGraphType<GameTypeEnum>>("GameType");
            Field(x => x.Year, true).Description("Year");
        }
    }
}
