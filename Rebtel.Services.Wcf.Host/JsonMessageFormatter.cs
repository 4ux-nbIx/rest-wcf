namespace Rebtel.Services.Wcf.Host
{
  #region Namespace Imports

  using System;
  using System.Diagnostics;
  using System.IO;
  using System.ServiceModel.Channels;
  using System.ServiceModel.Dispatcher;
  using System.ServiceModel.Web;
  using System.Text;

  using Newtonsoft.Json;

  #endregion


  internal sealed class JsonMessageFormatter : IDispatchMessageFormatter
  {
    #region Constants and Fields

    private readonly JsonSerializer _serializer;

    #endregion


    #region Constructors and Destructors

    internal JsonMessageFormatter()
    {
      _serializer = new JsonSerializer();
    }

    #endregion


    #region Public Methods

    public void DeserializeRequest(Message message, object[] parameters)
    {
      throw new NotImplementedException();
    }


    public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
    {
      var stream = new MemoryStream();

      var writer = new StreamWriter(stream, Encoding.UTF8, 512, true);
      using (var jsonTextWriter = new JsonTextWriter(writer) { CloseOutput = true })
      {
        _serializer.Serialize(jsonTextWriter, result);

        jsonTextWriter.Flush();
      }

      stream.Seek(0, SeekOrigin.Begin);

      Debug.Assert(WebOperationContext.Current != null, "WebOperationContext.Current != null");
      return WebOperationContext.Current.CreateStreamResponse(stream, "application/json");
    }

    #endregion
  }
}