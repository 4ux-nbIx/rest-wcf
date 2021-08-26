namespace Rebtel.Services.Wcf
{
  #region Namespace Imports

  using System;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  using Rebtel.DataAccess.Services;
  using Rebtel.Services.DataContracts;

  #endregion


  public class SubscriptionService : ISubscriptionService
  {
    #region Public Methods

    public async Task CreateSubscription(Subscription subscription)
    {
      if (subscription == null)
      {
        throw new ArgumentError("subscription", "Argument null.").ToException();
      }

      await ServiceClient<ISubscriptionRepositoryService>.Invoke(c => c.CreateSubscription(subscription));
    }


    public async Task DeleteSubscription(string id)
    {
      Guid guid;

      try
      {
        guid = Guid.Parse(id);
      }
      catch (Exception e)
      {
        throw new ArgumentError("id", e.Message).ToException();
      }

      await ServiceClient<ISubscriptionRepositoryService>.Invoke(c => c.DeleteSubscription(guid));
    }


    public async Task<List<Subscription>> GetAllSubscriptions()
    {
      return await ServiceClient<ISubscriptionRepositoryService>.Invoke(c => c.GetAllSubscriptions());
    }


    public async Task<Subscription> GetSubscription(string id)
    {
      Guid guid;

      try
      {
        guid = Guid.Parse(id);
      }
      catch (Exception e)
      {
        throw new ArgumentError("id", e.Message).ToException();
      }

      return await ServiceClient<ISubscriptionRepositoryService>.Invoke(c => c.GetSubscription(guid));
    }


    public async Task UpdateSubscription(string id, Subscription subscription)
    {
      Guid guid;

      try
      {
        guid = Guid.Parse(id);
      }
      catch (Exception e)
      {
        throw new ArgumentError("id", e.Message).ToException();
      }

      if (subscription == null)
      {
        throw new ArgumentError("subscription", "Argument null.").ToException();
      }

      subscription.Id = guid;

      await ServiceClient<ISubscriptionRepositoryService>.Invoke(c => c.UpdateSubscription(subscription));
    }

    #endregion
  }
}