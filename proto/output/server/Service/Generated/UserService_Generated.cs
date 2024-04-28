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
	public partial class UserServiceBase : ServiceBase
	{

		#region DataList
		public async Task<APIGatewayProxyResponse> DataList(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<UserDataListRequest>(request);
			Console.WriteLine("User/DataList apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await DataListImpl(apiRequest, context);
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
			Console.WriteLine("User/DataList apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<UserDataListResponse> DataListImpl(
			UserDataListRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("DataListImpl is not implemented"));
			return new UserDataListResponse();
		}
		#endregion // DataList
		#region NameEdit
		public async Task<APIGatewayProxyResponse> NameEdit(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<UserNameEditRequest>(request);
			Console.WriteLine("User/NameEdit apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await NameEditImpl(apiRequest, context);
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
			Console.WriteLine("User/NameEdit apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<UserNameEditResponse> NameEditImpl(
			UserNameEditRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("NameEditImpl is not implemented"));
			return new UserNameEditResponse();
		}
		#endregion // NameEdit
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UserDataListRequest : APIRequest
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UserDataListResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UserNameEditRequest : APIRequest
	{
		[JsonProperty("name")]
		public string name { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UserNameEditResponse : APIResponse
	{
	}
}
