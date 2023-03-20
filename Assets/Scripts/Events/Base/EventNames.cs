namespace Events.Base
{
    public static class EventNames
    {
        public static readonly string[] TEXT_ALL_NAMES = new[]
        {
            Game.Over,
            Game.Restarted,
            Bullet.Reached
        };

        public static class Game
        {
            public static string Over => "over";
            public static string Restarted => "restarted";
        }

        public static class Bullet
        {
            public static string Reached => "reached";
        }
    }
}