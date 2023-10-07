using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Domain.CardGamesGuruMiniApp.Enums.GameEnums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GameType
    {
        None = 0,
        NoPlayersJustCards = 1,
        MultiPlayerGame = 2
    }
}