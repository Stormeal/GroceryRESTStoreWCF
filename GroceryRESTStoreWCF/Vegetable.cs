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

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public double Price { get; set; }


    }
}