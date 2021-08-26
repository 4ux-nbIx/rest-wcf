namespace Rebtel.ServiceHostFactory
{
  #region Namespace Imports

  using System;
  using System.ServiceModel;
  using System.ServiceModel.Activation;

  using Microsoft.Practices.Unity;
  using Microsoft.Practices.Unity.Configuration;

  #endregion


  public sealed class UnityServiceHostFactory : ServiceHostFactory
  {
    #region Methods

    protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
    {
      IUnityContainer container = new UnityContainer().LoadConfiguration();

      object instance = container.Resolve(serviceType);
      serviceType = instance.GetType();

      container.Teardown(instance);

      return new UnityServiceHost(serviceType, container, baseAddresses);
    }

    #endregion
  }
}