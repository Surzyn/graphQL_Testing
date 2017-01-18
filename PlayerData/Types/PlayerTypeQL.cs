using GameData.Models;
using GameData.Types;
using GraphQL.Types;
using PlayerData.Models;
using PlayerData.Providers;

namespace PlayerData.Types
{
    public class PlayerTypeQL : ObjectGraphType
    {
        //private IPlayerData _playerData;
        //public PlayerTypeQL()
        //{
        //    _playerData = playerData;
        //}

        //public PlayerTypeQL()
        //{
        //    Name = "Plyer";
        //    Description = "Person who play games";

        //    Field(x => x.Id);
        //    Field(X => X.Name);
        //    Field<ListGraphType<GameTypeQL>>("games",resolve: context => context.Source.);
        //}

        public PlayerTypeQL()
        {
            Providers.PlayerData playerData = new Providers.PlayerData();

            Name = "Plyer";
            Description = "Person who play games";

            Field<NonNullGraphType<IntGraphType>>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<ListGraphType<PlayerTypeQL>>("friends", resolve: context => playerData.GetFriends(context.Source as Player));
            Field<ListGraphType<GameTypeQL>>("games", resolve: context => playerData.GetGames(context.Source as Player));
        }

    }
}
