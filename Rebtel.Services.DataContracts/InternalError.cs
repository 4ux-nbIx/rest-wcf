namespace Rebtel.Services.DataContracts
{
  #region Namespace Imports

  using System.Runtime.Serialization;

  #endregion


  [DataContract(Namespace = Ns.FaultContract)]
  public class InternalError
  {
    #region Constructors and Destructors

    public InternalError(string message)
    {
      Message = message;
    }

    #endregion


    #region Properties

    [DataMember]
    public string Message
    {
      get;
      set;
    }

    #endregion
  }
}