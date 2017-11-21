using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GroceryRESTStoreWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GroceryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GroceryService.svc or GroceryService.svc.cs at the Solution Explorer and start debugging.
    public class GroceryService : IGroceryService
    {
        private static readonly IList<Vegetable> Vegetables = new List<Vegetable>();
        private static int nextId = 10;

        WebOperationContext webContext = WebOperationContext.Current;

        static GroceryService()
        {
            //NOTE: A simple collection with some basic VEGETABLES that can be called and modified in the RESTful API. 
            #region List of Vegetables

            Vegetable firstVegetable = new Vegetable

            {
                Id = 1,
                Available = true,
                Name = "Cauliflower",
                Price = 17.95,
                Type = "Flowers"
            };
            Vegetables.Add(firstVegetable);
            Vegetables.Add(new Vegetable
            {
                Id = 2,
                Available = true,
                Name = "Carrot",
                Price = 5.95,
                Type = "Roots"
            });
            Vegetables.Add(new Vegetable
            {
                Id = 3,
                Available = true,
                Name = "Cabbages",
                Price = 16.95,
                Type = "Leaves"
            });
            Vegetables.Add(new Vegetable
            {
                Id = 4,
                Available = true,
                Name = "Broccoli",
                Price = 12.95,
                Type = "Flowers"
            });
            Vegetables.Add(new Vegetable
            {
                Id = 5,
                Available = true,
                Name = "Celery",
                Price = 14.95,
                Type = "Stems"
            });
            Vegetables.Add(new Vegetable
            {
                Id = 6,
                Available = true,
                Name = "Artichokes",
                Price = 34.95,
                Type = "Flowers"
            });
            Vegetables.Add(new Vegetable
            {
                Id = 7,
                Available = true,
                Name = "Onions",
                Price = 7.95,
                Type = "Bulbs"
            });
            Vegetables.Add(new Vegetable
            {
                Id = 8,
                Available = true,
                Name = "Spring Onions",
                Price = 12.95,
                Type = "Bulbs"
            });
            Vegetables.Add(new Vegetable
            {
                Id = 9,
                Available = true,
                Name = "Spinach",
                Price = 14.95,
                Type = "Leaves"
            });
            Vegetables.Add(new Vegetable
            {
                Id = 10,
                Available = true,
                Name = "Brussel Sprouts",
                Price = 23.95,
                Type = "Leaves"
            });

            #endregion

        }

        public IList<Vegetable> GetVegetables()
        {
            return Vegetables;
        }

        public Vegetable GetVegetable(string id)
        {
            int idNumber = int.Parse(id);
            return Vegetables.FirstOrDefault(vegetable => vegetable.Id == idNumber);
        }

        string IGroceryService.GetVegetableName(string id)
        {
            Vegetable vegetable = GetVegetable(id);
            if (vegetable == null) return null;
            return vegetable.Name;
        }

        public IEnumerable<Vegetable> GetVegetablesByType(string typeFragment)
        {
            //NOTE: How it works is that looks for vegetables in the list where the name/type contians the name/type fragment. 
            //NOTE: Also that it converts it to lowercase so non-pacal users also can find what they're looking for. 
            //REFERENCE: http://stackoverflow.com/questions/444798/case-insensitive-containsstring

            return Vegetables.Where(vegetable => vegetable.Type.ToLower().Contains(typeFragment.ToLower()));
        }


        public IEnumerable<Vegetable> GetVegetablesByName(string nameFragment)
        {
            return Vegetables.Where(vegetable => vegetable.Name.ToLower().Contains(nameFragment.ToLower()));
        }

        public Vegetable AddVegetable(Vegetable vegetable)
        {
            vegetable.Id = nextId++;
            Vegetables.Add(vegetable);
            return vegetable;
        }

        public Vegetable UpdateVegetable(string id, Vegetable vegetable)
        {
            int idNumber = int.Parse(id);
            Vegetable existingVegetable = Vegetables.FirstOrDefault(b => b.Id == idNumber);
            if (existingVegetable == null) webContext.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            existingVegetable.Name = vegetable.Name;
            existingVegetable.Type = vegetable.Type;
            existingVegetable.Available = vegetable.Available;
            existingVegetable.Price = vegetable.Price;

            return existingVegetable;
        }

        public Vegetable DeleteVegetable(string id)
        {
            Vegetable vegetable = GetVegetable(id);
            if(vegetable == null) webContext.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            bool removed = Vegetables.Remove(vegetable);
            if (removed) return vegetable;
            return null;
        }
    }
}
