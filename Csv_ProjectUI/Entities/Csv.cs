using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csv_ProjectUI.Entities
{

    [BsonIgnoreExtraElements]
    public class Csv
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public int MainLevel_id { get; set; }
        public int XRmean { get; set; }
        public int XRmin { get; set; }
        public int XRmax { get; set; }
        public float SDNN { get; set; }
        public float Rmssd { get; set; }
        public float NN50 { get; set; }
        public float pNN50 { get; set; }
        public float ValueIndex { get; set; }
        public long created_at { get; set; }

    }
}
