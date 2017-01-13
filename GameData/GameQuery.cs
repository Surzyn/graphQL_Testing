using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameData.Models;
using GameData.Types;
using GraphQL.Types;

namespace GameData
{
    public class GameQuery : ObjectGraphType
    {
        public GameQuery(GameDataProvider data)
        {
            Field<ListGraphType<GameTypeQL>>(
                "games",
                resolve: context => data.GetAsync());
            Field<GameTypeQL>(
                "game",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> {Name = "id", Description = "Id of game"}
                    ),
                resolve: context => data.GetAsync(context.GetArgument<int>("id")));
        }
    }
}
