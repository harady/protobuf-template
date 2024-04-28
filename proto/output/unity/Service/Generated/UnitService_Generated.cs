//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class UnitService : AbstractApiService
{
	#region Singleton
	public static UnitService instance {
		get { return SingletonContainer.GetInstance<UnitService>(); }
	}
	#endregion

	private void DeckEditInner(
		UnitDeckEditRequest request,
		Action<UnitDeckEditResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/unit/deck_edit";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<UnitDeckEditResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (UnitDeckEditResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void PowerupInner(
		UnitPowerupRequest request,
		Action<UnitPowerupResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/unit/powerup";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<UnitPowerupResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (UnitPowerupResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void EvolutionInner(
		UnitEvolutionRequest request,
		Action<UnitEvolutionResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/unit/evolution";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<UnitEvolutionResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (UnitEvolutionResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void SellInner(
		UnitSellRequest request,
		Action<UnitSellResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/unit/sell";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<UnitSellResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (UnitSellResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void LockInner(
		UnitLockRequest request,
		Action<UnitLockResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/unit/lock";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<UnitLockResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (UnitLockResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static UnitService UnitService
		=> UnitService.instance;
}
#region Request/Response
public partial class UnitDeckEditRequest : CommonRequest
{
	[JsonProperty("user_deck")]
	public UserDeckData userDeck { get; set; }
}

public partial class UnitDeckEditResponse : APIResponse
{
}

public partial class UnitPowerupRequest : CommonRequest
{
	[JsonProperty("user_unit_id")]
	public long userUnitId { get; set; }
	[JsonProperty("consume_resources")]
	public List<ResourceData> consumeResources { get; set; } 
		= new List<ResourceData>();
}

public partial class UnitPowerupResponse : APIResponse
{
}

public partial class UnitEvolutionRequest : CommonRequest
{
	[JsonProperty("user_unit_id")]
	public long userUnitId { get; set; }
	[JsonProperty("unit_evolution_id")]
	public long unitEvolutionId { get; set; }
	[JsonProperty("consume_resources")]
	public List<ResourceData> consumeResources { get; set; } 
		= new List<ResourceData>();
}

public partial class UnitEvolutionResponse : APIResponse
{
}

public partial class UnitSellRequest : CommonRequest
{
	[JsonProperty("user_unit_ids")]
	public List<long> userUnitIds { get; set; } 
		= new List<long>();
}

public partial class UnitSellResponse : APIResponse
{
}

public partial class UnitLockRequest : CommonRequest
{
	[JsonProperty("user_unit_id")]
	public long userUnitId { get; set; }
	[JsonProperty("is_locked")]
	public bool isLocked { get; set; }
}

public partial class UnitLockResponse : APIResponse
{
}
#endregion
