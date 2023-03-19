
namespace Events.Base
{
    public static class EventNames
    {
        public static readonly string[] TEXT_ALL_NAMES = new[]
        {
            Enemy.NonLethalDamaged,
            Enemy.Died,
        };

        public static class Game
        {
            // public static string Started => "started";
        }

        public static class Enemy
        {
            public static string NonLethalDamaged => "non_lethal_damaged";
            public static string Died => "died";
        }
    }
}