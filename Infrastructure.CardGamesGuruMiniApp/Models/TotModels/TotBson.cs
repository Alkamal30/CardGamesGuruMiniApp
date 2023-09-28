using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CardGamesGuruMiniApp.Models.TotModels
{
    public class TotBson
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid CardId { get; set; }
        public string FirstQuestion { get; set; }
        public string SecondQuestion { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdatedDate { get; set; }
    }
}
