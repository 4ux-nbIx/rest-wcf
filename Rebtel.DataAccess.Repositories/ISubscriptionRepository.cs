namespace Rebtel.DataAccess.Repositories
{
  #region Namespace Imports

  using System;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  using Rebtel.Services.DataContracts;

  #endregion


  public interface ISubscriptionRepository
  {
    #region Public Methods

    Task CreateSubscription(Subscription subscription);
    Task DeleteSubscription(Guid id);
    Task<List<Subscription>> GetAllSubscriptions();
    Task<Subscription> GetSubscription(Guid id);
    Task UpdateSubscription(Subscription subscription);

    #endregion
  }
}