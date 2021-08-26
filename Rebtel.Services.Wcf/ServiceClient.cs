namespace Rebtel.Services.Wcf
{
  #region Namespace Imports

  using System;
  using System.ServiceModel;
  using System.Threading.Tasks;

  using Rebtel.Services.DataContracts;

  #endregion


  internal sealed class ServiceClient<TContract> : ClientBase<TContract> where TContract : class
  {
    #region Constructors and Destructors

    private ServiceClient()
    {
    }

    #endregion


    #region Properties

    private new TContract Channel
    {
      get
      {
        return base.Channel;
      }
    }

    #endregion


    #region Public Methods

    public static async Task<TResult> Invoke<TResult>(Func<TContract, Task<TResult>> action)
    {
      var client = new ServiceClient<TContract>();

      try
      {
        TResult result = await action(client.Channel);
        client.Close();

        return result;
      }
      catch (FaultException)
      {
        throw;
      }
      catch (Exception e)
      {
        throw new InternalError(e.Message).ToException();
      }
      finally
      {
        CloseOrAbort(client);
      }
    }


    public static async Task Invoke(Func<TContract, Task> action)
    {
      var client = new ServiceClient<TContract>();

      try
      {
        await action(client.Channel);
        client.Close();
      }
      catch (FaultException)
      {
        throw;
      }
      catch (Exception e)
      {
        throw new InternalError(e.Message).ToException();
      }
      finally
      {
        CloseOrAbort(client);
      }
    }

    #endregion


    #region Methods

    private static void CloseOrAbort(ICommunicationObject client)
    {
      if (client.State == CommunicationState.Faulted)
      {
        client.Abort();
      }
      else if (client.State != CommunicationState.Closed)
      {
        client.Close();
      }
    }

    #endregion
  }
}