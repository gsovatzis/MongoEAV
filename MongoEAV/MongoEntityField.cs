using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoEAV
{

    public class MongoEntityField
    {
        public BsonType type { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }
}
