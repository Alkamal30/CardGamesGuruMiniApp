using Domain.CardGamesGuruMiniApp.Enums.GameEnums;

namespace Domain.CardGamesGuruMiniApp.Mapping
{
    public static class EnumMapping
    {
        public static GameType MapGameType(string gameType)
        {
            if (String.IsNullOrEmpty(gameType)) throw new ArgumentNullException(gameType);

            switch (gameType)
            {
                case "NoPlayersJustCards":
                    return GameType.NoPlayersJustCards;

                case "MultiPlayerGame":
                    return GameType.MultiPlayerGame;

                default:
                    return GameType.None;
            }
        }
    }
}