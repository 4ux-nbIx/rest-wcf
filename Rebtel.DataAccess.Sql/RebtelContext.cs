namespace Rebtel.DataAccess.Sql
{
  #region Namespace Imports

  using System.Data.Entity;

  using AutoMapper;

  #endregion


  internal class RebtelContext : DbContext
  {
    #region Constructors and Destructors

    public RebtelContext(string nameOrConnectionString = "name=RebtelDatabase")
      : base(nameOrConnectionString)
    {
      Mapper.CreateMap<Subscription, Services.DataContracts.Subscription>()
        .ForMember(s => s.Id, expression => expression.MapFrom(s => s.SubscriptionId));

      Mapper.CreateMap<Services.DataContracts.Subscription, Subscription>()
        .ForMember(s => s.SubscriptionId, expression => expression.MapFrom(s => s.Id));

      Mapper.CreateMap<User, Services.DataContracts.User>()
        .ForMember(u => u.Id, expression => expression.MapFrom(u => u.UserId));

      Mapper.CreateMap<Services.DataContracts.User, User>()
        .ForMember(u => u.UserId, expression => expression.MapFrom(u => u.Id));
    }

    #endregion


    #region Properties

    public DbSet<Subscription> Subscriptions
    {
      get;
      set;
    }

    public DbSet<User> Users
    {
      get;
      set;
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().HasMany(u => u.Subscriptions).WithMany(s => s.Users).Map(
        m =>
        {
          m.MapLeftKey("UserId");
          m.MapRightKey("SubscriptionId");
          m.ToTable("UserSubscriptions");
        });
    }

    #endregion
  }
}