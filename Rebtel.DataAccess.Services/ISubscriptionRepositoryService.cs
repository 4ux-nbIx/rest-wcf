namespace Rebtel.DataAccess.Services
{
  #region Namespace Imports

  using System;
  using System.Collections.Generic;
  using System.ServiceModel;
  using System.Threading.Tasks;

  using Rebtel.Services.DataContracts;

  #endregion


  [ServiceContract(Namespace = Ns.ServiceContract)]
  public interface ISubscriptionRepositoryService
  {
    #region Public Methods

    [OperationContract]
    [FaultContract(typeof(InternalError))]
    Task CreateSubscription(Subscription subscription);


    [OperationContract]
    [FaultContract(typeof(InternalError))]
    Task DeleteSubscription(Guid id);


    [OperationContract]
    [FaultContract(typeof(InternalError))]
    Task<List<Subscription>> GetAllSubscriptions();


    [OperationContract]
    [FaultContract(typeof(InternalError))]
    Task<Subscription> GetSubscription(Guid id);


    [OperationContract]
    [FaultContract(typeof(InternalError))]
    Task UpdateSubscription(Subscription subscription);

    #endregion
  }
}