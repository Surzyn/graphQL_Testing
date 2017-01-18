using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameData.Models;
using GameData.Types;
using GraphQL.Types;

namespace PlayerData.Models
{
    public class CharacterInterface : InterfaceGraphType<Player>
    {
        public CharacterInterface()
        {
            Name = "Character";

            Field(d => d.Id).Description("The id of the character.");
            Field(d => d.Name, nullable: true).Description("The name of the character.");

            Field<ListGraphType<CharacterInterface>>("friends");
        }
    }

    public class GameInterface : InterfaceGraphType<Game>
    {
        public GameInterface()
        {
            Name = "Game";

            Field(d => d.Id).Description("The id of the game.");
            Field(d => d.Name, nullable: true).Description("The name of the game.");

            Field<ListGraphType<GameInterface>>("games");
        }
    }
}
