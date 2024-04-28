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
	public partial class BackupServiceBase : ServiceBase
	{

		#region SaveToken
		public async Task<APIGatewayProxyResponse> SaveToken(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<BackupSaveTokenRequest>(request);
			Console.WriteLine("Backup/SaveToken apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await SaveTokenImpl(apiRequest, context);
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
			Console.WriteLine("Backup/SaveToken apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<BackupSaveTokenResponse> SaveTokenImpl(
			BackupSaveTokenRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("SaveTokenImpl is not implemented"));
			return new BackupSaveTokenResponse();
		}
		#endregion // SaveToken
		#region RemoveToken
		public async Task<APIGatewayProxyResponse> RemoveToken(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<BackupRemoveTokenRequest>(request);
			Console.WriteLine("Backup/RemoveToken apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await RemoveTokenImpl(apiRequest, context);
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
			Console.WriteLine("Backup/RemoveToken apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<BackupRemoveTokenResponse> RemoveTokenImpl(
			BackupRemoveTokenRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("RemoveTokenImpl is not implemented"));
			return new BackupRemoveTokenResponse();
		}
		#endregion // RemoveToken
		#region Transfer
		public async Task<APIGatewayProxyResponse> Transfer(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<BackupTransferRequest>(request);
			Console.WriteLine("Backup/Transfer apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await TransferImpl(apiRequest, context);
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
			Console.WriteLine("Backup/Transfer apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<BackupTransferResponse> TransferImpl(
			BackupTransferRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("TransferImpl is not implemented"));
			return new BackupTransferResponse();
		}
		#endregion // Transfer
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BackupSaveTokenRequest : APIRequest
	{
		[JsonProperty("backup_type")]
		public BackupType backupType { get; set; }
		[JsonProperty("backup_token")]
		public string backupToken { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BackupSaveTokenResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BackupRemoveTokenRequest : APIRequest
	{
		[JsonProperty("backup_type")]
		public BackupType backupType { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BackupRemoveTokenResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BackupTransferRequest : APIRequest
	{
		[JsonProperty("backup_type")]
		public BackupType backupType { get; set; }
		[JsonProperty("backup_token")]
		public string backupToken { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BackupTransferResponse : APIResponse
	{
		[JsonProperty("token")]
		public string token { get; set; }
		[JsonProperty("session_id")]
		public string sessionId { get; set; }
	}
}
