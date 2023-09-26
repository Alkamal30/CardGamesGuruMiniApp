using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Domain.CardGamesGuruMiniApp.Enums.GameEnums;
using System.Text.Json.Serialization;

namespace Infrastructure.CardGamesGuruMiniApp.Models.GamesModels
{
    public class GameBson
    {
        [BsonElement("_id")]
        [BsonId]
        public string Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public GameType GameType { get; set; }

        public string NameIndex { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdatedDate { get; set; }
    }
}
