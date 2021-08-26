namespace Rebtel.Services.Wcf.Host
{
  #region Namespace Imports

  using System;
  using System.ServiceModel.Activation;
  using System.Web;
  using System.Web.Routing;

  using Rebtel.ServiceHostFactory;

  #endregion


  public class Global : HttpApplication
  {
    #region Methods

    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
    }


    protected void Application_BeginRequest(object sender, EventArgs e)
    {
    }


    protected void Application_End(object sender, EventArgs e)
    {
    }


    protected void Application_Error(object sender, EventArgs e)
    {
    }


    protected void Application_Start(object sender, EventArgs e)
    {
      RegisterRoutes(RouteTable.Routes);
    }


    protected void Session_End(object sender, EventArgs e)
    {
    }


    protected void Session_Start(object sender, EventArgs e)
    {
    }


    private static void RegisterRoutes(RouteCollection routes)
    {
      routes.Add(new ServiceRoute("users", new UnityServiceHostFactory(), typeof(IUserService)));
      routes.Add(new ServiceRoute("subscriptions", new UnityServiceHostFactory(), typeof(ISubscriptionService)));
    }

    #endregion
  }
}