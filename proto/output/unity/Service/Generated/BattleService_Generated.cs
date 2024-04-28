//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class BattleService : AbstractApiService
{
	#region Singleton
	public static BattleService instance {
		get { return SingletonContainer.GetInstance<BattleService>(); }
	}
	#endregion

	private void HelperListInner(
		BattleHelperListRequest request,
		Action<BattleHelperListResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/battle/helper_list";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<BattleHelperListResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (BattleHelperListResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void StartInner(
		BattleStartRequest request,
		Action<BattleStartResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/battle/start";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<BattleStartResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (BattleStartResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void ContinueInner(
		BattleContinueRequest request,
		Action<BattleContinueResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/battle/continue";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<BattleContinueResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (BattleContinueResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void GiveupInner(
		BattleGiveupRequest request,
		Action<BattleGiveupResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/battle/giveup";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<BattleGiveupResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (BattleGiveupResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void ClearInner(
		BattleClearRequest request,
		Action<BattleClearResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/battle/clear";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<BattleClearResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (BattleClearResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static BattleService BattleService
		=> BattleService.instance;
}
#region Request/Response
public partial class BattleHelperListRequest : CommonRequest
{
	[JsonProperty("stage_id")]
	public long stageId { get; set; }
}

public partial class BattleHelperListResponse : APIResponse
{
	[JsonProperty("other_users")]
	public List<OtherUserData> otherUsers { get; set; } 
		= new List<OtherUserData>();
}

public partial class BattleStartRequest : CommonRequest
{
	[JsonProperty("stage_id")]
	public long stageId { get; set; }
	[JsonProperty("user_deck_id")]
	public long userDeckId { get; set; }
	[JsonProperty("helper_user_id")]
	public long helperUserId { get; set; }
}

public partial class BattleStartResponse : APIResponse
{
	[JsonProperty("battle_id")]
	public long battleId { get; set; }
	[JsonProperty("battle_client")]
	public BattleClientData battleClient { get; set; }
}

public partial class BattleContinueRequest : CommonRequest
{
	[JsonProperty("battle_id")]
	public long battleId { get; set; }
}

public partial class BattleContinueResponse : APIResponse
{
}

public partial class BattleGiveupRequest : CommonRequest
{
	[JsonProperty("battle_id")]
	public long battleId { get; set; }
}

public partial class BattleGiveupResponse : APIResponse
{
}

public partial class BattleClearRequest : CommonRequest
{
	[JsonProperty("battle_id")]
	public long battleId { get; set; }
	[JsonProperty("battle_result")]
	public BattleResultData battleResult { get; set; }
}

public partial class BattleClearResponse : APIResponse
{
	[JsonProperty("result")]
	public long result { get; set; }
	[JsonProperty("battle_rewards")]
	public BattleRewardsData battleRewards { get; set; }
}
#endregion
