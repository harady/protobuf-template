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
	public partial class FriendRequestServiceBase : ServiceBase
	{

		#region List
		public async Task<APIGatewayProxyResponse> List(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<FriendRequestListRequest>(request);
			Console.WriteLine("FriendRequest/List apiRequest=" + JsonConvert.SerializeObject(apiRequest));

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
			Console.WriteLine("FriendRequest/List apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<FriendRequestListResponse> ListImpl(
			FriendRequestListRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ListImpl is not implemented"));
			return new FriendRequestListResponse();
		}
		#endregion // List
		#region Accept
		public async Task<APIGatewayProxyResponse> Accept(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<FriendRequestAcceptRequest>(request);
			Console.WriteLine("FriendRequest/Accept apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await AcceptImpl(apiRequest, context);
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
			Console.WriteLine("FriendRequest/Accept apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<FriendRequestAcceptResponse> AcceptImpl(
			FriendRequestAcceptRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("AcceptImpl is not implemented"));
			return new FriendRequestAcceptResponse();
		}
		#endregion // Accept
		#region Reject
		public async Task<APIGatewayProxyResponse> Reject(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<FriendRequestRejectRequest>(request);
			Console.WriteLine("FriendRequest/Reject apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await RejectImpl(apiRequest, context);
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
			Console.WriteLine("FriendRequest/Reject apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<FriendRequestRejectResponse> RejectImpl(
			FriendRequestRejectRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("RejectImpl is not implemented"));
			return new FriendRequestRejectResponse();
		}
		#endregion // Reject
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendRequestListRequest : APIRequest
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendRequestListResponse : APIResponse
	{
		[JsonProperty("other_users")]
		public List<OtherUserData> otherUsers { get; set; } = new List<OtherUserData>();
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendRequestAcceptRequest : APIRequest
	{
		[JsonProperty("user_id")]
		public long userId { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendRequestAcceptResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendRequestRejectRequest : APIRequest
	{
		[JsonProperty("user_id")]
		public long userId { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendRequestRejectResponse : APIResponse
	{
	}
}
