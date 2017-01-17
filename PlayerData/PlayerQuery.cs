//using GraphQL.Types;
//using PlayerData.Types;

//namespace PlayerData
//{
//    class PlayerQuery : ObjectGraphType
//    {
//        public PlayerQuery(Providers.PlayerData playerData)
//        {
//            Field<ListGraphType<PlayerTypeQL>>(
//                "Players",
//                resolve: context => playerData.GetAll());
//            Field<ListGraphType<PlayerTypeQL>>(
//                "Player",
//                arguments: new QueryArguments(
//                    new QueryArgument<IntGraphType> { Name = "id", Description = "Id of game" }
//                    ),
//                resolve: context => playerData.GetAll(context.GetArgument<int>("id")));

//        }
//    }
//}
