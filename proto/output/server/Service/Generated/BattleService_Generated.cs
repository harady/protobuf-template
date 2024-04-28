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
	public partial class BattleServiceBase : ServiceBase
	{

		#region HelperList
		public async Task<APIGatewayProxyResponse> HelperList(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<BattleHelperListRequest>(request);
			Console.WriteLine("Battle/HelperList apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await HelperListImpl(apiRequest, context);
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
			Console.WriteLine("Battle/HelperList apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<BattleHelperListResponse> HelperListImpl(
			BattleHelperListRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("HelperListImpl is not implemented"));
			return new BattleHelperListResponse();
		}
		#endregion // HelperList
		#region Start
		public async Task<APIGatewayProxyResponse> Start(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<BattleStartRequest>(request);
			Console.WriteLine("Battle/Start apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await StartImpl(apiRequest, context);
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
			Console.WriteLine("Battle/Start apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<BattleStartResponse> StartImpl(
			BattleStartRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("StartImpl is not implemented"));
			return new BattleStartResponse();
		}
		#endregion // Start
		#region Continue
		public async Task<APIGatewayProxyResponse> Continue(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<BattleContinueRequest>(request);
			Console.WriteLine("Battle/Continue apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await ContinueImpl(apiRequest, context);
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
			Console.WriteLine("Battle/Continue apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<BattleContinueResponse> ContinueImpl(
			BattleContinueRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ContinueImpl is not implemented"));
			return new BattleContinueResponse();
		}
		#endregion // Continue
		#region Giveup
		public async Task<APIGatewayProxyResponse> Giveup(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<BattleGiveupRequest>(request);
			Console.WriteLine("Battle/Giveup apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await GiveupImpl(apiRequest, context);
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
			Console.WriteLine("Battle/Giveup apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<BattleGiveupResponse> GiveupImpl(
			BattleGiveupRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("GiveupImpl is not implemented"));
			return new BattleGiveupResponse();
		}
		#endregion // Giveup
		#region Clear
		public async Task<APIGatewayProxyResponse> Clear(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<BattleClearRequest>(request);
			Console.WriteLine("Battle/Clear apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await ClearImpl(apiRequest, context);
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
			Console.WriteLine("Battle/Clear apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<BattleClearResponse> ClearImpl(
			BattleClearRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ClearImpl is not implemented"));
			return new BattleClearResponse();
		}
		#endregion // Clear
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BattleHelperListRequest : APIRequest
	{
		[JsonProperty("stage_id")]
		public long stageId { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BattleHelperListResponse : APIResponse
	{
		[JsonProperty("other_users")]
		public List<OtherUserData> otherUsers { get; set; } = new List<OtherUserData>();
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BattleStartRequest : APIRequest
	{
		[JsonProperty("stage_id")]
		public long stageId { get; set; }
		[JsonProperty("user_deck_id")]
		public long userDeckId { get; set; }
		[JsonProperty("helper_user_id")]
		public long helperUserId { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BattleStartResponse : APIResponse
	{
		[JsonProperty("battle_id")]
		public long battleId { get; set; }
		[JsonProperty("battle_client")]
		public BattleClientData battleClient { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BattleContinueRequest : APIRequest
	{
		[JsonProperty("battle_id")]
		public long battleId { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BattleContinueResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BattleGiveupRequest : APIRequest
	{
		[JsonProperty("battle_id")]
		public long battleId { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BattleGiveupResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BattleClearRequest : APIRequest
	{
		[JsonProperty("battle_id")]
		public long battleId { get; set; }
		[JsonProperty("battle_result")]
		public BattleResultData battleResult { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class BattleClearResponse : APIResponse
	{
		[JsonProperty("result")]
		public long result { get; set; }
		[JsonProperty("battle_rewards")]
		public BattleRewardsData battleRewards { get; set; }
	}
}
