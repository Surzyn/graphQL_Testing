
using GameData;
using GameData.Types;
using GraphQL.Types;
using PlayerData.Types;

namespace GraphQLTest.Helpers
{
    public class GraphQLSchema : ObjectGraphType<object>
    {

        public GraphQLSchema(PlayerData.Providers.PlayerData playerData, GameDataProvider gameData)
        {
            Field<ListGraphType<GameTypeQL>>(
                "games",
                resolve: context => gameData.GetAll());
            Field<GameTypeQL>(
                "game",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id", Description = "Id of game" }
                    ),
                resolve: context => gameData.GetAll(context.GetArgument<int>("id")));

            Field<ListGraphType<PlayerTypeQL>>(
                "players",
                resolve: context => playerData.GetAll());
            Field<ListGraphType<PlayerTypeQL>>(
                "player",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id", Description = "Id of game" }
                    ),
                resolve: context => playerData.GetAll(context.GetArgument<int>("id")));

            Field<PlayerTypeQL>(
                "showMe",
                resolve: context => playerData.ShowMe((string)context.UserContext));

        }
    }
}