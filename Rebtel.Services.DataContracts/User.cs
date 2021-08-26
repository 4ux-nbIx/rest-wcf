namespace Rebtel.Services.DataContracts
{
  #region Namespace Imports

  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.Serialization;

  using Newtonsoft.Json;

  #endregion


  [DataContract(Namespace = Ns.DataContract)]
  public class User
  {
    #region Constructors and Destructors

    public User()
    {
      Subscriptions = new List<Subscription>();
    }

    #endregion


    #region Properties

    [DataMember(Name = "email", IsRequired = true, EmitDefaultValue = false, Order = 3)]
    [JsonProperty(PropertyName = "email", Order = 3)]
    public string Email
    {
      get;
      set;
    }

    [DataMember(Name = "firstname", IsRequired = true, EmitDefaultValue = false, Order = 1)]
    [JsonProperty(PropertyName = "firstname", Order = 1)]
    public string FirstName
    {
      get;
      set;
    }

    [DataMember(Name = "id", EmitDefaultValue = false, Order = 0)]
    [JsonProperty(PropertyName = "id", Order = 0)]
    public Guid Id
    {
      get;
      set;
    }

    [DataMember(Name = "lastname", IsRequired = true, Order = 2)]
    [JsonProperty(PropertyName = "lastname", Order = 2)]
    public string LastName
    {
      get;
      set;
    }

    [DataMember(Name = "subscriptions", EmitDefaultValue = false, Order = 4)]
    [JsonProperty(PropertyName = "subscriptions", Order = 4)]
    public List<Subscription> Subscriptions
    {
      get;
      set;
    }

    [JsonProperty(PropertyName = "totalcallminutes", Order = 6)]
    public int TotalCallMinutes
    {
      get
      {
        return Subscriptions == null ? 0 : Subscriptions.Sum(s => s.CallMinutes);
      }
    }

    [JsonProperty(PropertyName = "totalPriceIncVatAmount", Order = 5)]
    public decimal TotalPriceIncVatAmount
    {
      get
      {
        return Subscriptions == null ? 0 : Subscriptions.Sum(s => s.PriceIncVatAmount);
      }
    }

    #endregion
  }
}