using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

//GENERATED CODE, DO NOT EDIT !
namespace AwsDotnetCsharp
{
	public partial class MessageServiceBase : ServiceBase
	{

		#region List
		public async Task<APIGatewayProxyResponse> List(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<MessageListRequest>(request);
			Console.WriteLine("Message/List apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await ListImpl(apiRequest, context);
				await MongoSessionManager.CommitTransactionAsync();
			}
			catch (APIException e) {
				apiResponse = e.apiError;
				context.Logger.Log(e.Message + "\n" + e.StackTrace);
				await MongoSessionManager.AbortTransactionAsync();
			}
			catch (Exception e) {
				apiResponse = APIError.GetDefaultError(e.Message, e.StackTrace);
				context.Logger.Log(e.Message + "\n" + e.StackTrace);
				await MongoSessionManager.AbortTransactionAsync();
			}
			await SendSlackIfError(apiResponse);
			Console.WriteLine("Message/List apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<MessageListResponse> ListImpl(
			MessageListRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ListImpl is not implemented"));
			return new MessageListResponse();
		}
		#endregion // List
		#region Receive
		public async Task<APIGatewayProxyResponse> Receive(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<MessageReceiveRequest>(request);
			Console.WriteLine("Message/Receive apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await ReceiveImpl(apiRequest, context);
				await MongoSessionManager.CommitTransactionAsync();
			}
			catch (APIException e) {
				apiResponse = e.apiError;
				context.Logger.Log(e.Message + "\n" + e.StackTrace);
				await MongoSessionManager.AbortTransactionAsync();
			}
			catch (Exception e) {
				apiResponse = APIError.GetDefaultError(e.Message, e.StackTrace);
				context.Logger.Log(e.Message + "\n" + e.StackTrace);
				await MongoSessionManager.AbortTransactionAsync();
			}
			await SendSlackIfError(apiResponse);
			Console.WriteLine("Message/Receive apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<MessageReceiveResponse> ReceiveImpl(
			MessageReceiveRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ReceiveImpl is not implemented"));
			return new MessageReceiveResponse();
		}
		#endregion // Receive
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class MessageListRequest : APIRequest
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class MessageListResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class MessageReceiveRequest : APIRequest
	{
		[JsonProperty("user_message_id")]
		public long userMessageId { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class MessageReceiveResponse : APIResponse
	{
	}
}
