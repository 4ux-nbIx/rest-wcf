namespace Rebtel.Services
{
  #region Namespace Imports

  using System.Collections.Generic;
  using System.ServiceModel;
  using System.ServiceModel.Web;
  using System.Threading.Tasks;

  using Rebtel.Services.DataContracts;

  #endregion


  [ServiceContract(Namespace = Ns.ServiceContract)]
  public interface ISubscriptionService
  {
    #region Public Methods

    [OperationContract]
    [WebInvoke(UriTemplate = "/", Method = "POST")]
    [FaultContract(typeof(InternalError))]
    [FaultContract(typeof(ArgumentError))]
    Task CreateSubscription(Subscription subscription);


    [OperationContract]
    [WebInvoke(UriTemplate = "/{id}", Method = "DELETE")]
    [FaultContract(typeof(InternalError))]
    [FaultContract(typeof(ArgumentError))]
    Task DeleteSubscription(string id);


    [OperationContract]
    [WebGet(UriTemplate = "/")]
    [FaultContract(typeof(InternalError))]
    Task<List<Subscription>> GetAllSubscriptions();


    [OperationContract]
    [WebGet(UriTemplate = "/{id}")]
    [FaultContract(typeof(InternalError))]
    [FaultContract(typeof(ArgumentError))]
    Task<Subscription> GetSubscription(string id);


    [OperationContract]
    [WebInvoke(UriTemplate = "/{id}", Method = "PUT")]
    [FaultContract(typeof(InternalError))]
    [FaultContract(typeof(ArgumentError))]
    Task UpdateSubscription(string id, Subscription subscription);

    #endregion
  }
}