using System.IO;

namespace Monry.CAFUSample.Application
{
    public static partial class Constant
    {
        public static class Animator
        {
            public static class TriggerName
            {
                public const string Show = "Show";
                public const string Hide = "Hide";
                public const string Hit = "Hit";
                public const string Feint = "Feint";
                public const string Attack = "Attack";
            }
            public static class AnimationStateName
            {
                public const string Show = "Show";
                public const string Hide = "Hide";
                public const string Hit = "Hit";
                public const string Feint = "Feint";
                public const string Attack = "Attack";
            }
        }


        public const int MoleAmount = 10;

        public const float RemainingTime = 30.0f;

        public const float MoleActiveDuration = 1.5f;

        public const float MoleInactiveDurationFrom = 0.0f;

        public const float MoleInactiveDurationTo = 5.0f;

        public static readonly string ResultListFilePath = Path.Combine("Data", "result_list.bytes");
    }
}