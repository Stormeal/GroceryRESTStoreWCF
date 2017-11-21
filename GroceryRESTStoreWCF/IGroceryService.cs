using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GroceryRESTStoreWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGroceryService
    {
        #region GET Commands

        [OperationContract]
        [WebInvoke(Method = "GET",
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "vegetables")]
        IList<Vegetable> GetVegetables();

        [OperationContract]
        [WebInvoke(Method = "GET",
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "vegetables/{id}")]
        Vegetable GetVegetable(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "vegetables/{id}/name")]
        string GetVegetableName(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "vegetables/type/{typeFragment}")]
        IEnumerable<Vegetable> GetVegetablesByType(string typeFragment);

        [OperationContract]
        [WebInvoke(Method = "GET",
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "vegetables/name/{nameFragment}")]
        IEnumerable<Vegetable> GetVegetablesByName(string nameFragment);

        #endregion

        [OperationContract]
        [WebInvoke(Method = "POST",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "vegetables")]
        Vegetable AddVegetable(Vegetable vegetable);

        [OperationContract]
        [WebInvoke(Method = "PUT",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "vegetables/{id}")]
        Vegetable UpdateVegetable(string id, Vegetable vegetable);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "vegetables/{id}")]
        Vegetable DeleteVegetable(string id);


    }
}
