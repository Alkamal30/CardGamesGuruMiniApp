using Domain.CardGamesGuruMiniApp.Enums.GameEnums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.CardGamesGuruMiniApp.Models.GamesModels
{
    public class GameBson
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public GameType GameType { get; set; }

        public string NameIndex { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdatedDate { get; set; }

        public string Endpoint { get; set; }
        public List<string> Colors { get; set; }
        public string Font { get; set; }
    }
}