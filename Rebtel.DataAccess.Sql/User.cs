namespace Rebtel.DataAccess.Sql
{
  #region Namespace Imports

  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;

  #endregion


  public class User
  {
    #region Constructors and Destructors

    public User()
    {
      Subscriptions = new List<Subscription>();
    }

    #endregion


    #region Properties

    [Required]
    [StringLength(255)]
    public string Email
    {
      get;
      set;
    }

    [Required]
    [StringLength(255)]
    public string FirstName
    {
      get;
      set;
    }

    [Required]
    [StringLength(255)]
    public string LastName
    {
      get;
      set;
    }

    public ICollection<Subscription> Subscriptions
    {
      get;
      set;
    }

    [Key]
    [Required]
    public Guid UserId
    {
      get;
      set;
    }

    #endregion
  }
}