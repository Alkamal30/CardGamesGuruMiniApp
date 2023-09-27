using Domain.CardGamesGuruMiniApp.Enums.GameEnums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    return GameType.NoPlayersJustCards; break;
            }
        }
    }
}
