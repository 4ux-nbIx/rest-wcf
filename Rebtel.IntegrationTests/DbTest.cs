namespace Rebtel.IntegrationTests
{
  #region Namespace Imports

  using System;
  using System.Linq;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  using Rebtel.DataAccess.Sql;

  #endregion


  [TestClass]
  public class DbTest
  {
    #region Public Methods

    [TestMethod]
    public void TestConnectionRelationsAndCascadeDelete()
    {
      // TODO: split into separate tests.

      using (var entities = new RebtelContext())
      {
        entities.Users.Add(new User { FirstName = "Test", LastName = "Test", Email = "email", UserId = Guid.NewGuid() });

        entities.Subscriptions.Add(
          new Subscription
          {
            SubscriptionId = Guid.NewGuid(),
            CallMinutes = 10,
            Name = "Name",
            Price = 100,
            PriceIncVatAmount = 120
          });

        int changes = entities.SaveChanges();
        Assert.AreNotEqual(0, changes);
      }

      using (var entities = new RebtelContext())
      {
        Subscription subscription = entities.Subscriptions.First();

        User user = entities.Users.First();
        user.Subscriptions.Add(subscription);

        int changes = entities.SaveChanges();
        Assert.AreNotEqual(0, changes);
      }

      using (var entities = new RebtelContext())
      {
        Subscription subscription = entities.Subscriptions.First();
        entities.Subscriptions.Remove(subscription);

        int changes = entities.SaveChanges();
        Assert.AreNotEqual(0, changes);
      }

      using (var entities = new RebtelContext())
      {
        Subscription subscription =
          entities.Subscriptions.Add(
            new Subscription
            {
              SubscriptionId = Guid.NewGuid(),
              CallMinutes = 10,
              Name = "Name",
              Price = 100,
              PriceIncVatAmount = 120
            });

        User user = entities.Users.First();
        user.Subscriptions.Add(subscription);

        int changes = entities.SaveChanges();
        Assert.AreNotEqual(0, changes);
      }

      using (var entities = new RebtelContext())
      {
        User user = entities.Users.First();
        entities.Users.Remove(user);

        int changes = entities.SaveChanges();
        Assert.AreNotEqual(0, changes);
      }

      using (var entities = new RebtelContext())
      {
        Subscription subscription = entities.Subscriptions.First();

        User user =
          entities.Users.Add(
            new User { FirstName = "Test", LastName = "Test", Email = "email", UserId = Guid.NewGuid() });

        user.Subscriptions.Add(subscription);

        int changes = entities.SaveChanges();
        Assert.AreNotEqual(0, changes);
      }

      using (var entities = new RebtelContext())
      {
        User user = entities.Users.Include("Subscriptions").First();
      }
    }

    #endregion
  }
}