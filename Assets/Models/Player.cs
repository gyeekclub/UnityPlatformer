using System;

namespace Assets.Models
{
    public class Player : IComparable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Coins { get; set; }
        public int CompareTo(object obj)
        {
            var player = (Player) obj;
            return player.Coins - Coins;
        }
    }
}
