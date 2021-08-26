namespace Rebtel.Services.DataContracts
{
  #region Namespace Imports

  using System.ServiceModel;

  #endregion


  public static class FaultExceptionHelper
  {
    #region Public Methods

    public static FaultException<TFault> ToException<TFault>(this TFault fault)
    {
      return new FaultException<TFault>(fault);
    }

    #endregion
  }
}