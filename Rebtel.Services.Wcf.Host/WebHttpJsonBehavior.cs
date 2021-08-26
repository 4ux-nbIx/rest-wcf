namespace Rebtel.Services.Wcf.Host
{
  #region Namespace Imports

  using System.ServiceModel.Description;
  using System.ServiceModel.Dispatcher;

  #endregion


  public sealed class WebHttpJsonBehavior : WebHttpBehavior
  {
    #region Methods

    protected override IDispatchMessageFormatter GetReplyDispatchFormatter(
      OperationDescription operationDescription,
      ServiceEndpoint endpoint)
    {
      return new JsonMessageFormatter();
    }

    #endregion
  }
}