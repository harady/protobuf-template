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
	public partial class DebugServiceBase : ServiceBase
	{

		#region SetServerTime
		public async Task<APIGatewayProxyResponse> SetServerTime(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<DebugSetServerTimeRequest>(request);
			Console.WriteLine("Debug/SetServerTime apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await SetServerTimeImpl(apiRequest, context);
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
			Console.WriteLine("Debug/SetServerTime apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<DebugSetServerTimeResponse> SetServerTimeImpl(
			DebugSetServerTimeRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("SetServerTimeImpl is not implemented"));
			return new DebugSetServerTimeResponse();
		}
		#endregion // SetServerTime
		#region Test
		public async Task<APIGatewayProxyResponse> Test(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<DebugTestRequest>(request);
			Console.WriteLine("Debug/Test apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await TestImpl(apiRequest, context);
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
			Console.WriteLine("Debug/Test apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<DebugTestResponse> TestImpl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("TestImpl is not implemented"));
			return new DebugTestResponse();
		}
		#endregion // Test
		#region Test1
		public async Task<APIGatewayProxyResponse> Test1(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<DebugTestRequest>(request);
			Console.WriteLine("Debug/Test1 apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await Test1Impl(apiRequest, context);
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
			Console.WriteLine("Debug/Test1 apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<DebugTestResponse> Test1Impl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test1Impl is not implemented"));
			return new DebugTestResponse();
		}
		#endregion // Test1
		#region Test2
		public async Task<APIGatewayProxyResponse> Test2(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<DebugTestRequest>(request);
			Console.WriteLine("Debug/Test2 apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await Test2Impl(apiRequest, context);
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
			Console.WriteLine("Debug/Test2 apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<DebugTestResponse> Test2Impl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test2Impl is not implemented"));
			return new DebugTestResponse();
		}
		#endregion // Test2
		#region Test3
		public async Task<APIGatewayProxyResponse> Test3(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<DebugTestRequest>(request);
			Console.WriteLine("Debug/Test3 apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await Test3Impl(apiRequest, context);
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
			Console.WriteLine("Debug/Test3 apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<DebugTestResponse> Test3Impl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test3Impl is not implemented"));
			return new DebugTestResponse();
		}
		#endregion // Test3
		#region Test4
		public async Task<APIGatewayProxyResponse> Test4(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<DebugTestRequest>(request);
			Console.WriteLine("Debug/Test4 apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await Test4Impl(apiRequest, context);
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
			Console.WriteLine("Debug/Test4 apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<DebugTestResponse> Test4Impl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test4Impl is not implemented"));
			return new DebugTestResponse();
		}
		#endregion // Test4
		#region Test5
		public async Task<APIGatewayProxyResponse> Test5(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<DebugTestRequest>(request);
			Console.WriteLine("Debug/Test5 apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await Test5Impl(apiRequest, context);
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
			Console.WriteLine("Debug/Test5 apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<DebugTestResponse> Test5Impl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test5Impl is not implemented"));
			return new DebugTestResponse();
		}
		#endregion // Test5
		#region Test6
		public async Task<APIGatewayProxyResponse> Test6(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<DebugTestRequest>(request);
			Console.WriteLine("Debug/Test6 apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await Test6Impl(apiRequest, context);
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
			Console.WriteLine("Debug/Test6 apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<DebugTestResponse> Test6Impl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test6Impl is not implemented"));
			return new DebugTestResponse();
		}
		#endregion // Test6
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class DebugSetServerTimeRequest : APIRequest
	{
		[JsonProperty("is_clear")]
		public bool isClear { get; set; }
		[JsonProperty("to_set_server_time")]
		public long toSetServerTime { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class DebugSetServerTimeResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class DebugTestRequest : APIRequest
	{
		[JsonProperty("message")]
		public string message { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class DebugTestResponse : APIResponse
	{
		[JsonProperty("message")]
		public string message { get; set; }
	}
}
