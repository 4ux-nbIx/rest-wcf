namespace Rebtel.DataAccess.Services.Wcf
{
  #region Namespace Imports

  using System;
  using System.Collections.Generic;
  using System.ServiceModel;
  using System.Threading.Tasks;

  using Rebtel.DataAccess.Repositories;
  using Rebtel.Services.DataContracts;

  #endregion

  [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
  public class UserRepositoryService : IUserRepositoryService
  {
    #region Constants and Fields

    private readonly IUserRepository _userRepository;

    #endregion


    #region Constructors and Destructors

    public UserRepositoryService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    #endregion


    #region Public Methods

    public async Task AddSubscription(Guid userId, Guid subscriptionId)
    {
      try
      {
        await _userRepository.AddSubscription(userId, subscriptionId);
      }
      catch (Exception e)
      {
        throw new InternalError(e.Message).ToException();
      }
    }


    public async Task CreateUser(User user)
    {
      try
      {
        await _userRepository.AddUser(user);
      }
      catch (Exception e)
      {
        throw new InternalError(e.Message).ToException();
      }
    }


    public async Task DeleteUser(Guid userId)
    {
      try
      {
        await _userRepository.DeleteUser(userId);
      }
      catch (Exception e)
      {
        throw new InternalError(e.Message).ToException();
      }
    }


    public async Task<List<User>> GetAllUsers()
    {
      try
      {
        return await _userRepository.GetAllUsers();
      }
      catch (Exception e)
      {
        throw new InternalError(e.Message).ToException();
      }
    }


    public async Task<User> GetUser(Guid userId)
    {
      try
      {
        return await _userRepository.GetUser(userId);
      }
      catch (Exception e)
      {
        throw new InternalError(e.Message).ToException();
      }
    }

    #endregion
  }
}