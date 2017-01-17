using GameData.Types;
using GraphQL.Types;
using PlayerData.Models;

namespace PlayerData.Types
{
    public class PlayerTypeQL : ObjectGraphType<Player>
    {
        public PlayerTypeQL()
        {
            Name = "Plyer";
            Description = "Person who play games";

            Field(x => x.Id);
            Field(X => X.Name);
        }

        public PlayerTypeQL(Providers.PlayerData data)
        {
            Name = "Plyer";
            Description = "Person who play games";

            Field(x => x.Id);
            Field(X => X.Name);
            Field<ListGraphType<PlayerTypeQL>>("friends", resolve: context => data.GetFriends(context.Source));
            Field<ListGraphType<GameTypeQL>>("games");


        }

    }
}
