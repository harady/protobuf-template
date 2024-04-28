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
	public partial class SystemServiceBase : ServiceBase
	{

		#region Ping
		public async Task<APIGatewayProxyResponse> Ping(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<SystemPingRequest>(request);
			Console.WriteLine("System/Ping apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await PingImpl(apiRequest, context);
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
			Console.WriteLine("System/Ping apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<SystemPingResponse> PingImpl(
			SystemPingRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("PingImpl is not implemented"));
			return new SystemPingResponse();
		}
		#endregion // Ping
		#region Signup
		public async Task<APIGatewayProxyResponse> Signup(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<SystemSignupRequest>(request);
			Console.WriteLine("System/Signup apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await SignupImpl(apiRequest, context);
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
			Console.WriteLine("System/Signup apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<SystemSignupResponse> SignupImpl(
			SystemSignupRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("SignupImpl is not implemented"));
			return new SystemSignupResponse();
		}
		#endregion // Signup
		#region Login
		public async Task<APIGatewayProxyResponse> Login(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<SystemLoginRequest>(request);
			Console.WriteLine("System/Login apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await LoginImpl(apiRequest, context);
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
			Console.WriteLine("System/Login apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<SystemLoginResponse> LoginImpl(
			SystemLoginRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("LoginImpl is not implemented"));
			return new SystemLoginResponse();
		}
		#endregion // Login
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class SystemPingRequest : APIRequest
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class SystemPingResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class SystemSignupRequest : APIRequest
	{
		[JsonProperty("name")]
		public string name { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class SystemSignupResponse : APIResponse
	{
		[JsonProperty("token")]
		public string token { get; set; }
		[JsonProperty("session_id")]
		public string sessionId { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class SystemLoginRequest : APIRequest
	{
		[JsonProperty("token")]
		public string token { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class SystemLoginResponse : APIResponse
	{
		[JsonProperty("session_id")]
		public string sessionId { get; set; }
	}
}
