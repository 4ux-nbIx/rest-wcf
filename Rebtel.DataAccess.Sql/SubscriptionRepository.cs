namespace Rebtel.DataAccess.Sql
{
  #region Namespace Imports

  using System;
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Linq;
  using System.Threading.Tasks;

  using AutoMapper;

  using Rebtel.DataAccess.Repositories;

  #endregion


  public class SubscriptionRepository : ISubscriptionRepository
  {
    #region Public Methods

    public async Task CreateSubscription(Services.DataContracts.Subscription subscription)
    {
      using (var entities = new RebtelContext())
      {
        Subscription newSubscription = Mapper.Map<Subscription>(subscription);
        entities.Subscriptions.Add(newSubscription);

        await entities.SaveChangesAsync().ConfigureAwait(false);
      }
    }


    public async Task DeleteSubscription(Guid id)
    {
      using (var entities = new RebtelContext())
      {
        // TODO: Deleting without fetching
        Subscription subscription =
          await entities.Subscriptions.FirstAsync(s => s.SubscriptionId == id).ConfigureAwait(false);

        entities.Subscriptions.Remove(subscription);

        await entities.SaveChangesAsync().ConfigureAwait(false);
      }
    }


    public async Task<List<Services.DataContracts.Subscription>> GetAllSubscriptions()
    {
      using (var entities = new RebtelContext())
      {
        List<Subscription> subscriptions = await entities.Subscriptions.ToListAsync().ConfigureAwait(false);

        return subscriptions.Select(Mapper.Map<Services.DataContracts.Subscription>).ToList();
      }
    }


    public async Task<Services.DataContracts.Subscription> GetSubscription(Guid id)
    {
      using (var entities = new RebtelContext())
      {
        Subscription subscription =
          await entities.Subscriptions.FirstAsync(s => s.SubscriptionId == id).ConfigureAwait(false);

        return Mapper.Map<Services.DataContracts.Subscription>(subscription);
      }
    }


    public async Task UpdateSubscription(Services.DataContracts.Subscription subscription)
    {
      using (var entities = new RebtelContext())
      {
        Subscription dbSubscription =
          await entities.Subscriptions.FirstAsync(s => s.SubscriptionId == subscription.Id).ConfigureAwait(false);

        Mapper.DynamicMap(subscription, dbSubscription);

        await entities.SaveChangesAsync().ConfigureAwait(false);
      }
    }

    #endregion
  }
}