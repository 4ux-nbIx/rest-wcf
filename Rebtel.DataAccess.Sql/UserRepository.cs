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


  public sealed class UserRepository : IUserRepository
  {
    #region Public Methods

    public async Task AddSubscription(Guid userId, Guid subscriptionId)
    {
      using (var entities = new RebtelContext())
      {
        // TODO: Update without fetching
        User user = await entities.Users.FirstAsync(u => u.UserId == userId).ConfigureAwait(false);

        Subscription subscription =
          await entities.Subscriptions.FirstAsync(s => s.SubscriptionId == subscriptionId).ConfigureAwait(false);

        user.Subscriptions.Add(subscription);

        await entities.SaveChangesAsync().ConfigureAwait(false);
      }
    }


    public async Task AddUser(Services.DataContracts.User user)
    {
      using (var entities = new RebtelContext())
      {
        var newUser = Mapper.Map<User>(user);

        entities.Users.Add(newUser);

        await entities.SaveChangesAsync().ConfigureAwait(false);
      }
    }


    public async Task DeleteUser(Guid userId)
    {
      using (var entities = new RebtelContext())
      {
        // TODO: Deleting without fetching
        User user = await entities.Users.FirstAsync(u => u.UserId == userId).ConfigureAwait(false);
        entities.Users.Remove(user);

        await entities.SaveChangesAsync().ConfigureAwait(false);
      }
    }


    public async Task<List<Services.DataContracts.User>> GetAllUsers()
    {
      using (var entities = new RebtelContext())
      {
        List<User> users = await entities.Users.ToListAsync().ConfigureAwait(false);
        return users.Select(Mapper.Map<Services.DataContracts.User>).ToList();
      }
    }


    public async Task<Services.DataContracts.User> GetUser(Guid userId)
    {
      using (var entities = new RebtelContext())
      {
        User user =
          await entities.Users.Include("Subscriptions").FirstAsync(u => u.UserId == userId).ConfigureAwait(false);

        return Mapper.Map<Services.DataContracts.User>(user);
      }
    }

    #endregion
  }
}