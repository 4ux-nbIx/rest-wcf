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
  public class SubscriptionRepositoryService : ISubscriptionRepositoryService
  {
    #region Constants and Fields

    private readonly ISubscriptionRepository _subscriptionRepository;

    #endregion


    #region Constructors and Destructors

    public SubscriptionRepositoryService(ISubscriptionRepository subscriptionRepository)
    {
      _subscriptionRepository = subscriptionRepository;
    }

    #endregion


    #region Public Methods

    public async Task CreateSubscription(Subscription subscription)
    {
      try
      {
        await _subscriptionRepository.CreateSubscription(subscription);
      }
      catch (Exception e)
      {
        throw new InternalError(e.Message).ToException();
      }
    }


    public async Task DeleteSubscription(Guid id)
    {
      try
      {
        await _subscriptionRepository.DeleteSubscription(id);
      }
      catch (Exception e)
      {
        throw new InternalError(e.Message).ToException();
      }
    }


    public async Task<List<Subscription>> GetAllSubscriptions()
    {
      try
      {
        return await _subscriptionRepository.GetAllSubscriptions();
      }
      catch (Exception e)
      {
        throw new InternalError(e.Message).ToException();
      }
    }


    public async Task<Subscription> GetSubscription(Guid id)
    {
      try
      {
        return await _subscriptionRepository.GetSubscription(id);
      }
      catch (Exception e)
      {
        throw new InternalError(e.Message).ToException();
      }
    }


    public async Task UpdateSubscription(Subscription subscription)
    {
      try
      {
        await _subscriptionRepository.UpdateSubscription(subscription);
      }
      catch (Exception e)
      {
        throw new InternalError(e.Message).ToException();
      }
    }

    #endregion
  }
}