using System;
using System.Collections.Generic;
using System.Text;

namespace MongoEAV
{
    public class MongoEntity
    {
        public string EntityName { get; set; }
        public ICollection<MongoEntityField> EntityFields = new List<MongoEntityField>();
    }
}
