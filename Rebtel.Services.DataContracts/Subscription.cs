namespace Rebtel.Services.DataContracts
{
  #region Namespace Imports

  using System;
  using System.Runtime.Serialization;

  using Newtonsoft.Json;

  #endregion


  [DataContract(Namespace = Ns.DataContract)]
  public class Subscription
  {
    #region Properties

    [DataMember(Name = "callminutes", IsRequired = true, Order = 4)]
    [JsonProperty(PropertyName = "callminutes", Order = 4)]
    public int CallMinutes
    {
      get;
      set;
    }

    [DataMember(Name = "id", IsRequired = true, Order = 0)]
    [JsonProperty(PropertyName = "id", Order = 0)]
    public Guid Id
    {
      get;
      set;
    }

    [DataMember(Name = "name", IsRequired = true, Order = 1)]
    [JsonProperty(PropertyName = "name", Order = 1)]
    public string Name
    {
      get;
      set;
    }

    [DataMember(Name = "price", IsRequired = true, Order = 2)]
    [JsonProperty(PropertyName = "price", Order = 2)]
    public decimal Price
    {
      get;
      set;
    }

    [DataMember(Name = "priceIncVatAmount", IsRequired = true, Order = 3)]
    [JsonProperty(PropertyName = "priceIncVatAmount", Order = 3)]
    public decimal PriceIncVatAmount
    {
      get;
      set;
    }

    #endregion
  }
}