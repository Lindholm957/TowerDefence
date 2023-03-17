
namespace Events.Base
{
    public static class EventNames
    {
        public static readonly string[] TEXT_ALL_NAMES = new[]
        {
            Enemy.Died,
            Data.TotalDamageChanged,
            Data.AttackSpeedChanged,
            Data.AttackSpeedDistanceChanged
        };

        public static class Game
        {
            // public static string Started => "started";
        }

        public static class Base
        {
        }
        
        public static class Enemy
        {
            public static string Died => "died";
        }
        
        public static class Data
        {
            public static string TotalDamageChanged => "total_damage_changed";
            public static string AttackSpeedChanged => "attack_speed_changed";
            public static string AttackSpeedDistanceChanged => "attack_speed_distance_changed";
        }
    }
}