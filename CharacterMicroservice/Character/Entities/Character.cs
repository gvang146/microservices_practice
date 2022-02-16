using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Character
{
    public class Character
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Power { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }



    }
}
