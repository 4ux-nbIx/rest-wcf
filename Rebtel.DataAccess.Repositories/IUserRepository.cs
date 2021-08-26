namespace Rebtel.DataAccess.Repositories
{
  #region Namespace Imports

  using System;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  using Rebtel.Services.DataContracts;

  #endregion


  public interface IUserRepository
  {
    #region Public Methods

    Task AddSubscription(Guid userId, Guid subscriptionId);
    Task AddUser(User user);
    Task DeleteUser(Guid userId);
    Task<List<User>> GetAllUsers();
    Task<User> GetUser(Guid userId);

    #endregion
  }
}