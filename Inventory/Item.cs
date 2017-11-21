using System.Runtime.Serialization;

namespace Inventory
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public string Name { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }


    }
}
