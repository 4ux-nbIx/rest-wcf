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
  public interface IUserRepositoryService
  {
    #region Public Methods

    [OperationContract]
    [FaultContract(typeof(InternalError))]
    Task AddSubscription(Guid userId, Guid subscriptionId);


    [OperationContract]
    [FaultContract(typeof(InternalError))]
    Task CreateUser(User user);


    [OperationContract]
    [FaultContract(typeof(InternalError))]
    Task DeleteUser(Guid userId);


    [OperationContract]
    [FaultContract(typeof(InternalError))]
    Task<List<User>> GetAllUsers();


    [OperationContract]
    [FaultContract(typeof(InternalError))]
    Task<User> GetUser(Guid userId);

    #endregion
  }
}