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
	public partial class MissionServiceBase : ServiceBase
	{

		#region Achieve
		public async Task<APIGatewayProxyResponse> Achieve(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<MissionAchieveRequest>(request);
			Console.WriteLine("Mission/Achieve apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await AchieveImpl(apiRequest, context);
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
			Console.WriteLine("Mission/Achieve apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<MissionAchieveResponse> AchieveImpl(
			MissionAchieveRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("AchieveImpl is not implemented"));
			return new MissionAchieveResponse();
		}
		#endregion // Achieve
		#region Receive
		public async Task<APIGatewayProxyResponse> Receive(
			APIGatewayProxyRequest request, ILambdaContext context)
		{
			var apiRequest = GetApiRequest<MissionReceiveRequest>(request);
			Console.WriteLine("Mission/Receive apiRequest=" + JsonConvert.SerializeObject(apiRequest));

			await MongoSessionManager.StartSessionAsync();
			MongoSessionManager.StartTransaction();

			object apiResponse;
			try {
				apiResponse = await ReceiveImpl(apiRequest, context);
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
			Console.WriteLine("Mission/Receive apiResponse=" + JsonConvert.SerializeObject(apiResponse));
			var response = GetAPIGatewayProxyResponse(apiResponse);
			return response;
		}

		public virtual async Task<MissionReceiveResponse> ReceiveImpl(
			MissionReceiveRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ReceiveImpl is not implemented"));
			return new MissionReceiveResponse();
		}
		#endregion // Receive
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class MissionAchieveRequest : APIRequest
	{
		[JsonProperty("mission_id")]
		public long missionId { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class MissionAchieveResponse : APIResponse
	{
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class MissionReceiveRequest : APIRequest
	{
		[JsonProperty("mission_ids")]
		public List<long> missionIds { get; set; } = new List<long>();
	}

	[JsonObject(MemberSerialization.OptIn)]
	public partial class MissionReceiveResponse : APIResponse
	{
	}
}
