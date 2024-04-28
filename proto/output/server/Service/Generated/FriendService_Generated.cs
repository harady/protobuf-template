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
	public partial class FriendServiceBase : ServiceBase
	{

		#region List
		public async Task<APIGatewayProxyResponse> List(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<FriendListRequest>(request);
			Console.WriteLine("Friend/List apiRequest=" + JsonConvert.SerializeObject(apiRequest));

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
			Console.WriteLine("Friend/List apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<FriendListResponse> ListImpl(
			FriendListRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ListImpl is not implemented"));
			return new FriendListResponse();
		}
		#endregion // List
		#region Remove
		public async Task<APIGatewayProxyResponse> Remove(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<FriendRemoveRequest>(request);
			Console.WriteLine("Friend/Remove apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await RemoveImpl(apiRequest, context);
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
			Console.WriteLine("Friend/Remove apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<FriendRemoveResponse> RemoveImpl(
			FriendRemoveRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("RemoveImpl is not implemented"));
			return new FriendRemoveResponse();
		}
		#endregion // Remove
		#region Search
		public async Task<APIGatewayProxyResponse> Search(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<FriendSearchRequest>(request);
			Console.WriteLine("Friend/Search apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await SearchImpl(apiRequest, context);
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
			Console.WriteLine("Friend/Search apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<FriendSearchResponse> SearchImpl(
			FriendSearchRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("SearchImpl is not implemented"));
			return new FriendSearchResponse();
		}
		#endregion // Search
		#region Request
		public async Task<APIGatewayProxyResponse> Request(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<FriendRequestRequest>(request);
			Console.WriteLine("Friend/Request apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await RequestImpl(apiRequest, context);
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
			Console.WriteLine("Friend/Request apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<FriendRequestResponse> RequestImpl(
			FriendRequestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("RequestImpl is not implemented"));
			return new FriendRequestResponse();
		}
		#endregion // Request
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendListRequest : APIRequest
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendListResponse : APIResponse
	{
		[JsonProperty("other_users")]
		public List<OtherUserData> otherUsers { get; set; } = new List<OtherUserData>();
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendRemoveRequest : APIRequest
	{
		[JsonProperty("user_id")]
		public long userId { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendRemoveResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendSearchRequest : APIRequest
	{
		[JsonProperty("code")]
		public long code { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendSearchResponse : APIResponse
	{
		[JsonProperty("other_user")]
		public OtherUserData otherUser { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendRequestRequest : APIRequest
	{
		[JsonProperty("user_id")]
		public long userId { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class FriendRequestResponse : APIResponse
	{
	}
}
