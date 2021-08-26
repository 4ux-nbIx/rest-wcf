namespace Rebtel.Services.Wcf.Host
{
  #region Namespace Imports

  using System;
  using System.ServiceModel.Configuration;
  using System.ServiceModel.Web;

  #endregion


  public class WebHttpJsonBehaviorElement : BehaviorExtensionElement
  {
    #region Properties

    public override Type BehaviorType
    {
      get
      {
        return typeof(WebHttpJsonBehavior);
      }
    }

    #endregion


    #region Methods

    protected override object CreateBehavior()
    {
      return new WebHttpJsonBehavior
      {
        DefaultBodyStyle = WebMessageBodyStyle.WrappedResponse,
        DefaultOutgoingResponseFormat = WebMessageFormat.Json,
        DefaultOutgoingRequestFormat = WebMessageFormat.Json,
        AutomaticFormatSelectionEnabled = false
      };
    }

    #endregion
  }
}