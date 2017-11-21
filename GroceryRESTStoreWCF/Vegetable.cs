using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GroceryRESTStoreWCF
{
    [DataContract]
    public class Vegetable
    {
        [DataMember]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
        public double Price { get; set; }

    }
}