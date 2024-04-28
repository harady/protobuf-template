//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class FriendService : AbstractApiService
{
	#region Singleton
	public static FriendService instance {
		get { return SingletonContainer.GetInstance<FriendService>(); }
	}
	#endregion

	private void ListInner(
		FriendListRequest request,
		Action<FriendListResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friend/list";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<FriendListResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (FriendListResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void RemoveInner(
		FriendRemoveRequest request,
		Action<FriendRemoveResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friend/remove";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<FriendRemoveResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (FriendRemoveResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void SearchInner(
		FriendSearchRequest request,
		Action<FriendSearchResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friend/search";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<FriendSearchResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (FriendSearchResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void RequestInner(
		FriendRequestRequest request,
		Action<FriendRequestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friend/request";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<FriendRequestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (FriendRequestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static FriendService FriendService
		=> FriendService.instance;
}
#region Request/Response
public partial class FriendListRequest : CommonRequest
{
}

public partial class FriendListResponse : APIResponse
{
	[JsonProperty("other_users")]
	public List<OtherUserData> otherUsers { get; set; } 
		= new List<OtherUserData>();
}

public partial class FriendRemoveRequest : CommonRequest
{
	[JsonProperty("user_id")]
	public long userId { get; set; }
}

public partial class FriendRemoveResponse : APIResponse
{
}

public partial class FriendSearchRequest : CommonRequest
{
	[JsonProperty("code")]
	public long code { get; set; }
}

public partial class FriendSearchResponse : APIResponse
{
	[JsonProperty("other_user")]
	public OtherUserData otherUser { get; set; }
}

public partial class FriendRequestRequest : CommonRequest
{
	[JsonProperty("user_id")]
	public long userId { get; set; }
}

public partial class FriendRequestResponse : APIResponse
{
}
#endregion
