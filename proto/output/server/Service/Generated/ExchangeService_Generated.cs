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
	public partial class ExchangeServiceBase : ServiceBase
	{

		#region Exchange
		public async Task<APIGatewayProxyResponse> Exchange(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<ExchangeExchangeRequest>(request);
			Console.WriteLine("Exchange/Exchange apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await ExchangeImpl(apiRequest, context);
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
			Console.WriteLine("Exchange/Exchange apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<ExchangeExchangeResponse> ExchangeImpl(
			ExchangeExchangeRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ExchangeImpl is not implemented"));
			return new ExchangeExchangeResponse();
		}
		#endregion // Exchange
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class ExchangeExchangeRequest : APIRequest
	{
		[JsonProperty("exchange_item_id")]
		public long exchangeItemId { get; set; }
		[JsonProperty("exchange_count")]
		public long exchangeCount { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class ExchangeExchangeResponse : APIResponse
	{
	}
}
