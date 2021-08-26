namespace Rebtel.DataAccess.Sql
{
  #region Namespace Imports

  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;

  #endregion


  public class Subscription
  {
    #region Properties

    [Required]
    public int CallMinutes
    {
      get;
      set;
    }

    [Required]
    [StringLength(255)]
    public string Name
    {
      get;
      set;
    }

    [Required]
    public decimal Price
    {
      get;
      set;
    }

    [Required]
    public decimal PriceIncVatAmount
    {
      get;
      set;
    }

    [Key]
    [Required]
    public Guid SubscriptionId
    {
      get;
      set;
    }

    public virtual ICollection<User> Users
    {
      get;
      set;
    }

    #endregion
  }
}