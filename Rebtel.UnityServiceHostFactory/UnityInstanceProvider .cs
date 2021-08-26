namespace Rebtel.ServiceHostFactory
{
  #region Namespace Imports

  using System;
  using System.ServiceModel;
  using System.ServiceModel.Channels;
  using System.ServiceModel.Dispatcher;

  using Microsoft.Practices.Unity;

  #endregion


  public class UnityInstanceProvider : IInstanceProvider
  {
    #region Constants and Fields

    private readonly IUnityContainer _container;
    private readonly Type _serviceType;

    #endregion


    #region Constructors and Destructors

    public UnityInstanceProvider(Type type, IUnityContainer container)
    {
      _serviceType = type;
      _container = container;
    }

    #endregion


    #region IInstanceProvider Members 

    public object GetInstance(InstanceContext instanceContext, Message message)
    {
      return _container.Resolve(_serviceType);
    }


    public object GetInstance(InstanceContext instanceContext)
    {
      // ReSharper disable once AssignNullToNotNullAttribute
      return GetInstance(instanceContext, null);
    }


    public void ReleaseInstance(InstanceContext instanceContext, object instance)
    {
      _container.Teardown(instance);
    }

    #endregion
  }
}