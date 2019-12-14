using MongoEAV;
using System;

namespace MongoEAVClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDBContext context = new MongoDBContext("mongodb://localhost:27017", "mongoeav");

            MongoEntity ent1 = new MongoEntity();
            ent1.EntityName = "test entity";
            ent1.EntityFields.Add(new MongoEntityField { name = "f1", type = MongoDB.Bson.BsonType.String });
            ent1.EntityFields.Add(new MongoEntityField { name = "f2", type = MongoDB.Bson.BsonType.Int32 });

            context.CreateEntityDef(ent1);

            Console.ReadKey(); // wait until exit...
        }
    }
}
