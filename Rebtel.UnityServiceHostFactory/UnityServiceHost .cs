namespace Rebtel.ServiceHostFactory
{
  #region Namespace Imports

  using System;
  using System.ServiceModel;

  using Microsoft.Practices.Unity;

  #endregion


  internal sealed class UnityServiceHost : ServiceHost

  {
    #region Constants and Fields

    private readonly IUnityContainer _container;

    #endregion


    #region Constructors and Destructors

    public UnityServiceHost(Type serviceType, IUnityContainer container, params Uri[] baseAddresses)
      : base(serviceType, baseAddresses)
    {
      _container = container;
    }

    #endregion


    #region Methods

    protected override void OnOpening()
    {
      if (Description.Behaviors.Find<UnityServiceBehavior>() == null)
      {
        Description.Behaviors.Add(new UnityServiceBehavior(_container));
      }

      base.OnOpening();
    }

    #endregion
  }
}