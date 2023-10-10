using Domain.CardGamesGuruMiniApp.Enums.GameEnums;

namespace Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;

public class Game
{
    public string NameIndex { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public GameType GameType { get; set; }
    public string Endpoint { get; set; }
    public List<string> Colors { get; set; }
    public string Font { get; set; }
}