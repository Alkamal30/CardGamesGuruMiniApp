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
                    return GameType.NoPlayersJustCards; break;
                case "MultiPlayerGame":
                    return GameType.MultiPlayerGame; break;
                default:
                    return GameType.None; break;
            }
        }
    }
}