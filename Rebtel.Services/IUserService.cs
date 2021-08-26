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
  public interface IUserService
  {
    #region Public Methods

    [OperationContract]
    [WebInvoke(UriTemplate = "/{userId}/{subscriptionId}", Method = "PUT")]
    [FaultContract(typeof(InternalError))]
    [FaultContract(typeof(ArgumentError))]
    Task AddSubscription(string userId, string subscriptionId);


    [OperationContract]
    [WebInvoke(UriTemplate = "/", Method = "POST", RequestFormat = WebMessageFormat.Json,
      ResponseFormat = WebMessageFormat.Json)]
    [FaultContract(typeof(InternalError))]
    [FaultContract(typeof(ArgumentError))]
    Task CreateUser(User user);


    [OperationContract]
    [WebInvoke(UriTemplate = "/{userId}", Method = "DELETE")]
    [FaultContract(typeof(InternalError))]
    [FaultContract(typeof(ArgumentError))]
    Task DeleteUser(string userId);


    [OperationContract]
    [WebGet(UriTemplate = "/")]
    [FaultContract(typeof(InternalError))]
    Task<List<User>> GetAllUsers();


    [OperationContract]
    [WebGet(UriTemplate = "/{userId}")]
    [FaultContract(typeof(InternalError))]
    [FaultContract(typeof(ArgumentError))]
    Task<User> GetUser(string userId);

    #endregion
  }
}