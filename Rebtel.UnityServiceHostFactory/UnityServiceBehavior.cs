namespace Rebtel.ServiceHostFactory
{
  #region Namespace Imports

  using System.Collections.ObjectModel;
  using System.ServiceModel;
  using System.ServiceModel.Channels;
  using System.ServiceModel.Description;
  using System.ServiceModel.Dispatcher;

  using Microsoft.Practices.Unity;

  #endregion


  internal sealed class UnityServiceBehavior : IServiceBehavior
  {
    #region Constants and Fields

    private readonly IUnityContainer _unityContainer;

    #endregion


    #region Constructors and Destructors

    public UnityServiceBehavior(IUnityContainer unityContainer)
    {
      _unityContainer = unityContainer;
    }

    #endregion


    #region Public Methods

    public void AddBindingParameters(
      ServiceDescription serviceDescription,
      ServiceHostBase serviceHostBase,
      Collection<ServiceEndpoint> endpoints,
      BindingParameterCollection bindingParameters)
    {
    }


    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
      foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
      {
        var channelDispatcher = channelDispatcherBase as ChannelDispatcher;

        if (channelDispatcher == null)
        {
          continue;
        }

        foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
        {
          endpointDispatcher.DispatchRuntime.InstanceProvider = new UnityInstanceProvider(
            serviceDescription.ServiceType,
            _unityContainer);
        }
      }
    }


    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
    }

    #endregion
  }
}