namespace Rebtel.Services.Wcf
{
  #region Namespace Imports

  using System;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  using Rebtel.DataAccess.Services;
  using Rebtel.Services.DataContracts;

  #endregion


  public class UserService : IUserService
  {
    #region Public Methods

    public async Task AddSubscription(string userId, string subscriptionId)
    {
      Guid userGuid;

      try
      {
        userGuid = Guid.Parse(userId);
      }
      catch (Exception e)
      {
        throw new ArgumentError("userId", e.Message).ToException();
      }

      Guid subscriptionGuid;

      try
      {
        subscriptionGuid = Guid.Parse(subscriptionId);
      }
      catch (Exception e)
      {
        throw new ArgumentError("subscriptionId", e.Message).ToException();
      }

      await ServiceClient<IUserRepositoryService>.Invoke(c => c.AddSubscription(userGuid, subscriptionGuid));
    }


    public async Task CreateUser(User user)
    {
      if (user == null)
      {
        throw new ArgumentError("user", "Argument null.").ToException();
      }

      await ServiceClient<IUserRepositoryService>.Invoke(c => c.CreateUser(user));
    }


    public async Task DeleteUser(string userId)
    {
      Guid guid;

      try
      {
        guid = Guid.Parse(userId);
      }
      catch (Exception e)
      {
        throw new ArgumentError("userId", e.Message).ToException();
      }

      await ServiceClient<IUserRepositoryService>.Invoke(c => c.DeleteUser(guid));
    }


    public async Task<List<User>> GetAllUsers()
    {
      return await ServiceClient<IUserRepositoryService>.Invoke(c => c.GetAllUsers());
    }


    public async Task<User> GetUser(string userId)
    {
      Guid guid;

      try
      {
        guid = Guid.Parse(userId);
      }
      catch (Exception e)
      {
        throw new ArgumentError("userId", e.Message).ToException();
      }

      return await ServiceClient<IUserRepositoryService>.Invoke(c => c.GetUser(guid));
    }

    #endregion
  }
}