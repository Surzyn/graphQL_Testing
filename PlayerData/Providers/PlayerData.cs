using System;
using System.Collections.Generic;
using System.Linq;
using GameData;
using GameData.Models;
using PlayerData.Models;

namespace PlayerData.Providers
{
    public interface IPlayerData
    {
        List<Player> GetAll();
        Player GetAll(int playerId);
        IEnumerable<Player> GetFriends(Player player);
        Player ShowMe(string userContext);
    }

    public class PlayerData : IPlayerData
    {
        private List<Player> _players = new List<Player>();

        public PlayerData()
        {
            _players.Add(new Player() { Id = 1, Name = "Bob", Games = new List<int>() { 1, 2 }, Friends = new List<int>() { 2 } });
            _players.Add(new Player() { Id = 2, Name = "Tom", Games = new List<int>() { 3, 4 }, Friends = new List<int>() { 1 } });
            _players.Add(new Player() { Id = 3, Name = "Mack", Games = new List<int>() { 1, 4 }, Friends = new List<int>() { 4, 5 } });
            _players.Add(new Player() { Id = 4, Name = "Juliusz", Games = new List<int>() { 1, 5 }, Friends = new List<int>() { 1, 2 } });
            _players.Add(new Player() { Id = 5, Name = "Rob", Games = new List<int>() { 2, 4 }, Friends = new List<int>() { 2, 1, 4 } });
        }


        public List<Player> GetAll()
        {
            return _players;
        }

        public Player GetAll(int playerId)
        {
            return _players.FirstOrDefault(z => z.Id == playerId);
        }

        public IEnumerable<Player> GetFriends(Player player)
        {
            if (player == null)
            {
                return null;
            }

            var friends = _players.Where(x => player.Friends.Contains(x.Id));
            return friends;
        }

        public Player ShowMe(string userContext)
        {
            return _players.FirstOrDefault(z => z.Name == userContext);

        }

        public IEnumerable<Game> GetGames(Player player)
        {
            var games = new GameDataProvider(); //TODO: fix this
            return games.GetAll().Where(x => player.Games.Contains(x.Id));
        }
    }
}
