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
	public partial class OperationServiceBase : ServiceBase
	{

		#region Test
		public async Task<APIGatewayProxyResponse> Test(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<OperationTestRequest>(request);
			Console.WriteLine("Operation/Test apiRequest=" + JsonConvert.SerializeObject(apiRequest));

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
			Console.WriteLine("Operation/Test apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<OperationTestResponse> TestImpl(
			OperationTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("TestImpl is not implemented"));
			return new OperationTestResponse();
		}
		#endregion // Test
		#region Test1
		public async Task<APIGatewayProxyResponse> Test1(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<OperationTestRequest>(request);
			Console.WriteLine("Operation/Test1 apiRequest=" + JsonConvert.SerializeObject(apiRequest));

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
			Console.WriteLine("Operation/Test1 apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<OperationTestResponse> Test1Impl(
			OperationTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test1Impl is not implemented"));
			return new OperationTestResponse();
		}
		#endregion // Test1
		#region Test2
		public async Task<APIGatewayProxyResponse> Test2(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<OperationTestRequest>(request);
			Console.WriteLine("Operation/Test2 apiRequest=" + JsonConvert.SerializeObject(apiRequest));

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
			Console.WriteLine("Operation/Test2 apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<OperationTestResponse> Test2Impl(
			OperationTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test2Impl is not implemented"));
			return new OperationTestResponse();
		}
		#endregion // Test2
		#region Test3
		public async Task<APIGatewayProxyResponse> Test3(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<OperationTestRequest>(request);
			Console.WriteLine("Operation/Test3 apiRequest=" + JsonConvert.SerializeObject(apiRequest));

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
			Console.WriteLine("Operation/Test3 apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<OperationTestResponse> Test3Impl(
			OperationTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test3Impl is not implemented"));
			return new OperationTestResponse();
		}
		#endregion // Test3
		#region Test4
		public async Task<APIGatewayProxyResponse> Test4(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<OperationTestRequest>(request);
			Console.WriteLine("Operation/Test4 apiRequest=" + JsonConvert.SerializeObject(apiRequest));

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
			Console.WriteLine("Operation/Test4 apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<OperationTestResponse> Test4Impl(
			OperationTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test4Impl is not implemented"));
			return new OperationTestResponse();
		}
		#endregion // Test4
		#region Test5
		public async Task<APIGatewayProxyResponse> Test5(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<OperationTestRequest>(request);
			Console.WriteLine("Operation/Test5 apiRequest=" + JsonConvert.SerializeObject(apiRequest));

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
			Console.WriteLine("Operation/Test5 apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<OperationTestResponse> Test5Impl(
			OperationTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test5Impl is not implemented"));
			return new OperationTestResponse();
		}
		#endregion // Test5
		#region UpdateMasterVersion
		public async Task<APIGatewayProxyResponse> UpdateMasterVersion(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<OperationUpdateMasterVersionRequest>(request);
			Console.WriteLine("Operation/UpdateMasterVersion apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await UpdateMasterVersionImpl(apiRequest, context);
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
			Console.WriteLine("Operation/UpdateMasterVersion apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<OperationUpdateMasterVersionResponse> UpdateMasterVersionImpl(
			OperationUpdateMasterVersionRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("UpdateMasterVersionImpl is not implemented"));
			return new OperationUpdateMasterVersionResponse();
		}
		#endregion // UpdateMasterVersion
		#region UpdateEventSchedule
		public async Task<APIGatewayProxyResponse> UpdateEventSchedule(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<OperationUpdateEventScheduleRequest>(request);
			Console.WriteLine("Operation/UpdateEventSchedule apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await UpdateEventScheduleImpl(apiRequest, context);
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
			Console.WriteLine("Operation/UpdateEventSchedule apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<OperationUpdateEventScheduleResponse> UpdateEventScheduleImpl(
			OperationUpdateEventScheduleRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("UpdateEventScheduleImpl is not implemented"));
			return new OperationUpdateEventScheduleResponse();
		}
		#endregion // UpdateEventSchedule
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class OperationTestRequest : APIRequest
	{
		[JsonProperty("message")]
		public string message { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class OperationTestResponse : APIResponse
	{
		[JsonProperty("message")]
		public string message { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class OperationUpdateMasterVersionRequest : APIRequest
	{
		[JsonProperty("message")]
		public string message { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class OperationUpdateMasterVersionResponse : APIResponse
	{
		[JsonProperty("message")]
		public string message { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class OperationUpdateEventScheduleRequest : APIRequest
	{
		[JsonProperty("message")]
		public string message { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class OperationUpdateEventScheduleResponse : APIResponse
	{
		[JsonProperty("message")]
		public string message { get; set; }
	}
}
