using System;
using System.Text.RegularExpressions;
using Windows.Models.Debugging;

namespace Windows.Models.Extensions
{
    public static class WheelExtension
    {
        private const char TaxonomySeparator = '/';

        public static string Level1(this Wheel wheel)
        {
            var levelText = GetLevel(wheel.Position, Level.One);

            if (!string.IsNullOrWhiteSpace(levelText))
            {
                const string prefix = "KD: ";
                levelText = Regex.Replace(levelText, prefix, string.Empty);
            }

            return levelText;
        }

        public static string Level2(this Wheel wheel)
        {
            return GetLevel(wheel.Position, Level.Two);
        }

        public static string Level3(this Wheel wheel)
        {
            return GetLevel(wheel.Position, Level.Three);
        }

        public static string Level4(this Wheel wheel)
        {
            return GetLevel(wheel.Position, Level.Four);
        }

        private static string GetLevel(string text, Level level)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            var parts = text.Split(new[] { TaxonomySeparator }, StringSplitOptions.RemoveEmptyEntries);

            return GetPart(parts, (int)level);
        }

        private static string GetPart(string[] parts, int position)
        {
            return parts.Length <= position ? null : parts[position];
        }
    }

    public enum Level
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4
    }
}
