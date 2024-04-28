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
	public partial class UnitServiceBase : ServiceBase
	{

		#region DeckEdit
		public async Task<APIGatewayProxyResponse> DeckEdit(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<UnitDeckEditRequest>(request);
			Console.WriteLine("Unit/DeckEdit apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await DeckEditImpl(apiRequest, context);
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
			Console.WriteLine("Unit/DeckEdit apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<UnitDeckEditResponse> DeckEditImpl(
			UnitDeckEditRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("DeckEditImpl is not implemented"));
			return new UnitDeckEditResponse();
		}
		#endregion // DeckEdit
		#region Powerup
		public async Task<APIGatewayProxyResponse> Powerup(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<UnitPowerupRequest>(request);
			Console.WriteLine("Unit/Powerup apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await PowerupImpl(apiRequest, context);
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
			Console.WriteLine("Unit/Powerup apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<UnitPowerupResponse> PowerupImpl(
			UnitPowerupRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("PowerupImpl is not implemented"));
			return new UnitPowerupResponse();
		}
		#endregion // Powerup
		#region Evolution
		public async Task<APIGatewayProxyResponse> Evolution(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<UnitEvolutionRequest>(request);
			Console.WriteLine("Unit/Evolution apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await EvolutionImpl(apiRequest, context);
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
			Console.WriteLine("Unit/Evolution apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<UnitEvolutionResponse> EvolutionImpl(
			UnitEvolutionRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("EvolutionImpl is not implemented"));
			return new UnitEvolutionResponse();
		}
		#endregion // Evolution
		#region Sell
		public async Task<APIGatewayProxyResponse> Sell(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<UnitSellRequest>(request);
			Console.WriteLine("Unit/Sell apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await SellImpl(apiRequest, context);
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
			Console.WriteLine("Unit/Sell apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<UnitSellResponse> SellImpl(
			UnitSellRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("SellImpl is not implemented"));
			return new UnitSellResponse();
		}
		#endregion // Sell
		#region Lock
		public async Task<APIGatewayProxyResponse> Lock(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<UnitLockRequest>(request);
			Console.WriteLine("Unit/Lock apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await LockImpl(apiRequest, context);
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
			Console.WriteLine("Unit/Lock apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<UnitLockResponse> LockImpl(
			UnitLockRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("LockImpl is not implemented"));
			return new UnitLockResponse();
		}
		#endregion // Lock
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UnitDeckEditRequest : APIRequest
	{
		[JsonProperty("user_deck")]
		public UserDeckData userDeck { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UnitDeckEditResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UnitPowerupRequest : APIRequest
	{
		[JsonProperty("user_unit_id")]
		public long userUnitId { get; set; }
		[JsonProperty("consume_resources")]
		public List<ResourceData> consumeResources { get; set; } = new List<ResourceData>();
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UnitPowerupResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UnitEvolutionRequest : APIRequest
	{
		[JsonProperty("user_unit_id")]
		public long userUnitId { get; set; }
		[JsonProperty("unit_evolution_id")]
		public long unitEvolutionId { get; set; }
		[JsonProperty("consume_resources")]
		public List<ResourceData> consumeResources { get; set; } = new List<ResourceData>();
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UnitEvolutionResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UnitSellRequest : APIRequest
	{
		[JsonProperty("user_unit_ids")]
		public List<long> userUnitIds { get; set; } = new List<long>();
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UnitSellResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UnitLockRequest : APIRequest
	{
		[JsonProperty("user_unit_id")]
		public long userUnitId { get; set; }
		[JsonProperty("is_locked")]
		public bool isLocked { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class UnitLockResponse : APIResponse
	{
	}
}
