using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
	public class Catalog
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string CategoryID { get; set; }
		public string CategoryName { get; set; }
	}
}

