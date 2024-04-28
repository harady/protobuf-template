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
	public partial class GachaServiceBase : ServiceBase
	{

		#region Draw
		public async Task<APIGatewayProxyResponse> Draw(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<GachaDrawRequest>(request);
			Console.WriteLine("Gacha/Draw apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await DrawImpl(apiRequest, context);
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
			Console.WriteLine("Gacha/Draw apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<GachaDrawResponse> DrawImpl(
			GachaDrawRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("DrawImpl is not implemented"));
			return new GachaDrawResponse();
		}
		#endregion // Draw
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class GachaDrawRequest : APIRequest
	{
		[JsonProperty("gacha_button_id")]
		public long gachaButtonId { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class GachaDrawResponse : APIResponse
	{
		[JsonProperty("gacha_result_items")]
		public List<GachaResultItemData> gachaResultItems { get; set; } = new List<GachaResultItemData>();
	}
}
