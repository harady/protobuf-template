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
	public partial class ShopServiceBase : ServiceBase
	{

		#region PurchaseGooglePlay
		public async Task<APIGatewayProxyResponse> PurchaseGooglePlay(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<ShopPurchaseGooglePlayRequest>(request);
			Console.WriteLine("Shop/PurchaseGooglePlay apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await PurchaseGooglePlayImpl(apiRequest, context);
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
			Console.WriteLine("Shop/PurchaseGooglePlay apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<ShopPurchaseGooglePlayResponse> PurchaseGooglePlayImpl(
			ShopPurchaseGooglePlayRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("PurchaseGooglePlayImpl is not implemented"));
			return new ShopPurchaseGooglePlayResponse();
		}
		#endregion // PurchaseGooglePlay
		#region PurchaseAppStore
		public async Task<APIGatewayProxyResponse> PurchaseAppStore(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<ShopPurchaseAppStoreRequest>(request);
			Console.WriteLine("Shop/PurchaseAppStore apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await PurchaseAppStoreImpl(apiRequest, context);
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
			Console.WriteLine("Shop/PurchaseAppStore apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<ShopPurchaseAppStoreResponse> PurchaseAppStoreImpl(
			ShopPurchaseAppStoreRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("PurchaseAppStoreImpl is not implemented"));
			return new ShopPurchaseAppStoreResponse();
		}
		#endregion // PurchaseAppStore
		#region PurchaseDebug
		public async Task<APIGatewayProxyResponse> PurchaseDebug(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<ShopPurchaseDebugRequest>(request);
			Console.WriteLine("Shop/PurchaseDebug apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await PurchaseDebugImpl(apiRequest, context);
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
			Console.WriteLine("Shop/PurchaseDebug apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<ShopPurchaseDebugResponse> PurchaseDebugImpl(
			ShopPurchaseDebugRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("PurchaseDebugImpl is not implemented"));
			return new ShopPurchaseDebugResponse();
		}
		#endregion // PurchaseDebug
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class ShopPurchaseGooglePlayRequest : APIRequest
	{
		[JsonProperty("shop_item_id")]
		public long shopItemId { get; set; }
		[JsonProperty("signed_data")]
		public string signedData { get; set; }
		[JsonProperty("signature")]
		public string signature { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class ShopPurchaseGooglePlayResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class ShopPurchaseAppStoreRequest : APIRequest
	{
		[JsonProperty("shop_item_id")]
		public long shopItemId { get; set; }
		[JsonProperty("receipt")]
		public string receipt { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class ShopPurchaseAppStoreResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class ShopPurchaseDebugRequest : APIRequest
	{
		[JsonProperty("shop_item_id")]
		public long shopItemId { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class ShopPurchaseDebugResponse : APIResponse
	{
	}
}
