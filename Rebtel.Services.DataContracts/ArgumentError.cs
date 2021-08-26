namespace Rebtel.Services.DataContracts
{
  #region Namespace Imports

  using System.Runtime.Serialization;

  #endregion


  [DataContract(Namespace = Ns.FaultContract)]
  public class ArgumentError
  {
    #region Constructors and Destructors

    public ArgumentError(string name, string message)
    {
      Name = name;
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

    [DataMember]
    public string Name
    {
      get;
      set;
    }

    #endregion
  }
}