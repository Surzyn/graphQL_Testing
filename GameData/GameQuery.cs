//using GameData.Types;
//using GraphQL.Types;

//namespace GameData
//{
//    public class GameQuery : ObjectGraphType
//    {
//        public GameQuery(GameDataProvider data)
//        {
//            Field<ListGraphType<GameTypeQL>>(
//                "games",
//                resolve: context => data.GetAll());
//            Field<GameTypeQL>(
//                "game",
//                arguments: new QueryArguments(
//                    new QueryArgument<IntGraphType> {Name = "id", Description = "Id of game"}
//                    ),
//                resolve: context => data.GetAll(context.GetArgument<int>("id")));
//        }
//    }
//}
