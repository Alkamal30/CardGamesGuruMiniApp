using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;
using System.Text.RegularExpressions;

namespace Services.CardGamesGuruMiniApp.Validations
{
    public static class GameCardValidation
    {
        public static bool IsGameValid(this Game game)
        {
            if (game == null) return false;

            foreach (var item in game.Colors)
            {
                if (!String.IsNullOrEmpty(item) && !IsValidRGBFormat(item)) return false;
            }

            if (!IsValidApiPrefix(game.Endpoint)) return false;

            return true;
        }

        private static bool IsValidRGBFormat(string input)
        {
            string pattern = @"^rgb\(\s*\d{1,3}\s*,\s*\d{1,3}\s*,\s*\d{1,3}\s*\)$";
            return Regex.IsMatch(input, pattern);
        }

        private static bool IsValidApiPrefix(string input)
        {
            return input.StartsWith("api/");
        }
    }
}