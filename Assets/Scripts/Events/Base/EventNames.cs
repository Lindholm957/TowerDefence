
namespace Events.Base
{
    public static class EventNames
    {
        public static readonly string[] TEXT_ALL_NAMES = new[]
        {
            Game.Over,
            Game.Restarted,
            Enemy.NonLethalDamaged,
            Enemy.Died,
        };

        public static class Game
        {
            public static string Over => "over";
            public static string Restarted => "restarted";
        }

        public static class Enemy
        {
            public static string NonLethalDamaged => "non_lethal_damaged";
            public static string Died => "died";
        }
    }
}