using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication4.Model
{
    public class Carro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]//ignora os elementos extras, caso tenha na classe mas não tenha no banco
        public string? Id { get; set; }

        [BsonElement("Marca")]
        public string? Marca { get; set; }

        [BsonElement("Ano")]
        public int Ano { get; set; }


    }
}
