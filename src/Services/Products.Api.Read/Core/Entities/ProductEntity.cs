using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api.Read.Core.Entities
{
    [BsonCollection("Products")]
    public class ProductEntity : Document
    {
        //[BsonElement("id")]
        //public int Id { get; set; }

        //[BsonElement("details")]
        //public string Details { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("stock")]
        public int Stock { get; set; }

        [BsonElement("price")]
        public int Price { get; set; }




    }
}
