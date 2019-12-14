using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoEAV
{
    public interface IMongoDBContext
    {
        void CreateEntityDef(MongoEntity entityDefinition);
        void DeleteEntityDef(string entityDefinitionName);
        MongoEntity GetEntityDef(string entityDefinitionName);
        Dictionary<string, MongoEntity> GetEntityDefs();
    }

    public class MongoDBContext : IMongoDBContext
    {
        public IMongoClient mongoClient { get; set; }
        public IMongoDatabase mongoDatabase { get; set; }

        public MongoDBContext(string connectionString)
        {
            this.mongoClient = new MongoClient(connectionString);
        }

        public MongoDBContext(string connectionString, string database)
        {
            this.mongoClient = new MongoClient(connectionString);
            this.mongoDatabase = mongoClient.GetDatabase(database);
        }

        public void CreateEntityDef(MongoEntity entityDefinition)
        {
            IMongoCollection<MongoEntity> entityDefs = mongoDatabase.GetCollection<MongoEntity>("EntityDefs");
            entityDefs.InsertOne(entityDefinition);
        }

        public void DeleteEntityDef(string entityDefinitionName)
        {
            mongoDatabase.GetCollection<MongoEntity>("EntityDefs").DeleteOne<MongoEntity>(x => x.EntityName.Equals(entityDefinitionName));

        }

        public MongoEntity GetEntityDef(string entityDefinitionName)
        {
            IMongoCollection<MongoEntity> entityDefs = mongoDatabase.GetCollection<MongoEntity>("EntityDefs");
            return entityDefs.Find<MongoEntity>(x => x.EntityName.Equals(entityDefinitionName)).FirstOrDefault();
        }

        public Dictionary<string, MongoEntity> GetEntityDefs()
        {
            var collection = mongoDatabase.GetCollection<MongoEntity>("EntityDefs");
            
        }
    }
}
